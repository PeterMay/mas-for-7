
namespace MAS7.Forms
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cmbxDrive = new System.Windows.Forms.ComboBox();
            this.cxmsDrives = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cxmsiCopyValue = new System.Windows.Forms.ToolStripMenuItem();
            this.cxmsiRefreshDrives = new System.Windows.Forms.ToolStripMenuItem();
            this.cxmsDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDrive = new System.Windows.Forms.Label();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpgDetails = new System.Windows.Forms.TabPage();
            this.grbxDetails = new System.Windows.Forms.GroupBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFirmwareVer = new System.Windows.Forms.Label();
            this.lblMediaType = new System.Windows.Forms.Label();
            this.lblInterfaceType = new System.Windows.Forms.Label();
            this.lblPartitions = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblDriveIndex = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbpgSensor = new System.Windows.Forms.TabPage();
            this.dgvSensor = new System.Windows.Forms.DataGridView();
            this.dgvcProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpgSMART = new System.Windows.Forms.TabPage();
            this.dgvSMART = new System.Windows.Forms.DataGridView();
            this.dgvcAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNormalized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRaw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcWorst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpgOptimize = new System.Windows.Forms.TabPage();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.lblOptimizationProg = new System.Windows.Forms.Label();
            this.lblOptimization = new System.Windows.Forms.Label();
            this.pbrOptimize = new System.Windows.Forms.ProgressBar();
            this.tbpgDiagnostic = new System.Windows.Forms.TabPage();
            this.btnFullDiagnostic = new System.Windows.Forms.Button();
            this.btnQuickDiagnostic = new System.Windows.Forms.Button();
            this.pbrDiagnstoic = new System.Windows.Forms.ProgressBar();
            this.lblDiagnostic = new System.Windows.Forms.Label();
            this.tbpgUpdate = new System.Windows.Forms.TabPage();
            this.rtbxFirmware = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.ntfiTaskbar = new System.Windows.Forms.NotifyIcon(this.components);
            this.cxmsTaskbar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cxmsiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cxmsiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cxmsDrives.SuspendLayout();
            this.cxmsDetails.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpgDetails.SuspendLayout();
            this.grbxDetails.SuspendLayout();
            this.tbpgSensor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensor)).BeginInit();
            this.tbpgSMART.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMART)).BeginInit();
            this.tbpgOptimize.SuspendLayout();
            this.tbpgDiagnostic.SuspendLayout();
            this.tbpgUpdate.SuspendLayout();
            this.cxmsTaskbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxDrive
            // 
            this.cmbxDrive.ContextMenuStrip = this.cxmsDrives;
            this.cmbxDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDrive.Enabled = false;
            this.cmbxDrive.FormattingEnabled = true;
            this.cmbxDrive.Location = new System.Drawing.Point(105, 8);
            this.cmbxDrive.Name = "cmbxDrive";
            this.cmbxDrive.Size = new System.Drawing.Size(325, 23);
            this.cmbxDrive.TabIndex = 2;
            this.cmbxDrive.SelectedIndexChanged += new System.EventHandler(this.SelectDrive);
            // 
            // cxmsDrives
            // 
            this.cxmsDrives.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxmsiCopyValue,
            this.cxmsiRefreshDrives});
            this.cxmsDrives.Name = "Main_ContextMenuStrip_ComboBox";
            this.cxmsDrives.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cxmsDrives.Size = new System.Drawing.Size(135, 48);
            // 
            // cxmsiCopyValue
            // 
            this.cxmsiCopyValue.Name = "cxmsiCopyValue";
            this.cxmsiCopyValue.Size = new System.Drawing.Size(134, 22);
            this.cxmsiCopyValue.Text = "Copy Value";
            this.cxmsiCopyValue.Click += new System.EventHandler(this.CopyObjectText);
            // 
            // cxmsiRefreshDrives
            // 
            this.cxmsiRefreshDrives.Name = "cxmsiRefreshDrives";
            this.cxmsiRefreshDrives.Size = new System.Drawing.Size(134, 22);
            this.cxmsiRefreshDrives.Text = "Refresh";
            // 
            // cxmsDetails
            // 
            this.cxmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiCopy});
            this.cxmsDetails.Name = "Main_ContextMenuStrip_Label";
            this.cxmsDetails.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cxmsDetails.Size = new System.Drawing.Size(103, 26);
            // 
            // tsiCopy
            // 
            this.tsiCopy.Name = "tsiCopy";
            this.tsiCopy.Size = new System.Drawing.Size(102, 22);
            this.tsiCopy.Text = "Copy";
            this.tsiCopy.Click += new System.EventHandler(this.CopyObjectText);
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDrive.Location = new System.Drawing.Point(15, 10);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(71, 15);
            this.lblDrive.TabIndex = 3;
            this.lblDrive.Text = "Select Drive";
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tbpgDetails);
            this.tbcMain.Controls.Add(this.tbpgSensor);
            this.tbcMain.Controls.Add(this.tbpgSMART);
            this.tbcMain.Controls.Add(this.tbpgOptimize);
            this.tbcMain.Controls.Add(this.tbpgDiagnostic);
            this.tbcMain.Controls.Add(this.tbpgUpdate);
            this.tbcMain.Location = new System.Drawing.Point(14, 39);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(800, 466);
            this.tbcMain.TabIndex = 4;
            // 
            // tbpgDetails
            // 
            this.tbpgDetails.Controls.Add(this.grbxDetails);
            this.tbpgDetails.Location = new System.Drawing.Point(4, 24);
            this.tbpgDetails.Name = "tbpgDetails";
            this.tbpgDetails.Size = new System.Drawing.Size(792, 438);
            this.tbpgDetails.TabIndex = 3;
            this.tbpgDetails.Text = "Details";
            this.tbpgDetails.UseVisualStyleBackColor = true;
            // 
            // grbxDetails
            // 
            this.grbxDetails.Controls.Add(this.lblSize);
            this.grbxDetails.Controls.Add(this.lblFirmwareVer);
            this.grbxDetails.Controls.Add(this.lblMediaType);
            this.grbxDetails.Controls.Add(this.lblInterfaceType);
            this.grbxDetails.Controls.Add(this.lblPartitions);
            this.grbxDetails.Controls.Add(this.lblModel);
            this.grbxDetails.Controls.Add(this.lblDriveIndex);
            this.grbxDetails.Controls.Add(this.lblSerialNumber);
            this.grbxDetails.Controls.Add(this.lblStatus);
            this.grbxDetails.Location = new System.Drawing.Point(15, 17);
            this.grbxDetails.Name = "grbxDetails";
            this.grbxDetails.Size = new System.Drawing.Size(761, 375);
            this.grbxDetails.TabIndex = 17;
            this.grbxDetails.TabStop = false;
            this.grbxDetails.Text = "Caption: ";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.ContextMenuStrip = this.cxmsDetails;
            this.lblSize.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblSize.Location = new System.Drawing.Point(442, 216);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(31, 15);
            this.lblSize.TabIndex = 25;
            this.lblSize.Text = "Size:";
            // 
            // lblFirmwareVer
            // 
            this.lblFirmwareVer.AutoSize = true;
            this.lblFirmwareVer.ContextMenuStrip = this.cxmsDetails;
            this.lblFirmwareVer.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblFirmwareVer.Location = new System.Drawing.Point(22, 43);
            this.lblFirmwareVer.Name = "lblFirmwareVer";
            this.lblFirmwareVer.Size = new System.Drawing.Size(112, 15);
            this.lblFirmwareVer.TabIndex = 17;
            this.lblFirmwareVer.Text = "Firmware Revision:";
            // 
            // lblMediaType
            // 
            this.lblMediaType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMediaType.AutoSize = true;
            this.lblMediaType.ContextMenuStrip = this.cxmsDetails;
            this.lblMediaType.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblMediaType.Location = new System.Drawing.Point(442, 101);
            this.lblMediaType.Name = "lblMediaType";
            this.lblMediaType.Size = new System.Drawing.Size(72, 15);
            this.lblMediaType.TabIndex = 24;
            this.lblMediaType.Text = "Media Type:";
            // 
            // lblInterfaceType
            // 
            this.lblInterfaceType.AutoSize = true;
            this.lblInterfaceType.ContextMenuStrip = this.cxmsDetails;
            this.lblInterfaceType.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblInterfaceType.Location = new System.Drawing.Point(22, 101);
            this.lblInterfaceType.Name = "lblInterfaceType";
            this.lblInterfaceType.Size = new System.Drawing.Size(86, 15);
            this.lblInterfaceType.TabIndex = 18;
            this.lblInterfaceType.Text = "Interface Type:";
            // 
            // lblPartitions
            // 
            this.lblPartitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPartitions.AutoSize = true;
            this.lblPartitions.ContextMenuStrip = this.cxmsDetails;
            this.lblPartitions.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblPartitions.Location = new System.Drawing.Point(442, 158);
            this.lblPartitions.Name = "lblPartitions";
            this.lblPartitions.Size = new System.Drawing.Size(63, 15);
            this.lblPartitions.TabIndex = 23;
            this.lblPartitions.Text = "Partitions:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.ContextMenuStrip = this.cxmsDetails;
            this.lblModel.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblModel.Location = new System.Drawing.Point(22, 158);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(45, 15);
            this.lblModel.TabIndex = 19;
            this.lblModel.Text = "Model:";
            // 
            // lblDriveIndex
            // 
            this.lblDriveIndex.AutoSize = true;
            this.lblDriveIndex.ContextMenuStrip = this.cxmsDetails;
            this.lblDriveIndex.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblDriveIndex.Location = new System.Drawing.Point(22, 332);
            this.lblDriveIndex.Name = "lblDriveIndex";
            this.lblDriveIndex.Size = new System.Drawing.Size(72, 15);
            this.lblDriveIndex.TabIndex = 22;
            this.lblDriveIndex.Text = "Drive Index:";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.ContextMenuStrip = this.cxmsDetails;
            this.lblSerialNumber.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblSerialNumber.Location = new System.Drawing.Point(22, 216);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(88, 15);
            this.lblSerialNumber.TabIndex = 20;
            this.lblSerialNumber.Text = "Serial Number:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ContextMenuStrip = this.cxmsDetails;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblStatus.Location = new System.Drawing.Point(22, 274);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 15);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status:";
            // 
            // tbpgSensor
            // 
            this.tbpgSensor.Controls.Add(this.dgvSensor);
            this.tbpgSensor.Location = new System.Drawing.Point(4, 24);
            this.tbpgSensor.Name = "tbpgSensor";
            this.tbpgSensor.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSensor.Size = new System.Drawing.Size(792, 438);
            this.tbpgSensor.TabIndex = 4;
            this.tbpgSensor.Text = "Sensor";
            this.tbpgSensor.UseVisualStyleBackColor = true;
            // 
            // dgvSensor
            // 
            this.dgvSensor.AllowUserToAddRows = false;
            this.dgvSensor.AllowUserToDeleteRows = false;
            this.dgvSensor.AllowUserToResizeColumns = false;
            this.dgvSensor.AllowUserToResizeRows = false;
            this.dgvSensor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSensor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSensor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcProperty,
            this.dgvcValue});
            this.dgvSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSensor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSensor.Location = new System.Drawing.Point(3, 3);
            this.dgvSensor.Name = "dgvSensor";
            this.dgvSensor.ReadOnly = true;
            this.dgvSensor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvSensor.Size = new System.Drawing.Size(786, 432);
            this.dgvSensor.TabIndex = 0;
            // 
            // dgvcProperty
            // 
            this.dgvcProperty.HeaderText = "Property";
            this.dgvcProperty.Name = "dgvcProperty";
            this.dgvcProperty.ReadOnly = true;
            this.dgvcProperty.Width = 79;
            // 
            // dgvcValue
            // 
            this.dgvcValue.HeaderText = "Value";
            this.dgvcValue.Name = "dgvcValue";
            this.dgvcValue.ReadOnly = true;
            this.dgvcValue.Width = 62;
            // 
            // tbpgSMART
            // 
            this.tbpgSMART.Controls.Add(this.dgvSMART);
            this.tbpgSMART.Location = new System.Drawing.Point(4, 24);
            this.tbpgSMART.Name = "tbpgSMART";
            this.tbpgSMART.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSMART.Size = new System.Drawing.Size(792, 438);
            this.tbpgSMART.TabIndex = 0;
            this.tbpgSMART.Text = "S.M.A.R.T.";
            this.tbpgSMART.UseVisualStyleBackColor = true;
            // 
            // dgvSMART
            // 
            this.dgvSMART.AllowUserToAddRows = false;
            this.dgvSMART.AllowUserToDeleteRows = false;
            this.dgvSMART.AllowUserToResizeColumns = false;
            this.dgvSMART.AllowUserToResizeRows = false;
            this.dgvSMART.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSMART.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSMART.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSMART.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSMART.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcAttribute,
            this.dgvcAction,
            this.dgvcDescription,
            this.dgvcID,
            this.dgvcNormalized,
            this.dgvcRaw,
            this.dgvcStatus,
            this.dgvcThreshold,
            this.dgvcWorst,
            this.dgvcCur,
            this.dgvcLow,
            this.dgvcHigh});
            this.dgvSMART.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSMART.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSMART.Location = new System.Drawing.Point(3, 3);
            this.dgvSMART.MultiSelect = false;
            this.dgvSMART.Name = "dgvSMART";
            this.dgvSMART.ReadOnly = true;
            this.dgvSMART.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvSMART.Size = new System.Drawing.Size(786, 432);
            this.dgvSMART.TabIndex = 0;
            // 
            // dgvcAttribute
            // 
            this.dgvcAttribute.HeaderText = "Attribute";
            this.dgvcAttribute.Name = "dgvcAttribute";
            this.dgvcAttribute.ReadOnly = true;
            this.dgvcAttribute.Width = 80;
            // 
            // dgvcAction
            // 
            this.dgvcAction.HeaderText = "Action";
            this.dgvcAction.Name = "dgvcAction";
            this.dgvcAction.ReadOnly = true;
            this.dgvcAction.Width = 66;
            // 
            // dgvcDescription
            // 
            this.dgvcDescription.HeaderText = "Description";
            this.dgvcDescription.Name = "dgvcDescription";
            this.dgvcDescription.ReadOnly = true;
            this.dgvcDescription.Width = 95;
            // 
            // dgvcID
            // 
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Width = 44;
            // 
            // dgvcNormalized
            // 
            this.dgvcNormalized.HeaderText = "Normalized";
            this.dgvcNormalized.Name = "dgvcNormalized";
            this.dgvcNormalized.ReadOnly = true;
            this.dgvcNormalized.Width = 95;
            // 
            // dgvcRaw
            // 
            this.dgvcRaw.HeaderText = "Raw";
            this.dgvcRaw.Name = "dgvcRaw";
            this.dgvcRaw.ReadOnly = true;
            this.dgvcRaw.Width = 55;
            // 
            // dgvcStatus
            // 
            this.dgvcStatus.HeaderText = "Status";
            this.dgvcStatus.Name = "dgvcStatus";
            this.dgvcStatus.ReadOnly = true;
            this.dgvcStatus.Width = 66;
            // 
            // dgvcThreshold
            // 
            this.dgvcThreshold.HeaderText = "Threshold";
            this.dgvcThreshold.Name = "dgvcThreshold";
            this.dgvcThreshold.ReadOnly = true;
            this.dgvcThreshold.Width = 87;
            // 
            // dgvcWorst
            // 
            this.dgvcWorst.HeaderText = "Worst";
            this.dgvcWorst.Name = "dgvcWorst";
            this.dgvcWorst.ReadOnly = true;
            this.dgvcWorst.Width = 65;
            // 
            // dgvcCur
            // 
            this.dgvcCur.HeaderText = "Current";
            this.dgvcCur.Name = "dgvcCur";
            this.dgvcCur.ReadOnly = true;
            this.dgvcCur.Width = 73;
            // 
            // dgvcLow
            // 
            this.dgvcLow.HeaderText = "Low";
            this.dgvcLow.Name = "dgvcLow";
            this.dgvcLow.ReadOnly = true;
            this.dgvcLow.Width = 53;
            // 
            // dgvcHigh
            // 
            this.dgvcHigh.HeaderText = "High";
            this.dgvcHigh.Name = "dgvcHigh";
            this.dgvcHigh.ReadOnly = true;
            this.dgvcHigh.Width = 57;
            // 
            // tbpgOptimize
            // 
            this.tbpgOptimize.Controls.Add(this.btnOptimize);
            this.tbpgOptimize.Controls.Add(this.lblOptimizationProg);
            this.tbpgOptimize.Controls.Add(this.lblOptimization);
            this.tbpgOptimize.Controls.Add(this.pbrOptimize);
            this.tbpgOptimize.Location = new System.Drawing.Point(4, 24);
            this.tbpgOptimize.Name = "tbpgOptimize";
            this.tbpgOptimize.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgOptimize.Size = new System.Drawing.Size(792, 438);
            this.tbpgOptimize.TabIndex = 1;
            this.tbpgOptimize.Text = "SSD Optimizer";
            this.tbpgOptimize.UseVisualStyleBackColor = true;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Enabled = false;
            this.btnOptimize.Location = new System.Drawing.Point(352, 347);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(87, 27);
            this.btnOptimize.TabIndex = 6;
            this.btnOptimize.Text = "Run";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.RunOptimization);
            // 
            // lblOptimizationProg
            // 
            this.lblOptimizationProg.AutoSize = true;
            this.lblOptimizationProg.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOptimizationProg.Location = new System.Drawing.Point(7, 283);
            this.lblOptimizationProg.Name = "lblOptimizationProg";
            this.lblOptimizationProg.Size = new System.Drawing.Size(23, 15);
            this.lblOptimizationProg.TabIndex = 5;
            this.lblOptimizationProg.Text = "0%";
            // 
            // lblOptimization
            // 
            this.lblOptimization.AutoSize = true;
            this.lblOptimization.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimization.Location = new System.Drawing.Point(7, 25);
            this.lblOptimization.Name = "lblOptimization";
            this.lblOptimization.Size = new System.Drawing.Size(369, 105);
            this.lblOptimization.TabIndex = 4;
            this.lblOptimization.Text = resources.GetString("lblOptimization.Text");
            // 
            // pbrOptimize
            // 
            this.pbrOptimize.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbrOptimize.Location = new System.Drawing.Point(10, 301);
            this.pbrOptimize.Name = "pbrOptimize";
            this.pbrOptimize.Size = new System.Drawing.Size(769, 27);
            this.pbrOptimize.TabIndex = 3;
            // 
            // tbpgDiagnostic
            // 
            this.tbpgDiagnostic.Controls.Add(this.btnFullDiagnostic);
            this.tbpgDiagnostic.Controls.Add(this.btnQuickDiagnostic);
            this.tbpgDiagnostic.Controls.Add(this.pbrDiagnstoic);
            this.tbpgDiagnostic.Controls.Add(this.lblDiagnostic);
            this.tbpgDiagnostic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbpgDiagnostic.Location = new System.Drawing.Point(4, 24);
            this.tbpgDiagnostic.Name = "tbpgDiagnostic";
            this.tbpgDiagnostic.Size = new System.Drawing.Size(792, 438);
            this.tbpgDiagnostic.TabIndex = 2;
            this.tbpgDiagnostic.Text = "Diagnostic";
            this.tbpgDiagnostic.UseVisualStyleBackColor = true;
            // 
            // btnFullDiagnostic
            // 
            this.btnFullDiagnostic.Enabled = false;
            this.btnFullDiagnostic.Location = new System.Drawing.Point(562, 347);
            this.btnFullDiagnostic.Name = "btnFullDiagnostic";
            this.btnFullDiagnostic.Size = new System.Drawing.Size(127, 27);
            this.btnFullDiagnostic.TabIndex = 8;
            this.btnFullDiagnostic.Text = "Full Diagnostic";
            this.btnFullDiagnostic.UseVisualStyleBackColor = true;
            this.btnFullDiagnostic.Click += new System.EventHandler(this.RunFullDiagnostic);
            // 
            // btnQuickDiagnostic
            // 
            this.btnQuickDiagnostic.Enabled = false;
            this.btnQuickDiagnostic.Location = new System.Drawing.Point(90, 347);
            this.btnQuickDiagnostic.Name = "btnQuickDiagnostic";
            this.btnQuickDiagnostic.Size = new System.Drawing.Size(127, 27);
            this.btnQuickDiagnostic.TabIndex = 7;
            this.btnQuickDiagnostic.Text = "Quick Diagnostic";
            this.btnQuickDiagnostic.UseVisualStyleBackColor = true;
            this.btnQuickDiagnostic.Click += new System.EventHandler(this.RunQuickDiagnostic);
            // 
            // pbrDiagnstoic
            // 
            this.pbrDiagnstoic.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbrDiagnstoic.Location = new System.Drawing.Point(10, 301);
            this.pbrDiagnstoic.MarqueeAnimationSpeed = 0;
            this.pbrDiagnstoic.Name = "pbrDiagnstoic";
            this.pbrDiagnstoic.Size = new System.Drawing.Size(769, 27);
            this.pbrDiagnstoic.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbrDiagnstoic.TabIndex = 4;
            // 
            // lblDiagnostic
            // 
            this.lblDiagnostic.AutoSize = true;
            this.lblDiagnostic.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblDiagnostic.Location = new System.Drawing.Point(7, 25);
            this.lblDiagnostic.Name = "lblDiagnostic";
            this.lblDiagnostic.Size = new System.Drawing.Size(678, 210);
            this.lblDiagnostic.TabIndex = 0;
            this.lblDiagnostic.Text = resources.GetString("lblDiagnostic.Text");
            // 
            // tbpgUpdate
            // 
            this.tbpgUpdate.Controls.Add(this.rtbxFirmware);
            this.tbpgUpdate.Controls.Add(this.btnUpdate);
            this.tbpgUpdate.Controls.Add(this.lblFirmware);
            this.tbpgUpdate.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbpgUpdate.Location = new System.Drawing.Point(4, 24);
            this.tbpgUpdate.Name = "tbpgUpdate";
            this.tbpgUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgUpdate.Size = new System.Drawing.Size(792, 438);
            this.tbpgUpdate.TabIndex = 5;
            this.tbpgUpdate.Text = "Firmware Update";
            this.tbpgUpdate.UseVisualStyleBackColor = true;
            // 
            // rtbxFirmware
            // 
            this.rtbxFirmware.AcceptsTab = true;
            this.rtbxFirmware.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxFirmware.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rtbxFirmware.Location = new System.Drawing.Point(10, 148);
            this.rtbxFirmware.Name = "rtbxFirmware";
            this.rtbxFirmware.ReadOnly = true;
            this.rtbxFirmware.Size = new System.Drawing.Size(768, 193);
            this.rtbxFirmware.TabIndex = 3;
            this.rtbxFirmware.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(352, 347);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 27);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.RunUpdate);
            // 
            // lblFirmware
            // 
            this.lblFirmware.AutoSize = true;
            this.lblFirmware.Location = new System.Drawing.Point(7, 25);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(664, 105);
            this.lblFirmware.TabIndex = 0;
            this.lblFirmware.Text = resources.GetString("lblFirmware.Text");
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(729, 8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(87, 27);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.SettingsOpen);
            // 
            // ntfiTaskbar
            // 
            this.ntfiTaskbar.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfiTaskbar.ContextMenuStrip = this.cxmsTaskbar;
            this.ntfiTaskbar.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfiTaskbar.Icon")));
            this.ntfiTaskbar.Text = "Intel MAS for 7";
            this.ntfiTaskbar.DoubleClick += new System.EventHandler(this.TaskbarDoubleClick);
            // 
            // cxmsTaskbar
            // 
            this.cxmsTaskbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxmsiOpen,
            this.cxmsiExit});
            this.cxmsTaskbar.Name = "Main_ContextMenuStrip_Notify";
            this.cxmsTaskbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cxmsTaskbar.Size = new System.Drawing.Size(104, 48);
            this.cxmsTaskbar.Text = "Intel MAS for 7";
            // 
            // cxmsiOpen
            // 
            this.cxmsiOpen.Name = "cxmsiOpen";
            this.cxmsiOpen.Size = new System.Drawing.Size(103, 22);
            this.cxmsiOpen.Text = "Open";
            this.cxmsiOpen.Click += new System.EventHandler(this.TaskbarDoubleClick);
            // 
            // cxmsiExit
            // 
            this.cxmsiExit.Name = "cxmsiExit";
            this.cxmsiExit.Size = new System.Drawing.Size(103, 22);
            this.cxmsiExit.Text = "Exit";
            this.cxmsiExit.Click += new System.EventHandler(this.TaskbarExit);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 519);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.cmbxDrive);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Intel MAS for Windows 7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClosing);
            this.Resize += new System.EventHandler(this.MainResize);
            this.cxmsDrives.ResumeLayout(false);
            this.cxmsDetails.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tbpgDetails.ResumeLayout(false);
            this.grbxDetails.ResumeLayout(false);
            this.grbxDetails.PerformLayout();
            this.tbpgSensor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensor)).EndInit();
            this.tbpgSMART.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMART)).EndInit();
            this.tbpgOptimize.ResumeLayout(false);
            this.tbpgOptimize.PerformLayout();
            this.tbpgDiagnostic.ResumeLayout(false);
            this.tbpgDiagnostic.PerformLayout();
            this.tbpgUpdate.ResumeLayout(false);
            this.tbpgUpdate.PerformLayout();
            this.cxmsTaskbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbxDrive;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpgSMART;
        private System.Windows.Forms.TabPage tbpgOptimize;
        private System.Windows.Forms.TabPage tbpgDiagnostic;
        private System.Windows.Forms.DataGridView dgvSMART;
        private System.Windows.Forms.Label lblOptimization;
        private System.Windows.Forms.ProgressBar pbrDiagnstoic;
        private System.Windows.Forms.Label lblDiagnostic;
        private System.Windows.Forms.ContextMenuStrip cxmsDetails;
        private System.Windows.Forms.ToolStripMenuItem tsiCopy;
        private System.Windows.Forms.ContextMenuStrip cxmsDrives;
        private System.Windows.Forms.ToolStripMenuItem cxmsiCopyValue;
        private System.Windows.Forms.ToolStripMenuItem cxmsiRefreshDrives;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Button btnFullDiagnostic;
        private System.Windows.Forms.Button btnQuickDiagnostic;
        private System.Windows.Forms.TabPage tbpgDetails;
        private System.Windows.Forms.TabPage tbpgSensor;
        private System.Windows.Forms.DataGridView dgvSensor;
        public System.Windows.Forms.ProgressBar pbrOptimize;
        private System.Windows.Forms.TabPage tbpgUpdate;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ContextMenuStrip cxmsTaskbar;
        private System.Windows.Forms.ToolStripMenuItem cxmsiOpen;
        private System.Windows.Forms.ToolStripMenuItem cxmsiExit;
        private System.Windows.Forms.RichTextBox rtbxFirmware;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcValue;
        public System.Windows.Forms.Label lblOptimizationProg;
        public System.Windows.Forms.NotifyIcon ntfiTaskbar;
        private System.Windows.Forms.GroupBox grbxDetails;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFirmwareVer;
        private System.Windows.Forms.Label lblMediaType;
        private System.Windows.Forms.Label lblInterfaceType;
        private System.Windows.Forms.Label lblPartitions;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblDriveIndex;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNormalized;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRaw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcWorst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHigh;
    }
}

