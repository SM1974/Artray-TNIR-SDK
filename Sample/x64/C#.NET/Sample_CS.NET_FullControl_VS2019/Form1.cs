using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using ArtCamSdk;


namespace Sample_CS
{
	/// <summary>
	/// This is an explanation for outline of "Form1".
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;

		private byte[] m_pCapture;
		private Bitmap m_Bitmap = null;
		private int m_PreviewMode = -1;
		private int m_SelectDevice = -1;
		private CArtCam m_CArtCam = new CArtCam();
		private string m_RecName;
		private bool m_SaveFlg = false;
		private bool m_StopFlg = false;

		private int  m_ViewScale = 100;

		private ARTCAM_CAMERATYPE m_CurrentCameraType;
		private int m_DllType  = -1;
		private int m_DllCount = 0;
		private int m_DllSata  = -1;
		private int m_SataType = -1;

		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuView;
		private System.Windows.Forms.MenuItem menuPreview;
		private System.Windows.Forms.MenuItem menuCallback;
		private System.Windows.Forms.MenuItem menuSnapshot;
		private System.Windows.Forms.MenuItem menuCapture;
		private System.Windows.Forms.MenuItem menuTrigger;
		private System.Windows.Forms.MenuItem menuSet;
		private System.Windows.Forms.MenuItem menuCamera;
		private System.Windows.Forms.MenuItem menuFilter;
		private System.Windows.Forms.MenuItem menuAnalog;
		private System.Windows.Forms.MenuItem menuDevice;
		private System.Windows.Forms.MenuItem menuDevice0;
		private System.Windows.Forms.MenuItem menuDevice1;
		private System.Windows.Forms.MenuItem menuDevice2;
		private System.Windows.Forms.MenuItem menuDevice3;
		private System.Windows.Forms.MenuItem menuDevice4;
		private System.Windows.Forms.MenuItem menuDevice5;
		private System.Windows.Forms.MenuItem menuDevice6;
		private System.Windows.Forms.MenuItem menuDevice7;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuRec;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Timer timerRec;
		private System.Windows.Forms.MenuItem menuStop;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuDLL;
		private System.Windows.Forms.MenuItem menuDllReload;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.Panel ImagePanel;
		private System.Windows.Forms.StatusBarPanel sbPanelSdkStatus;
		private System.Windows.Forms.StatusBarPanel sbPanelFps;
		private System.Windows.Forms.StatusBarPanel sbPanelScale;
		private System.Windows.Forms.StatusBarPanel sbPanelExp;
		private MenuItem menuItem6;
		private MenuItem MenuUserCorrection;
        private MenuItem menuAction;
        private MenuItem menuSequence;
        private MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timer1;


		[DllImport("user32.dll")]
		public static extern IntPtr GetWindow (IntPtr hWnd, int uCmd);

		[DllImport("user32.dll")]
		public static extern int SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);


		public Form1()
		{
			//
			// This is needed for Windows form designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after calling InitializeComponent.
			//
		}

		/// <summary>
		/// Execute after-treatment to resource used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );

			Release();
			m_CArtCam.FreeLibrary();

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// This method is required for designer support.
		/// Do not change the content of this method by code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuRec = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuView = new System.Windows.Forms.MenuItem();
            this.menuPreview = new System.Windows.Forms.MenuItem();
            this.menuCallback = new System.Windows.Forms.MenuItem();
            this.menuSnapshot = new System.Windows.Forms.MenuItem();
            this.menuCapture = new System.Windows.Forms.MenuItem();
            this.menuTrigger = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuStop = new System.Windows.Forms.MenuItem();
            this.menuSet = new System.Windows.Forms.MenuItem();
            this.menuCamera = new System.Windows.Forms.MenuItem();
            this.menuFilter = new System.Windows.Forms.MenuItem();
            this.menuAnalog = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.MenuUserCorrection = new System.Windows.Forms.MenuItem();
            this.menuDLL = new System.Windows.Forms.MenuItem();
            this.menuDllReload = new System.Windows.Forms.MenuItem();
            this.menuDevice = new System.Windows.Forms.MenuItem();
            this.menuDevice0 = new System.Windows.Forms.MenuItem();
            this.menuDevice1 = new System.Windows.Forms.MenuItem();
            this.menuDevice2 = new System.Windows.Forms.MenuItem();
            this.menuDevice3 = new System.Windows.Forms.MenuItem();
            this.menuDevice4 = new System.Windows.Forms.MenuItem();
            this.menuDevice5 = new System.Windows.Forms.MenuItem();
            this.menuDevice6 = new System.Windows.Forms.MenuItem();
            this.menuDevice7 = new System.Windows.Forms.MenuItem();
            this.menuAction = new System.Windows.Forms.MenuItem();
            this.menuSequence = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timerRec = new System.Windows.Forms.Timer(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbPanelSdkStatus = new System.Windows.Forms.StatusBarPanel();
            this.sbPanelExp = new System.Windows.Forms.StatusBarPanel();
            this.sbPanelFps = new System.Windows.Forms.StatusBarPanel();
            this.sbPanelScale = new System.Windows.Forms.StatusBarPanel();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelSdkStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.ImagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuView,
            this.menuSet,
            this.menuDLL,
            this.menuDevice,
            this.menuAction});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSave,
            this.menuRec,
            this.menuExit});
            this.menuFile.Text = "File(&F)";
            this.menuFile.Popup += new System.EventHandler(this.menuFile_Popup);
            // 
            // menuSave
            // 
            this.menuSave.Index = 0;
            this.menuSave.Text = "Save(&S)";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuRec
            // 
            this.menuRec.Index = 1;
            this.menuRec.Text = "Recording(&R)";
            this.menuRec.Click += new System.EventHandler(this.menuRec_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 2;
            this.menuExit.Text = "End(&X)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuView
            // 
            this.menuView.Index = 1;
            this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuPreview,
            this.menuCallback,
            this.menuSnapshot,
            this.menuCapture,
            this.menuTrigger,
            this.menuItem5,
            this.menuStop});
            this.menuView.Text = "Display(&V)";
            this.menuView.Popup += new System.EventHandler(this.menuView_Popup);
            // 
            // menuPreview
            // 
            this.menuPreview.Index = 0;
            this.menuPreview.Text = "Preview(&P)";
            this.menuPreview.Click += new System.EventHandler(this.menuPreview_Click);
            // 
            // menuCallback
            // 
            this.menuCallback.Index = 1;
            this.menuCallback.Text = "Callback(&B)";
            this.menuCallback.Click += new System.EventHandler(this.menuCallback_Click);
            // 
            // menuSnapshot
            // 
            this.menuSnapshot.Index = 2;
            this.menuSnapshot.Text = "Snapshot(&S)";
            this.menuSnapshot.Click += new System.EventHandler(this.menuSnapshot_Click);
            // 
            // menuCapture
            // 
            this.menuCapture.Index = 3;
            this.menuCapture.Text = "Capture(&C)";
            this.menuCapture.Click += new System.EventHandler(this.menuCapture_Click);
            // 
            // menuTrigger
            // 
            this.menuTrigger.Index = 4;
            this.menuTrigger.Text = "Trigger(&T)";
            this.menuTrigger.Click += new System.EventHandler(this.menuTrigger_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.Text = "-";
            // 
            // menuStop
            // 
            this.menuStop.Index = 6;
            this.menuStop.Text = "Pause";
            this.menuStop.Click += new System.EventHandler(this.menuStop_Click);
            // 
            // menuSet
            // 
            this.menuSet.Index = 2;
            this.menuSet.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuCamera,
            this.menuFilter,
            this.menuAnalog,
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem7,
            this.menuItem6,
            this.MenuUserCorrection});
            this.menuSet.Text = "Settings(&S)";
            this.menuSet.Click += new System.EventHandler(this.menuSet_Click);
            this.menuSet.Popup += new System.EventHandler(this.menuSet_Popup);
            // 
            // menuCamera
            // 
            this.menuCamera.Index = 0;
            this.menuCamera.Text = "Camera settings(&C)";
            this.menuCamera.Click += new System.EventHandler(this.menuCamera_Click);
            // 
            // menuFilter
            // 
            this.menuFilter.Index = 1;
            this.menuFilter.Text = "Filter settings(&F)";
            this.menuFilter.Click += new System.EventHandler(this.menuFilter_Click);
            // 
            // menuAnalog
            // 
            this.menuAnalog.Index = 2;
            this.menuAnalog.Text = "Analog settings(&A)";
            this.menuAnalog.Click += new System.EventHandler(this.menuAnalog_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "User size settings";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            this.menuItem3.Text = "User filter settings";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.Text = "User IO settings";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "User monitor settings";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_1);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 8;
            this.menuItem6.Text = "-";
            // 
            // MenuUserCorrection
            // 
            this.MenuUserCorrection.Index = 9;
            this.MenuUserCorrection.Text = "Correction setting";
            this.MenuUserCorrection.Click += new System.EventHandler(this.MenuUserCorrection_Click);
            // 
            // menuDLL
            // 
            this.menuDLL.Index = 3;
            this.menuDLL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDllReload});
            this.menuDLL.Text = "DLL(&L)";
            // 
            // menuDllReload
            // 
            this.menuDllReload.Index = 0;
            this.menuDllReload.Text = "Reload";
            this.menuDllReload.Click += new System.EventHandler(this.OnDllReload);
            // 
            // menuDevice
            // 
            this.menuDevice.Index = 4;
            this.menuDevice.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDevice0,
            this.menuDevice1,
            this.menuDevice2,
            this.menuDevice3,
            this.menuDevice4,
            this.menuDevice5,
            this.menuDevice6,
            this.menuDevice7});
            this.menuDevice.Text = "Device(&D)";
            // 
            // menuDevice0
            // 
            this.menuDevice0.Index = 0;
            this.menuDevice0.Text = "0";
            this.menuDevice0.Click += new System.EventHandler(this.menuDevice0_Click);
            // 
            // menuDevice1
            // 
            this.menuDevice1.Index = 1;
            this.menuDevice1.Text = "1";
            this.menuDevice1.Click += new System.EventHandler(this.menuDevice1_Click);
            // 
            // menuDevice2
            // 
            this.menuDevice2.Index = 2;
            this.menuDevice2.Text = "2";
            this.menuDevice2.Click += new System.EventHandler(this.menuDevice2_Click);
            // 
            // menuDevice3
            // 
            this.menuDevice3.Index = 3;
            this.menuDevice3.Text = "3";
            this.menuDevice3.Click += new System.EventHandler(this.menuDevice3_Click);
            // 
            // menuDevice4
            // 
            this.menuDevice4.Index = 4;
            this.menuDevice4.Text = "4";
            this.menuDevice4.Click += new System.EventHandler(this.menuDevice4_Click);
            // 
            // menuDevice5
            // 
            this.menuDevice5.Index = 5;
            this.menuDevice5.Text = "5";
            this.menuDevice5.Click += new System.EventHandler(this.menuDevice5_Click);
            // 
            // menuDevice6
            // 
            this.menuDevice6.Index = 6;
            this.menuDevice6.Text = "6";
            this.menuDevice6.Click += new System.EventHandler(this.menuDevice6_Click);
            // 
            // menuDevice7
            // 
            this.menuDevice7.Index = 7;
            this.menuDevice7.Text = "7";
            this.menuDevice7.Click += new System.EventHandler(this.menuDevice7_Click);
            // 
            // menuAction
            // 
            this.menuAction.Index = 5;
            this.menuAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSequence});
            this.menuAction.Text = "Action(&A)";
            // 
            // menuSequence
            // 
            this.menuSequence.Index = 0;
            this.menuSequence.Text = "Image sequence (&S)";
            this.menuSequence.Click += new System.EventHandler(this.menuSequence_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "doc1";
            // 
            // timerRec
            // 
            this.timerRec.Tick += new System.EventHandler(this.timerRec_Tick);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(0, 494);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbPanelSdkStatus,
            this.sbPanelExp,
            this.sbPanelFps,
            this.sbPanelScale});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(640, 17);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 0;
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // sbPanelSdkStatus
            // 
            this.sbPanelSdkStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbPanelSdkStatus.Name = "sbPanelSdkStatus";
            this.sbPanelSdkStatus.Text = "Not initialized";
            this.sbPanelSdkStatus.Width = 300;
            // 
            // sbPanelExp
            // 
            this.sbPanelExp.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbPanelExp.MinWidth = 100;
            this.sbPanelExp.Name = "sbPanelExp";
            this.sbPanelExp.Width = 120;
            // 
            // sbPanelFps
            // 
            this.sbPanelFps.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbPanelFps.Name = "sbPanelFps";
            this.sbPanelFps.Text = "0.0fps";
            this.sbPanelFps.Width = 120;
            // 
            // sbPanelScale
            // 
            this.sbPanelScale.Name = "sbPanelScale";
            this.sbPanelScale.Text = "100%";
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(16, 17);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(40, 44);
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBox_Paint);
            // 
            // ImagePanel
            // 
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.SystemColors.Control;
            this.ImagePanel.Controls.Add(this.ImageBox);
            this.ImagePanel.Location = new System.Drawing.Point(48, 35);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(552, 433);
            this.ImagePanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(640, 481);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "C# Sample";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelSdkStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPanelScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ImagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Main entry point for application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		protected override unsafe void WndProc(ref Message m)
		{
			// WM_GRAPHNOTIFY
			if(DLL_MESSAGE.WM_GRAPHNOTIFY == (DLL_MESSAGE)m.Msg)
			{
			}
				// WM_ERROR
			else if(DLL_MESSAGE.WM_ERROR == (DLL_MESSAGE)m.Msg)
			{
				int error = (int)m.LParam;
				switch((ARTCAMSDK_ERROR)error){
					case ARTCAMSDK_ERROR.ARTCAMSDK_NOERROR :		sbPanelSdkStatus.Text = "Normal";															break;	
					case ARTCAMSDK_ERROR.ARTCAMSDK_NOT_INITIALIZE:	sbPanelSdkStatus.Text = "Not initialized";													break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_DISABLEDDEVICE:	sbPanelSdkStatus.Text = "Access to unavailable device was attempted";						break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CREATETHREAD:	sbPanelSdkStatus.Text = "Failure of thread creation for capturing";							break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CREATEWINDOW:	sbPanelSdkStatus.Text = "Window creation failed";											break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_OUTOFMEMORY:		sbPanelSdkStatus.Text = "Not enough memory for image transfer/Failure for securing memory";	break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CAMERASET:		sbPanelSdkStatus.Text = "Error for camera (device) settings";								break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CAMERASIZE:		sbPanelSdkStatus.Text = "Error for camera (device) size settings;";							break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CAPTURE:			sbPanelSdkStatus.Text = "Capturing failed";													break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_PARAM:			sbPanelSdkStatus.Text = "Wrong argument";													break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_DIRECTSHOW:		sbPanelSdkStatus.Text = "Directshow initialization error";									break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_UNSUPPORTED:		sbPanelSdkStatus.Text = "Not supported";													break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_UNKNOWN:			sbPanelSdkStatus.Text = "Unknow error";														break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_CAPTURELOST:		sbPanelSdkStatus.Text = "Device lost";														break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_FILENOTFOUND:	sbPanelSdkStatus.Text = "File not found";													break;
					case ARTCAMSDK_ERROR.ARTCAMSDK_FPGASET:			sbPanelSdkStatus.Text = "FPGA settings error";												break;
					default:										sbPanelSdkStatus.Text = "";															break;
				}
			}
				// WM_GRAPHPAINT
			else if(DLL_MESSAGE.WM_GRAPHPAINT == (DLL_MESSAGE)m.Msg)
			{
				GP_INFO* pInfo = (GP_INFO*)m.WParam;
				if(pInfo != null)
				{
				m_SaveFlg = true;
					ImageBox.Invalidate();
					float fps = ((float)pInfo->lFps / 10.0f);
					sbPanelFps.Text = fps.ToString("F1") + "fps";
				}

			}
			else
			{
				base.WndProc(ref m);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Drawing by double buffer(not to flicker)
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			if(File.Exists("Sample.xml"))
				{
				System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(int[]));
				System.IO.FileStream fs = new System.IO.FileStream("Sample.xml", System.IO.FileMode.Open);
				int[] Type = new int[2];
				Type = (int[])ser.Deserialize(fs);
				fs.Close();
				m_DllType = Type[0];
				m_SataType= Type[1];
			}
			OnDllReload(sender, e);
			if( -1 != m_DllType){
				OnDllChange((object)0, System.EventArgs.Empty, m_DllType, m_SataType);
				}
			}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(m_DllType != -1)
			{
				int[] Type = {(int)m_DllType, (int)m_SataType};
				System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(int[]));
				System.IO.FileStream fs = new System.IO.FileStream("Sample.xml", System.IO.FileMode.Create);
				ser.Serialize(fs, Type);
				fs.Close();
		}

			Release();
		}

		private void Release()
		{
			m_CArtCam.Release();

			if(m_Bitmap != null)
			{
				m_Bitmap.Dispose();
				m_Bitmap = null;
			}
			
			m_PreviewMode = -1;
			timer1.Enabled = false;
			timerRec.Enabled = false;
			m_SaveFlg = false;
			m_StopFlg = false;
		}


		// Save
		private void menuSave_Click(object sender, System.EventArgs e)
		{
	       saveFileDialog1.Filter = "BITMAPFile(*.bmp)|*.bmp|JPEGFile(*.jpg)|*.jpg*.jpeg|TIFFFile(*.tif)|*.tif*.tiff|PNGFile(*.png)|*.png|RAWFile(*.raw)|*.raw||"  ;

			if(DialogResult.OK == saveFileDialog1.ShowDialog())
			{
				// Set extension yourself
				FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);

				string str = fileInfo.FullName.Remove(fileInfo.FullName.Length - fileInfo.Extension.Length, fileInfo.Extension.Length);
				switch(saveFileDialog1.FilterIndex)
				{
					case 1:	str += ".bmp";	m_CArtCam.SaveImage(str, FILETYPE.FILETYPE_BITMAP);		break;
					case 2:	str += ".jpg";	m_CArtCam.SaveImage(str, FILETYPE.FILETYPE_JPEG_HIGH);	break;
					case 3:	str += ".tif";	m_CArtCam.SaveImage(str, FILETYPE.FILETYPE_TIFF);		break;
					case 4:	str += ".png";	m_CArtCam.SaveImage(str, FILETYPE.FILETYPE_PNG);		break;
					case 5:	str += ".raw";	m_CArtCam.SaveImage(str, FILETYPE.FILETYPE_RAW);		break;
				}
			}
		}

		// Recording
		private void menuRec_Click(object sender, System.EventArgs e)
		{
			saveFileDialog1.Filter = "AVIFile(*.avi)|*.avi||";
			saveFileDialog1.DefaultExt = "avi";

			if(DialogResult.OK == saveFileDialog1.ShowDialog())
			{
				m_RecName = saveFileDialog1.FileName;

				// Pause
				m_CArtCam.Close();

				// Display on different window while recording
				// When "hWnd" is NULL, window is created from SDK side and therefore the size is not important.
				m_CArtCam.SetPreviewWindow(IntPtr.Zero, 0, 0, 0, 0);

				// 5 seconds recording
				m_CArtCam.Record(m_RecName, 5000, 1);


				// Timing for record ending is not sent from SDK and therefore it needs to be stopped by software.
				// Just in case, run the timer for 1 sencond longer.
				timerRec.Interval = 6000;
				timerRec.Enabled = true;
			}
		}

		// Recording timer
		private void timerRec_Tick(object sender, System.EventArgs e)
		{
			timerRec.Enabled = false;
			m_CArtCam.Close();

			if(DialogResult.Yes == MessageBox.Show("Recording complete. /n Play file?", "Complete", MessageBoxButtons.YesNo))
			{
				System.Diagnostics.Process.Start(m_RecName);
			}			
		}

		// End
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// Preview Draw automatically
		private void menuPreview_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = false;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Set window to be displayed
			// When setting NULL to hWnd,it is possible to create new window and show it.
			m_CArtCam.SetPreviewWindow(this.Handle, 0, 0, this.Width, this.Height);

			m_CArtCam.Preview();

			// Check menu
			menuPreview.Checked  = true;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 0;
			m_SaveFlg = true;
			m_StopFlg = false;
			menuStop.Text = "Pause";

			ImageBox.Invalidate();
		}

		// Callback: Obtain image pointer of image and draw its own.
		private void menuCallback_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// If drawing by yourself, set all window size to 0.
			// An automatic display can be performed, if window size is set up even when using CallBackPreview
			m_CArtCam.SetPreviewWindow(Handle, 0, 0, 0, 0);

			// Creat area for capturing
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			// Capture image
			m_CArtCam.CallBackPreview(Handle, m_pCapture, getSize(), 1);

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = true;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 1;
			m_StopFlg = false;
			menuStop.Text = "Pause";

			ImageBox.Invalidate();
		}

		// Snapshot
		private void menuSnapshot_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Creat area for capturing
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			// Capture image
			m_CArtCam.SnapShot(m_pCapture, getSize(), 1);


			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 2;
			m_SaveFlg = true;
			m_StopFlg = false;
			menuStop.Text = "Pause";

			timer1.Enabled = true;
			timer1.Interval = 100;

			ImageBox.Invalidate();
		}

		// Capture
		private void menuCapture_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Creat area for capturing
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			// Display image
			m_CArtCam.Capture();

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = true;
			menuTrigger.Checked  = false;

			m_PreviewMode = 3;
			m_StopFlg = false;
			menuStop.Text = "Pause";

			ImageBox.Invalidate();

			timer1.Enabled = true;
			timer1.Interval = 200;
		}

		// Capture timer
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(m_PreviewMode == 3)
			{
			m_CArtCam.SnapShot(m_pCapture, getSize(), 1);
			m_SaveFlg = true;
			}
			ImageBox.Invalidate();
		}

		// Trigger
		private void menuTrigger_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// If drawing by yourself, set all window size to 0.
			// An automatic display can be performed, if window size is set up even when using CallBackPreview
			m_CArtCam.SetPreviewWindow(this.Handle, 0, 0, 0, 0);

			// Create area for capturing
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			// Capture image
			m_CArtCam.Trigger(this.Handle, m_pCapture, getSize(), 1);

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = true;

			m_PreviewMode = 4;
			m_StopFlg = false;
			menuStop.Text = "Pause";

			ImageBox.Invalidate();
		}

		// Pause/Resume
		private void menuStop_Click(object sender, System.EventArgs e)
		{
			// Stop only for animated picture
			if(0 == m_PreviewMode || 1 == m_PreviewMode)
			{
				if(m_StopFlg)
				{
					m_CArtCam.StartPreview();
					m_StopFlg = false;

					menuStop.Text = "Pause";
				}
				else 
				{
					m_CArtCam.StopPreview();
					m_StopFlg = true;

					menuStop.Text = "Resume";
				}
			}
		}

		// Create bit-map
		private void CreateBitmap()
		{
			// In case bitmap is already created, release.
			if(null != m_Bitmap)
			{
				m_Bitmap.Dispose();
			}

			switch(getColorMode())
			{
				case 8:
				case 16:
					m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format8bppIndexed);

					// Pallet modification
					ColorPalette pal = m_Bitmap.Palette;
					Color[] cpe = m_Bitmap.Palette.Entries;

					for(int i=0; i<256; i++)
					{
						cpe.SetValue(Color.FromArgb(i, i, i), i);
						pal.Entries[i] = cpe[i];
					}
					m_Bitmap.Palette = pal;
					break;

				case 24:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 32:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 48:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 64:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
			}

			// Arrangement for capture
			m_pCapture = new Byte[getSize()];
		}


		// Camera settings
		private void menuCamera_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			if(0 != m_CArtCam.SetCameraDlg(this.Handle))
			{
				switch(m_PreviewMode)
				{
					case 0: menuPreview_Click(sender, e); break;
					case 1: menuCallback_Click(sender, e); break;
					case 3: menuCapture_Click(sender, e); break;
					case 4: menuTrigger_Click(sender, e); break;
				}
			}
		}

		// Filter settings
		private void menuFilter_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			m_CArtCam.SetImageDlg(this.Handle);
		}

		// Analog settings
		private void menuAnalog_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			m_CArtCam.SetAnalogDlg(this.Handle);
		}

		private void OnDllReload(object sender, System.EventArgs e)
		{
			for (int i=0; i<m_DllCount; i++){
				menuDLL.MenuItems.RemoveAt(1);
			}
			m_DllCount = 0;
			m_DllSata  = -1;

			String szDirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			String[] files = Directory.GetFiles(szDirPath, "Art*.dll");
			foreach (String szFileName in files)
			{
				CArtCam ArtCam = new CArtCam();
				if (ArtCam.LoadLibrary(szFileName)){

					long ver = ArtCam.GetDllVersion() & 0xFFFF;
					String szMenu = String.Format("{0}\tVersion {1:D4}", Path.GetFileNameWithoutExtension(szFileName), ver);

					m_DllCount++;
					if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA == (ARTCAM_CAMERATYPE)(ArtCam.GetDllVersion() >> 16)){
						
						MenuItem menuSata = new MenuItem();
						menuSata.Text = szMenu;
						String[] CameraName = {
											"LVDS",
											"300MI",
											"500MI",
											"MV413",
											"800MI",
											"036MI",
											"150P3",
											"267KY",
											"274KY",
											"625KY",
											"130MI",
											"200MI",
										};
						for(int i=0; i<CameraName.Length; i++){
							MenuItem mi = new MenuItem();
							mi.Text = CameraName[i];
							mi.Click += new System.EventHandler(OnMenuDLLSelect);
							menuSata.MenuItems.Add(i, mi);
						}
						menuDLL.MenuItems.Add(m_DllCount, menuSata);
						m_DllSata = m_DllCount-1;
					}else{
						MenuItem mi = new MenuItem();
						mi.Text = szMenu;
						mi.Click += new System.EventHandler(OnMenuDLLSelect);
						menuDLL.MenuItems.Add(m_DllCount, mi);
					}
				}
			}
		}

		private void OnMenuDLLSelect(object sender, System.EventArgs e)
		{
			int id = menuDLL.MenuItems.IndexOf((MenuItem)sender);
			if (id > -1){
				OnDllChange(sender, e, id-1, -1);
			}else{
				int type = ((MenuItem)sender).Index;
				if((int)ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_LVDS <= type && type <= (int)ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_200MI){
					OnDllChange(sender, e, m_DllSata, type);
				}
			}
		}
		private void DeviceChange(object sender, System.EventArgs e, int Number)
		{
			if(m_CArtCam.IsInit())
			{
				m_CArtCam.Close();
			}

			// To confirm whether the device is connected, use "GetDeviceName"
			// It can be found out easily with "GetDeviceName".
			// When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
			StringBuilder Temp = new StringBuilder( 256 );
			if(0 == m_CArtCam.GetDeviceName(Number, Temp, 256))
			{
				m_PreviewMode = -1;
				m_SelectDevice = -1;
				m_StopFlg = false;
				menuStop.Text = "Pause";
				return;
			}


			// A device will be changed, if a camera is displayed after changing the number of a device now
			// Notes: A device is not changed in this function simple substance
			//   After calling this function, a device is changed by initializing a device
			m_SelectDevice = Number;
			m_CArtCam.SetDeviceNumber(Number);


			for(int i=0; i<8; i++)
			{
				menuDevice.MenuItems[i].Checked = false;
			}
			menuDevice.MenuItems[Number].Checked = true;


			switch(m_PreviewMode)
			{
				case 0:	menuPreview_Click(sender, e); break;
				case 1:	menuCallback_Click(sender, e); break;
				case 3:	menuCapture_Click(sender, e); break;
				case 4:	menuTrigger_Click(sender, e); break;
			}
		}

		private void menuDevice0_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 0); }
		private void menuDevice1_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 1); }
		private void menuDevice2_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 2); }
		private void menuDevice3_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 3); }
		private void menuDevice4_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 4); }
		private void menuDevice5_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 5); }
		private void menuDevice6_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 6); }
		private void menuDevice7_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 7); }
		private void menuDevice8_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 8); }
		private void menuDevice9_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 9); }

		private int getSize()
		{
			return ((getWidth() * (getColorMode() / 8) + 3) & ~3) * getHeight();
		}

		private int getWidth()
		{
			int[] Size = { 1, 2, 4, 8 };
			return m_CArtCam.Width() / Size[(int)(getSubSample())];
		}

		private int getHeight()
		{
			int[] Size = { 1, 2, 4, 8 };
			return m_CArtCam.Height() / Size[(int)getSubSample()];
		}

		private int getColorMode()
		{
			return ((m_CArtCam.GetColorMode() + 7) & ~7);
		}

		private int getSubSample()
		{
			return ((int)m_CArtCam.GetSubSample() & 0x03);
		}

		private BitmapData LockBitmap()
		{
			switch(getColorMode())
			{
				case 8:
				case 16:
					return m_Bitmap.LockBits(new Rectangle(0,0,getWidth(),getHeight()), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

				case 24:
				case 32:
				case 48:
				case 64:
					return m_Bitmap.LockBits(new Rectangle(0,0,getWidth(),getHeight()), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			}

			return null;
		}

		private void DrawImage(Graphics g)
		{
			if(null == m_Bitmap)
			{
				return ;
			}


			BitmapData pBitmapData = LockBitmap();
			if(null == pBitmapData)
			{
				return ;
			}


			unsafe
			{
				byte* pdest = (byte*)pBitmapData.Scan0.ToPointer();

				// In case of 16 bit transfer,convert to 8 bit and display
				if(getColorMode() == 16)
				{
					int size = getWidth() * getHeight();
					switch(m_CArtCam.GetColorMode())
					{
						case 10: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 6) | (m_pCapture[i*2] >> 2));	break;
						case 12: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 4) | (m_pCapture[i*2] >> 4));	break;
						case 14: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 2) | (m_pCapture[i*2] >> 6));	break;
						case 16: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 0) | (m_pCapture[i*2] >> 8));	break;
					}
				}
				else if(getColorMode() == 32)
				{
					int size = getWidth() * getHeight();
					for(int i=0; i<size; i++)
					{
						pdest[i*3]   = m_pCapture[i*4];
						pdest[i*3+1] = m_pCapture[i*4+1];
						pdest[i*3+2] = m_pCapture[i*4+2];
					}
				}
					// This is a heavy load. When using 16 (10) bit color, use C language.
				else if(getColorMode() == 48 || getColorMode() == 64)
				{
					int bpp = getColorMode() / 8;
					int size = getWidth() * getHeight();
					switch(m_CArtCam.GetColorMode())
					{
						case 42: case 58:
					for(int i=0; i<size; i++)
					{
						pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 6) | (m_pCapture[i*bpp]   >> 2));
						pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 6) | (m_pCapture[i*bpp+2] >> 2));
						pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 6) | (m_pCapture[i*bpp+4] >> 2));
					}
							break;
						case 44: case 60:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 4) | (m_pCapture[i*bpp]   >> 4));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 4) | (m_pCapture[i*bpp+2] >> 4));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 4) | (m_pCapture[i*bpp+4] >> 4));
							}
							break;
						case 46: case 62:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 2) | (m_pCapture[i*bpp]   >> 6));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 2) | (m_pCapture[i*bpp+2] >> 6));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 2) | (m_pCapture[i*bpp+4] >> 6));
				}
							break;
						case 48: case 64:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 0) | (m_pCapture[i*bpp]   >> 8));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 0) | (m_pCapture[i*bpp+2] >> 8));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 0) | (m_pCapture[i*bpp+4] >> 8));
							}
							break;
					}
				}
				else
				{
					int size = getSize();
					for(int i=0; i<size; i++)
					{
						pdest[i] = m_pCapture[i];
					}
				}
			}

			m_Bitmap.UnlockBits(pBitmapData);


			// Image display
			int iWidth = m_Bitmap.Width;
			int iHeight= m_Bitmap.Height;
			g.DrawImage(m_Bitmap, new Rectangle(0, 0, getWidth() * m_ViewScale / 100, getHeight() * m_ViewScale / 100));

			// Line drawing
			Point MousePos = this.PointToClient(Cursor.Position);
			if( (MousePos.X < 0) || (MousePos.Y < 0) || (MousePos.X >= iWidth) || (MousePos.Y >= iHeight)) return;

			Pen pen = new Pen(Color.Red, 1);
			Point Pos = new Point(MousePos.X - ImagePanel.AutoScrollPosition.X, MousePos.Y - ImagePanel.AutoScrollPosition.Y);
			g.DrawLine(pen, Pos.X, 0, Pos.X, getHeight() * m_ViewScale / 100);
			g.DrawLine(pen, 0, Pos.Y, getWidth() * m_ViewScale / 100, Pos.Y);


			if (1300 <= (m_CArtCam.GetDllVersion() & 0xFFFF))
			{
				int Exposure = m_CArtCam.GetRealExposureTime();	// (micro sec)
				float fExposure = (float)Exposure / 1000.0f;
				sbPanelExp.Text = "Exp: " + fExposure.ToString() + "msec";
			}
			else
			{
				sbPanelExp.Text = "";
			}
		}

		private void ImageBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
				{
			DrawImage(e.Graphics);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
										{
			ImagePanel.SetBounds(0,0,this.ClientRectangle.Right,this.ClientRectangle.Bottom - 16);
			statusBar1.SetBounds(0,this.ClientRectangle.Bottom - 16, this.ClientRectangle.Right, 16);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			m_CArtCam.Close();
			timer1.Enabled = false;


			Form modalDialog = new Form2(m_CArtCam);
			DialogResult result = modalDialog.ShowDialog();

			switch(m_PreviewMode)
			{
				case 0: menuPreview_Click(sender, e); break;
				case 1: menuCallback_Click(sender, e); break;
				case 3: menuCapture_Click(sender, e); break;
				case 4: menuTrigger_Click(sender, e); break;
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Form modalDialog = new Form3(m_CArtCam, m_PreviewMode);
			DialogResult result = modalDialog.ShowDialog();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Form modalDialog = new Form4(m_CArtCam);
			DialogResult result = modalDialog.ShowDialog();
		}




		private void menuFile_Popup(object sender, System.EventArgs e)
		{
			// Check if saving is available (if an image has been captured at least once, it is possible).
			if(m_SaveFlg)
			{
				menuSave.Enabled = true;
			} 
			else 
			{
				menuSave.Enabled = false;
			}

			// Check is the camera is Directshow compatible
			// Only Directshow camera has recording function
			if (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS == m_CurrentCameraType)
			{
				menuRec.Enabled = true;
			} 
			else 
			{
				menuRec.Enabled = false;
			}
		}

		private void menuView_Popup(object sender, System.EventArgs e)
		{
			// Disable playback if device is not connected
			if(-1 == m_SelectDevice)
			{
				menuPreview.Enabled = false;
				menuCallback.Enabled = false;
				menuSnapshot.Enabled = false;
				menuCapture.Enabled = false;
				menuTrigger.Enabled = false;
				menuStop.Enabled = false;
			}
			else 
			{
				menuPreview.Enabled = true;
				menuCallback.Enabled = true;
				menuSnapshot.Enabled = true;
				menuCapture.Enabled = true;
				menuStop.Enabled = false;

				// Remark: Trigger mode is not available in every model.
				switch (m_CurrentCameraType)
				{
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC:	
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:	
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098:	
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P:		
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USB3_500MI:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USB3_900MI:
					case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USB3_267KY:
						menuTrigger.Enabled = false;
						break;

					default:
						menuTrigger.Enabled = true;
						break;
				}
			}
		}

		private void menuSet_Popup(object sender, System.EventArgs e)
		{
			// Directshow is not available in every model.
			// Note that "SetAnalogDlg" is not available in many models.
			menuCamera.Enabled = true;
			menuFilter.Enabled = true;

			switch (m_CurrentCameraType)
			{
					//case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:		// DS
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC:		// UST
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:		// CNV
					menuAnalog.Enabled = false;
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2:
					menuItem7.Enabled = true;
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_008TNIR:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_031TNIR:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_0016TNIR:
					MenuUserCorrection.Enabled = true;
					break;


				default:
					menuAnalog.Enabled = true;
					//menuItem7.Enabled = false;
					MenuUserCorrection.Enabled = false;
					break;
			}
		}

		private void menuItem7_Click_1(object sender, System.EventArgs e)
		{
			Form modalDialog;
			switch(m_CurrentCameraType){
			case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT:
			case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT:	
				modalDialog = new Form5(m_CArtCam);	
				modalDialog.ShowDialog(); 
			break;
			case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2:
				modalDialog = new Form7(m_CArtCam);	
				modalDialog.ShowDialog();
			break;
			}
		}

		private void OnDllChange(object sender, System.EventArgs e, int DllType, int SataType)
		{
			Release();
			m_CArtCam.FreeLibrary();

			m_CurrentCameraType = 0;

			if (0 == m_DllCount) return;
			String stMenu = menuDLL.MenuItems[(int)DllType + 1].Text;
			String[] stArray = stMenu.Split('\t');
			String szDllName = String.Format("{0}.dll", stArray[0]);
			bool res = m_CArtCam.LoadLibrary(szDllName);
			if (!res){
				MessageBox.Show("DLL is not found.\nIt may have been relocated after executing.");
				return;
			}else{
				m_CurrentCameraType = (ARTCAM_CAMERATYPE)(m_CArtCam.GetDllVersion() >> 16);
			}
			// Initialize is to be called first
			// By setting Window Handle here, WM_ERROR can be obtained
			if (!m_CArtCam.Initialize(this.Handle)){
				MessageBox.Show("Failed to initialize SDK");
				return;
			}
			m_DllType = DllType;
			m_SataType = SataType;

			// Check menu
			for (int i = 0; i < m_DllCount; i++){
				menuDLL.MenuItems[(int)i + 1].Checked = false;
			}
			// Select SATA camera type when use Sata.dll
			if(-1 != SataType && ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA == m_CurrentCameraType){
				m_CArtCam.SetCameraType(SataType);
				m_CArtCam.SetDeviceNumber(0);
			}else{
				menuDLL.MenuItems[(int)DllType+1].Checked = true;
			}


			// Device modification menu
			for(int i=0; i<8; i++)
			{
				StringBuilder Temp = new StringBuilder( 256 );
				if(0 != m_CArtCam.GetDeviceName(i, Temp, 256))
				{
					menuDevice.MenuItems[i].Text = Temp.ToString();
					menuDevice.MenuItems[i].Enabled = true;
	}
				else
				{
					menuDevice.MenuItems[i].Enabled = false;
				}
}

			DeviceChange(sender, e, 0);

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());
		}

		private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			if(e.StatusBarPanel == sbPanelScale)
			{
				if(e.Button.Equals(System.Windows.Forms.MouseButtons.Left))
				{
					switch(m_ViewScale)
					{
						case  25:	m_ViewScale =  50;	break;
						case  50:	m_ViewScale = 100;	break;
						case 100:	m_ViewScale = 150;	break;
						case 150:	m_ViewScale = 200;	break;
						case 200:	m_ViewScale = 400;	break;
						default :	m_ViewScale = 400;	break;
					}
				}
				else
				{
					switch(m_ViewScale)
					{
						case  50:	m_ViewScale =  25;	break;
						case 100:	m_ViewScale =  50;	break;
						case 150:	m_ViewScale = 100;	break;
						case 200:	m_ViewScale = 150;	break;
						case 400:	m_ViewScale = 200;	break;
						default :	m_ViewScale =  25;	break;
					}
				}
			}
			ImagePanel.AutoScrollPosition = new Point(0, 0);
			ImageBox.SetBounds(0, 0, getWidth() * m_ViewScale / 100, getHeight() * m_ViewScale / 100, BoundsSpecified.All);
			sbPanelScale.Text = m_ViewScale.ToString() + "%";
		}

		private void MenuUserCorrection_Click(object sender, EventArgs e)
		{
			Form modalDialog = new Form6(m_CArtCam);
			DialogResult result = modalDialog.ShowDialog();
		}

		private void menuSet_Click(object sender, EventArgs e)
		{

		}

		// End of original Artray Form1

		// Objective: Clicking on 'Image Sequence' in the Action menu opens a new Window which allows
		// the Camera, Filter and Analog Settings variable values to be passed to Form8, where the
		// user can add initial exposure time, number of exposure sets etc. and then run acquisition of images.
		// For the time being, develop this task in Form1

		private void menuSequence_Click(object sender, EventArgs e)
		{
			/*
			// Plan to move this access modifier to Form8
			Form8 sfm36Form = new Form8();
			sfm36Form.ShowDialog();
			*/

			// ********************************************************
			// The variables that the user needs to change
			// ********************************************************
			// string prefix = DateTime.Now.ToString("yyyyMMddHHmmss");
			string prefix = "ArtCam990_grey_LED770_zero-gain";          
			int startExposure = 10; // t in microseconds?
			// int endExposure = 2000;
			int exposureStep = 10;     // T in microseconds?
			int numberPerSet = 2;     // n
			int totalSets = 10;       // N
			int currentExposure = startExposure;
			// ********************************************************

			// Ok, lets loop over some stuff
			// int totalSteps = (int)Math.Ceiling(((double)(endExposure - startExposure)) / exposureStep + 1);

			//Acquire and save image sequence
			for (int step = 0; step < totalSets; step++)
			{				
				m_CArtCam.SetExposureTime(currentExposure);

				for (int i = 0; i < numberPerSet; i++)
				{
					// Acquire image
					Console.WriteLine("Acquiring image at exposure time = {0}...", currentExposure);
					menuSnapshot_Click(sender, e);

					// Set up destination folder  and filename for image
					// Example filname: ArtCam990_grey_LED770_zero-gain_Exp0003000us__005.tif
					string location =	string.Format
										("{0}/{1}_Exp{2,7}us__{3,3}.tif", 
										Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), 
										prefix,
										currentExposure.ToString("D7"),
										(numberPerSet * step + i + 1).ToString("D3"));

					// Wait three seconds (used for debug)
					//System.Threading.Thread.Sleep(3000);

					// Save image
					Console.WriteLine("Saving image to \"{0}\"...", location);
					if (m_CArtCam.SaveImage(location, FILETYPE.FILETYPE_TIFF) <= 0)
					{
						Console.WriteLine("Failed to save image, returning");
						return;
					}
				}

				// increment exposure time in outer loop
				currentExposure += exposureStep;
			}

		}

	}
}



