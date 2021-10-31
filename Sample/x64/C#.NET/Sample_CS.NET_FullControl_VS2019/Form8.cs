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
		// private CArtCam m_CArtCam = null;

		//Send set-up values from Form8 to Form1
		public string [] GetValuesInForm8
		{
			get
			{
				return new string[] { 
									text_exp_t.Text,
									text_int_T.Text,
									text_perSet_n.Text,
									text_numSets_N.Text,
									saveImageFolder.Text,
									baseFilename.Text
									};
			}
		}

		public Form8()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


		}

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
			FolderBrowserDialog artrayFolder = new FolderBrowserDialog();
			// The ideal default root folder is ...Documents\Artray\EMVA_1288\Images
			// However, the RootFolder property is only configurable to a Special Folder
			artrayFolder.RootFolder = Environment.SpecialFolder.MyDocuments;
			artrayFolder.Description = "Choose folder for saved images";
			if (artrayFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				saveImageFolder.Text = artrayFolder.SelectedPath;
			}

		}
	}
}
