
namespace MAS7.Forms
{
    partial class Settings
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
            this.folderBroswer = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grbxAppSettings = new System.Windows.Forms.GroupBox();
            this.ckbxCloseTray = new System.Windows.Forms.CheckBox();
            this.ckbxMinimizeTray = new System.Windows.Forms.CheckBox();
            this.ckbxCommandLine = new System.Windows.Forms.CheckBox();
            this.ckbxIntelExclusive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePath = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.lnkDonate = new System.Windows.Forms.LinkLabel();
            this.grbxAppSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBroswer
            // 
            this.folderBroswer.Description = "Please select the Intel/Solidigm Memory and Storage Tool installation folder.";
            this.folderBroswer.RootFolder = System.Environment.SpecialFolder.ProgramFiles;
            this.folderBroswer.SelectedPath = "C:\\Program Files";
            this.folderBroswer.ShowNewFolderButton = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(308, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelSettings);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(227, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.SaveSettings);
            // 
            // grbxAppSettings
            // 
            this.grbxAppSettings.Controls.Add(this.lnkDonate);
            this.grbxAppSettings.Controls.Add(this.ckbxCloseTray);
            this.grbxAppSettings.Controls.Add(this.ckbxMinimizeTray);
            this.grbxAppSettings.Controls.Add(this.ckbxCommandLine);
            this.grbxAppSettings.Controls.Add(this.ckbxIntelExclusive);
            this.grbxAppSettings.Location = new System.Drawing.Point(12, 102);
            this.grbxAppSettings.Name = "grbxAppSettings";
            this.grbxAppSettings.Size = new System.Drawing.Size(371, 135);
            this.grbxAppSettings.TabIndex = 12;
            this.grbxAppSettings.TabStop = false;
            this.grbxAppSettings.Text = "Application Settings";
            // 
            // ckbxCloseTray
            // 
            this.ckbxCloseTray.AutoSize = true;
            this.ckbxCloseTray.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbxCloseTray.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ckbxCloseTray.Location = new System.Drawing.Point(6, 100);
            this.ckbxCloseTray.Name = "ckbxCloseTray";
            this.ckbxCloseTray.Size = new System.Drawing.Size(130, 20);
            this.ckbxCloseTray.TabIndex = 15;
            this.ckbxCloseTray.Text = "Close on Task Bar.";
            this.ckbxCloseTray.UseVisualStyleBackColor = true;
            // 
            // ckbxMinimizeTray
            // 
            this.ckbxMinimizeTray.AutoSize = true;
            this.ckbxMinimizeTray.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbxMinimizeTray.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ckbxMinimizeTray.Location = new System.Drawing.Point(6, 74);
            this.ckbxMinimizeTray.Name = "ckbxMinimizeTray";
            this.ckbxMinimizeTray.Size = new System.Drawing.Size(151, 20);
            this.ckbxMinimizeTray.TabIndex = 14;
            this.ckbxMinimizeTray.Text = "Minimize on Task Bar.";
            this.ckbxMinimizeTray.UseVisualStyleBackColor = true;
            // 
            // ckbxCommandLine
            // 
            this.ckbxCommandLine.AutoSize = true;
            this.ckbxCommandLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbxCommandLine.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ckbxCommandLine.Location = new System.Drawing.Point(6, 48);
            this.ckbxCommandLine.Name = "ckbxCommandLine";
            this.ckbxCommandLine.Size = new System.Drawing.Size(273, 20);
            this.ckbxCommandLine.TabIndex = 13;
            this.ckbxCommandLine.Text = "Show command line for Intel MAS functions.";
            this.ckbxCommandLine.UseVisualStyleBackColor = true;
            // 
            // ckbxIntelExclusive
            // 
            this.ckbxIntelExclusive.AutoSize = true;
            this.ckbxIntelExclusive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbxIntelExclusive.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ckbxIntelExclusive.Location = new System.Drawing.Point(6, 22);
            this.ckbxIntelExclusive.Name = "ckbxIntelExclusive";
            this.ckbxIntelExclusive.Size = new System.Drawing.Size(260, 20);
            this.ckbxIntelExclusive.TabIndex = 12;
            this.ckbxIntelExclusive.Text = "Hide drives from different manufacturers.";
            this.ckbxIntelExclusive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePath);
            this.groupBox1.Controls.Add(this.txbPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 84);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intel/ Solidigm Storage Tool Installation path";
            // 
            // btnChangePath
            // 
            this.btnChangePath.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnChangePath.Location = new System.Drawing.Point(6, 51);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Size = new System.Drawing.Size(75, 23);
            this.btnChangePath.TabIndex = 15;
            this.btnChangePath.Text = "Change";
            this.btnChangePath.UseVisualStyleBackColor = true;
            this.btnChangePath.Click += new System.EventHandler(this.ChangePath);
            // 
            // txbPath
            // 
            this.txbPath.BackColor = System.Drawing.SystemColors.Window;
            this.txbPath.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txbPath.Location = new System.Drawing.Point(6, 22);
            this.txbPath.Name = "txbPath";
            this.txbPath.ReadOnly = true;
            this.txbPath.Size = new System.Drawing.Size(359, 23);
            this.txbPath.TabIndex = 14;
            this.txbPath.Text = "C:\\Program Files\\";
            // 
            // lnkDonate
            // 
            this.lnkDonate.AutoSize = true;
            this.lnkDonate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDonate.Location = new System.Drawing.Point(319, 117);
            this.lnkDonate.Name = "lnkDonate";
            this.lnkDonate.Size = new System.Drawing.Size(46, 15);
            this.lnkDonate.TabIndex = 16;
            this.lnkDonate.TabStop = true;
            this.lnkDonate.Text = "Donate";
            this.lnkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Donate);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 276);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbxAppSettings);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsClosing);
            this.Load += new System.EventHandler(this.SettingsLoad);
            this.grbxAppSettings.ResumeLayout(false);
            this.grbxAppSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBroswer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grbxAppSettings;
        private System.Windows.Forms.CheckBox ckbxCloseTray;
        private System.Windows.Forms.CheckBox ckbxMinimizeTray;
        private System.Windows.Forms.CheckBox ckbxCommandLine;
        private System.Windows.Forms.CheckBox ckbxIntelExclusive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangePath;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.LinkLabel lnkDonate;
    }
}