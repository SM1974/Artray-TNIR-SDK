using ArtCamSdk; //Added by sfm36
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; //Added by sfm36
using System.Text;
using System.Windows.Forms;

namespace Sample_CS
{
    public partial class Form8 : Form
	{
		// Our private variables
		private CArtCam m_CArtCam = new CArtCam();
		private Bitmap m_Bitmap;
		private byte[] m_pCapture;      
		
		// User available properties
		int startExposure = 21;
		int endExposure = 2000;
		int exposureStep = 1000;

		public Form8()
		{
			InitializeComponent();
		}

		/* Comment out this section as dispposing is done in Form1
		
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);

			m_CArtCam.Release();

			if (m_Bitmap != null)
			{
				m_Bitmap.Dispose();
				m_Bitmap = null;
			}

			m_CArtCam.FreeLibrary();
		}
		*/

		/* Comment out this section as IProgress does not work on Net2 framework (need 4.5.2)
		 * private async void DoStuffButton_Click(object sender, EventArgs e)
		{
			// NB: This function just loads a background thread to do the work and can safely be ignored
			// The function you are actually looking for is DoStuff() :-)
			DoStuffButton.Enabled = false;

			// Get the date/time prefix we use for saving
			string prefix = DateTime.Now.ToString("yyyyMMddHHmmss");

			// Process variables
			int totalSteps = (int)Math.Ceiling(((double)(endExposure - startExposure)) / exposureStep + 1);

			// Setup progress bar
			ProgressBar.Maximum = totalSteps;
			ProgressBar.Step = 1;

			var progress = new Progress<int>(v =>
			{
				// This lambda is executed in context of UI thread,
				// so it can safely update form controls
				ProgressBar.Value = v;
			});

			// Run operation in another thread
			await Task.Run(() => DoStuff(prefix, progress));
			ProgressBar.Value = 0;

			DoStuffButton.Enabled = true;
		}
		*/

		// public void DoStuff(string prefix, IProgress<int> progress)
		private void DoStuffButton_Click(object sender, EventArgs e)
		{
			// Set gain defaults (probably not necessary)
			m_CArtCam.SetGlobalGain(0);
			m_CArtCam.SetColorGainRed(0);
			m_CArtCam.SetColorGainGreen1(0);
			m_CArtCam.SetColorGainGreen2(0);
			m_CArtCam.SetColorGainBlue(0);
			m_CArtCam.SetBayerGainRed(0);
			m_CArtCam.SetBayerGainGreen(0);
			m_CArtCam.SetBayerGainBlue(0);

			// Other setup. Note that we get 64 bit colour out, we can then save only one channel
			m_CArtCam.SetColorMode(64);

			// Added by sfm36. Get the date/time prefix we use for saving
			string prefix = DateTime.Now.ToString("yyyyMMddHHmmss");


			// Ok, lets loop over some stuff
			int totalSteps = (int)Math.Ceiling(((double)(endExposure - startExposure)) / exposureStep + 1);
			for (int step = 0; step < totalSteps; step++)
			{
				//Console.WriteLine(string.Format("Starting capture step {0} of {1}.", step + 1, totalSteps));
				//progress.Report(step + 1);

				// Set loop varying properties
				int currentExposure = startExposure + step * exposureStep;
				m_CArtCam.SetExposureTime(currentExposure);

				/*
				// Acquire image
				Console.WriteLine("Acquiring image...");
				m_CArtCam.Close();
				m_Bitmap = new Bitmap(m_CArtCam.Width(), m_CArtCam.Height(), PixelFormat.Format24bppRgb);
				m_pCapture = new Byte[((m_CArtCam.Width() * (16 / 8) + 3) & ~3) * m_CArtCam.Height()];
				*/
				if (m_CArtCam.SnapShot(m_pCapture, m_pCapture.Length, 1) <= 0)
				{
					Console.WriteLine("Failed to read image, returning");
					return;
				}

				// Save image
				string location = string.Format("{0}/{1}_{2}_{3}.tif", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), prefix, step + 1, 1); //change file suffix
				//string location = string.Format("{0}/{1}_{2}_{3}.png", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), prefix, step + 1, 1);
				Console.WriteLine("Saving image to \"{0}\"...", location);
				if (m_CArtCam.SaveImage(location, FILETYPE.FILETYPE_TIFF) <= 0)
				{
					Console.WriteLine("Failed to save image, returning");
					return;
				}
			}
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
			int exp_t, int_T, perSet_n, numSet;
			exp_t = Convert.ToInt32(text_exp_t.Text);
			int_T = Convert.ToInt32(text_int_T.Text);
			perSet_n = Convert.ToInt32(text_perSet_n.Text);
			numSet = Convert.ToInt32(text_numSets_N.Text);


		}

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
