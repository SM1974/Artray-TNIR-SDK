
namespace Sample_CS
{
    partial class Form8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConsoleBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_numSets_N = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_exp_t = new System.Windows.Forms.TextBox();
            this.text_int_T = new System.Windows.Forms.TextBox();
            this.text_perSet_n = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveImageFolder = new System.Windows.Forms.TextBox();
            this.baseFilename = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Location = new System.Drawing.Point(12, 219);
            this.ConsoleBox.Multiline = true;
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.Size = new System.Drawing.Size(608, 219);
            this.ConsoleBox.TabIndex = 1;
            this.ConsoleBox.Text = "Echo Console Window here";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_numSets_N);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.text_exp_t);
            this.groupBox1.Controls.Add(this.text_int_T);
            this.groupBox1.Controls.Add(this.text_perSet_n);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sequence Set-up";
            // 
            // text_numSets_N
            // 
            this.text_numSets_N.Location = new System.Drawing.Point(404, 68);
            this.text_numSets_N.Name = "text_numSets_N";
            this.text_numSets_N.Size = new System.Drawing.Size(72, 20);
            this.text_numSets_N.TabIndex = 12;
            this.text_numSets_N.Text = "5";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(282, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number of sets, N";
            // 
            // text_exp_t
            // 
            this.text_exp_t.Location = new System.Drawing.Point(159, 33);
            this.text_exp_t.Name = "text_exp_t";
            this.text_exp_t.Size = new System.Drawing.Size(72, 20);
            this.text_exp_t.TabIndex = 10;
            this.text_exp_t.Text = "2000";
            // 
            // text_int_T
            // 
            this.text_int_T.Location = new System.Drawing.Point(159, 68);
            this.text_int_T.Name = "text_int_T";
            this.text_int_T.Size = new System.Drawing.Size(72, 20);
            this.text_int_T.TabIndex = 9;
            this.text_int_T.Text = "2000";
            // 
            // text_perSet_n
            // 
            this.text_perSet_n.Location = new System.Drawing.Point(404, 32);
            this.text_perSet_n.Name = "text_perSet_n";
            this.text_perSet_n.Size = new System.Drawing.Size(72, 20);
            this.text_perSet_n.TabIndex = 8;
            this.text_perSet_n.Text = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(282, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Images per set, n";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time interval, T (μs)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First exposure time, t (μs)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(527, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(527, 80);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Image folder";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Base filename";
            // 
            // saveImageFolder
            // 
            this.saveImageFolder.Location = new System.Drawing.Point(110, 139);
            this.saveImageFolder.Name = "saveImageFolder";
            this.saveImageFolder.Size = new System.Drawing.Size(378, 20);
            this.saveImageFolder.TabIndex = 13;
            this.saveImageFolder.Text = "C:\\Users\\sfm36\\Documents\\Artray\\EMVA_1288\\Images\\LED770";
            // 
            // baseFilename
            // 
            this.baseFilename.Location = new System.Drawing.Point(110, 172);
            this.baseFilename.Name = "baseFilename";
            this.baseFilename.Size = new System.Drawing.Size(378, 20);
            this.baseFilename.TabIndex = 14;
            this.baseFilename.Text = "ArtCam990_grey_LED770_zero-gain";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(527, 136);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 25);
            this.btn_Browse.TabIndex = 15;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // Form8
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(629, 450);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.baseFilename);
            this.Controls.Add(this.saveImageFolder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConsoleBox);
            this.Name = "Form8";
            this.Text = "Form8";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ConsoleBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_exp_t;
        private System.Windows.Forms.TextBox text_int_T;
        private System.Windows.Forms.TextBox text_perSet_n;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_numSets_N;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox saveImageFolder;
        private System.Windows.Forms.TextBox baseFilename;
        private System.Windows.Forms.Button btn_Browse;
    }
}