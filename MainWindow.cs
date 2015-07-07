using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ImageMagick;
using System.Threading;

namespace GifCapture
{
	struct FrameInfo
	{
		public Bitmap Bitmap;
		public int Time;
	}

	public partial class MainWindow : Form
	{
		bool recording;
		int lastTick;

		List<FrameInfo> recorded;
		long bytesUsed;
		
		public MainWindow()
		{
			InitializeComponent();
			bytesUsed = 0;
			recorded = new List<FrameInfo>(4096);
			Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			toolContainer_ContentPanel_Resize(null, null);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (noFocus.Checked && ContainsFocus)
				return;

			Bitmap bmp = new Bitmap(recordSize.Width, recordSize.Height, PixelFormat.Format32bppArgb);

			Graphics gfx = Graphics.FromImage(bmp);
			Rectangle recordScreen = toolContainer.ContentPanel.RectangleToScreen(new Rectangle(0, 0, recordSize.Width, recordSize.Height));
			gfx.CopyFromScreen(recordScreen.X, recordScreen.Y, 0, 0, recordSize, CopyPixelOperation.SourceCopy);
			gfx.Flush();
			gfx.Dispose();

			int newTick = Environment.TickCount;
			int diffTick = newTick - lastTick;
			lastTick = newTick;
			recorded.Add(new FrameInfo() { Bitmap = bmp, Time = diffTick });
			bytesUsed += (long)(recordSize.Width * recordSize.Height * 4);
			storageUse.Text = /*(bytesUsed / 1024 / 1024).ToString() + " MiB " +*/ recorded.Count + " Frames";
			updateRamLabel();
		}

		private void toolContainer_ContentPanel_Resize(object sender, EventArgs e)
		{
			sizeLabel.Text = toolContainer.ContentPanel.Size.Width + "x"
				+ toolContainer.ContentPanel.Size.Height;
		}

		Size recordSize;

		private void recordButton_Click(object sender, EventArgs e)
		{
			recordSize = toolContainer.ContentPanel.Size;

			lastTick = Environment.TickCount;
			recording = true;
			timer.Enabled = true;
			recordButton.Enabled = false;
			pauseButton.Enabled = true;
			saveButton.Enabled = false;
			eraseButton.Enabled = false;
			FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		private void pauseButton_Click(object sender, EventArgs e)
		{
			recording = false;
			timer.Enabled = false;
			recordButton.Enabled = true;
			pauseButton.Enabled = false;
			saveButton.Enabled = true;
			eraseButton.Enabled = true;
		}

		private void eraseButton_Click(object sender, EventArgs e)
		{
			Parallel.For(0, recorded.Count, (i) =>
			{
				recorded[i].Bitmap.Dispose();
			});
			recorded.Clear();
			GC.Collect();
			bytesUsed = 0;
			storageUse.Text = "0 Frames";
			updateRamLabel();
			FormBorderStyle = FormBorderStyle.Sizable;
		}

		void updateRamLabel()
		{
			ramLabel.Text = (System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024).ToString() + " MiB RAM";
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (recorded.Count > 0)
			{
				DialogResult dr = saveFileDialog.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK)
				{
					toolContainer.Enabled = false;
					fileName = saveFileDialog.FileName;
					progressTool.Visible = true;
					progressBar.Maximum = recorded.Count;
					t = new Thread(new ThreadStart(SaveFile));
					t.Start();
				}
			}
		}

		Thread t;
		int progress;
		int progressMax;
		string fileName;
		Exception exc;
		private void SaveFile()
		{
			try
			{
				progress = 0;
				progressMax = (recorded.Count * 4);
				MagickImage[] mia = new MagickImage[recorded.Count];
				Parallel.For(0, recorded.Count, (i) =>
				{
					mia[i] = new MagickImage(recorded[i].Bitmap);
					int pr = Interlocked.Increment(ref progress);
					if (pr % 16 == 0) Invoke(new EmptyCallback(showProgress));
				});
				progressMax = progress + (mia.Length * 3);
				bool[] mid = new bool[mia.Length];
				mid[0] = false;
				Parallel.For(1, mia.Length, (i) =>
				{
					mid[i] = mia[i].Equals(mia[i - 1]);
					int pr = Interlocked.Increment(ref progress);
					if (pr % 4 == 0) Invoke(new EmptyCallback(showProgress));
				});
				Parallel.For(1, mia.Length, (i) =>
				{
					if (mid[i])
					{
						mia[i].Dispose();
						mia[i] = null;
					}
				});
				progressMax = progress + (mia.Length * 2);
				MagickImageCollection mic = new MagickImageCollection();
				QuantizeSettings qs = new QuantizeSettings();
				qs.Colors = 256;
				int timeOffset = 0;
				int addi = -1;
				for (int i = 0; i < mia.Length; ++i)
				{
					MagickImage mi = mia[i];
					int addDelay;
					if (mi != null)
					{
						mic.Add(mi);
						++addi;
						addDelay = 0;
					}
					else
					{
						addDelay = mic[addi].AnimationDelay;
					}
					int delayMs = recorded[((i + 1) < recorded.Count) ? i + 1 : i].Time + timeOffset;
					int delayCs = delayMs / 10;
					timeOffset = delayMs - (delayCs * 10);
					mic[addi].AnimationDelay = delayCs + addDelay;
					++progress;
					if (progress % 32 == 0) Invoke(new EmptyCallback(showProgress));
				}
				// mic.OptimizePlus();
				progressMax = progress + (mic.Count);
				Parallel.For(0, mic.Count, (i) =>
				{
					mic[i].Quantize(qs);
					int pr = Interlocked.Increment(ref progress);
					Invoke(new EmptyCallback(showProgress));
				});
				mic.Write(fileName);
				Parallel.For(0, mic.Count, (i) =>
				{
					mic[i].Dispose();
				});
				mic.Dispose();
				GC.Collect();
			}
			catch (Exception ex)
			{
				exc = ex;
			}
			Invoke(new EmptyCallback(doneSaving));
		}

		void showProgress()
		{
			progressBar.Value = progress;
			progressBar.Maximum = progressMax;
			updateRamLabel();
		}

		delegate void EmptyCallback();
		void doneSaving()
		{
			t = null;
			progressTool.Visible = false;
			toolContainer.Enabled = true;
			fileName = null;
			if (exc != null)
			{
				MessageBox.Show(exc.ToString());
				exc = null;
			}
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (t != null)
			{
				t.Abort();
			}
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			updateRamLabel();
		}
	}
}
