using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MAS7.MAS;

namespace MAS7.Forms
{
    /// <summary>
    /// <see cref="Form"/> used as the Main GUI dialog for MAS7.
    /// </summary>
    public partial class Main : Form
    {
        // Storage Media Drive List.
        private List<MediaDrive> _drivesList = new List<MediaDrive>();

        // _canClose: False when a task is running.
        // _IntelExclsv: List only Intel Drives.
        // _commandLine: Show IntelMAS.exe command line (no GUI).
        // _minimizeTray / _closeTray: Minimize / Close application on taskbar.
        private bool _canClose = true, _IntelExclsv, _commandLine, _minimizeTray, _closeTray, _solidigm;

        /// <summary>
        /// Initializes a new instance of <see cref="Main"/> Form.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            // Update icon from Resources.
            Icon = Properties.Resources.icon;
            ntfiTaskbar.Icon = Icon;
            // Check if .exe path is specified.
            if (!File.Exists(Properties.Settings.Default.MASPath + "\\IntelMAS.exe") && !File.Exists(Properties.Settings.Default.MASPath + "\\sst.exe"))
            {
                using (Settings settings = new Settings())
                {
                    // Show settings Form.
                    settings.ShowDialog();
                    if (!File.Exists(Properties.Settings.Default.MASPath + "\\IntelMAS.exe") && !File.Exists(Properties.Settings.Default.MASPath + "\\sst.exe"))
                    {
                        // If .exe path is not specified, inform and disable controls.
                        MessageBox.Show("Intel/Solidigm Storage tool installation path is not specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnQuickDiagnostic.Enabled = false;
                        btnFullDiagnostic.Enabled = false;
                        btnOptimize.Enabled = false;
                        btnUpdate.Enabled = false;
                        cmbxDrive.Enabled = false;
                        // Don't forget to use relative settings.
                        _minimizeTray = Properties.Settings.Default.MinimizeOnTray;
                        _closeTray = Properties.Settings.Default.CloseOnTray;
                        return;
                    }
                }

            }
            // Update private vars.
            _IntelExclsv = Properties.Settings.Default.IntelExclusive;
            _commandLine = Properties.Settings.Default.CommandLine;
            _minimizeTray = Properties.Settings.Default.MinimizeOnTray;
            _closeTray = Properties.Settings.Default.CloseOnTray;
            _solidigm = Properties.Settings.Default.Solidigm;
            // Set Storage Media Drives and Enable UI.
            SetDrives();
            SetUIState(true);
        }

        /// <summary>
        /// Check if application can terminate.
        /// </summary>
        /// <remarks>Raised on <see cref="Main"/> Closing Event.</remarks>
        private void MainClosing(object sender, FormClosingEventArgs args)
        {
            // Check if there is a Task running in the background.
            // And - Check if Taskbar icon is visible OR if App can close on tray.
            if (!_canClose && (ntfiTaskbar.Visible || !_closeTray))
            {
                // Inform user about current task.
                DialogResult drFormClosingMsg = MessageBox.Show("A process is running in the background. Closing this application" +
                    " may cause permanent damage to your SSD.\nWould you like to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // Exit on user demand.
                if (drFormClosingMsg == DialogResult.Yes)
                {
                    // First kill IntelMAS.exe or sst.exe.
                    // Then kill MAS7.exe
                    ntfiTaskbar.Visible = false;
                    foreach (Process prRunningProcess in Process.GetProcesses())
                    {
                        if (prRunningProcess.ProcessName.ToString() == "IntelMAS" || prRunningProcess.ProcessName.ToString() == "sst")
                            prRunningProcess.Kill();
                    }
                    foreach (Process prRunningProcess in Process.GetProcesses())
                    {
                        if (prRunningProcess.ProcessName.ToString() == "MAS7")
                            prRunningProcess.Kill();
                    }
                }
                else if (drFormClosingMsg == DialogResult.No)
                    args.Cancel = true;
            }
            // Closing on tray while Task is running.
            else if (!_canClose && _closeTray)
            {
                args.Cancel = true;
                Hide();
                ntfiTaskbar.Visible = true;
                ShowMessage(ToolTipIcon.Info, "Background Tasks", "Tasks will continue running in background. Please minimize system usage.");
            }
            // Closing on tray without running a Task.
            else if (_closeTray)
            {
                args.Cancel = true;
                Hide();
                ntfiTaskbar.Visible = true;
            }
        }

        /// <summary>
        /// Check if taskbar icon can be visible.
        /// </summary>
        /// <remarks>Raised on <see cref="Main"/> Resize Event.</remarks>
        private void MainResize(object sender, EventArgs args)
        {
            // Check if App can be minimized on Taskbar.
            if (WindowState == FormWindowState.Minimized && _minimizeTray)
            {
                Hide();
                ntfiTaskbar.Visible = true;
                ntfiTaskbar.ShowBalloonTip(6000);
            }
        }

        /// <summary>
        /// Run SSD optimizer on current <see cref="MediaDrive"/>.
        /// </summary>
        private void RunOptimization(object sender, EventArgs args)
        {
            // Check if Storage device is INTEL.
            if (!GetIsIntel() || _drivesList.Count == 0) return;
            // Get index of Storage device.
            int index = int.Parse(_drivesList[cmbxDrive.SelectedIndex].Index);
            // Update Taskbar.
            UpdateTaskbar(MASConsole.Progress.Optimization, MASConsole.ProgressState.Started);
            // Disable UI.
            SetUIState(false);
            // Run SSD Optimizer.
            new Task(() => MASConsole.RunOptimizer(this, index, _commandLine, _solidigm)).Start();
        }

        /// <summary>
        /// Run Quick Diagnostic Scan on current <see cref="MediaDrive"/>.
        /// </summary>
        private void RunQuickDiagnostic(object sender, EventArgs args)
        {
            // Check if Storage device is Intel.
            if (!GetIsIntel() || _drivesList.Count == 0) return;
            // Get index of Storage device.
            int index = int.Parse(_drivesList[cmbxDrive.SelectedIndex].Index);
            // Update Taskbar.
            UpdateTaskbar(MASConsole.Progress.QuickDiagnostic, MASConsole.ProgressState.Started);
            // Disable UI.
            SetUIState(false);
            // Run Quick Diagnostic Scan.
            new Task(() => MASConsole.RunQuickTest(this, index, _commandLine, _solidigm)).Start();
        }

        /// <summary>
        /// Run Full Diagnostic Scan on current <see cref="MediaDrive"/>.
        /// </summary>
        private void RunFullDiagnostic(object sender, EventArgs args)
        {
            // Check if Storage device is Intel.
            if (!GetIsIntel() || _drivesList.Count == 0) return;
            // Get index of Storage device.
            int index = int.Parse(_drivesList[cmbxDrive.SelectedIndex].Index);
            // Update Taskbar.
            UpdateTaskbar(MASConsole.Progress.FullDiagnostic, MASConsole.ProgressState.Started, false);
            // Disable UI.
            SetUIState(false);
            // Run Full Diagnostic Scan.
            new Task(() => MASConsole.RunFullTest(this, index, _commandLine, _solidigm)).Start();
        }

        /// <summary>
        /// Run Firmware Update on current <see cref="MediaDrive"/>.
        /// </summary>
        private void RunUpdate(object sender, EventArgs args)
        {
            // Check if Storage device is Intel.
            if (!GetIsIntel() || _drivesList.Count == 0) return;
            // Clear RichTextBox rtbxFirmware log.
            rtbxFirmware.Clear();
            // Get index of Storage device.
            int index = int.Parse(_drivesList[cmbxDrive.SelectedIndex].Index);
            // Update Taskbar.
            UpdateTaskbar(MASConsole.Progress.FirmwareUpdate, MASConsole.ProgressState.Started, false);
            // Disable UI.
            SetUIState(false);
            // Run Firmware Update.
            new Thread(() => MASConsole.RunFirmwareUpdate(this, index, _solidigm)).Start();
        }

        /// <summary>
        /// Open <see cref="Settings"/>> Form.
        /// </summary>
        private void SettingsOpen(object sender, EventArgs args)
        {
            // Get DialogResult of new Settings Form.
            DialogResult dialogResult;
            using (Settings settings = new Settings())
            {
                settings.ShowDialog();
                dialogResult = settings.DialogResult;
            }
            // Make changes, only if DialogResult is OK.
            if (dialogResult != DialogResult.OK) return;
            _IntelExclsv = Properties.Settings.Default.IntelExclusive;
            _commandLine = Properties.Settings.Default.CommandLine;
            _minimizeTray = Properties.Settings.Default.MinimizeOnTray;
            _closeTray = Properties.Settings.Default.CloseOnTray;
            _solidigm = Properties.Settings.Default.Solidigm;
            // Clear DataGridView rows.
            dgvSMART.Rows.Clear();
            dgvSMART.Refresh();
            dgvSensor.Rows.Clear();
            dgvSensor.Refresh();
            cmbxDrive.Items.Clear();
            // Clear ComboBox items.
            _drivesList.Clear();
            // (Re)Set Media Drives.
            SetDrives();
        }

        /// <summary>
        /// Select current <see cref="MediaDrive"/>.
        /// </summary>
        private void SelectDrive(object sender, EventArgs args)
        {
            // Get MediaDrive information.
            MediaDrive SelectedDrive = _drivesList[cmbxDrive.SelectedIndex];
            grbxDetails.Text = "Caption: " + SelectedDrive.Caption;
            lblFirmwareVer.Text = "Firmware Revision: " + SelectedDrive.FirmwareRevision;
            lblInterfaceType.Text = "Interface Type: " + SelectedDrive.InterfaceType;
            lblModel.Text = "Model: " + SelectedDrive.Model;
            lblSerialNumber.Text = "Serial Number: " + SelectedDrive.SerialNumber;
            lblStatus.Text = "Status: " + SelectedDrive.Status;
            lblDriveIndex.Text = "Drive Index: " + SelectedDrive.Index;
            lblMediaType.Text = "Media Type: " + SelectedDrive.MediaType;
            lblPartitions.Text = "Partitions: " + SelectedDrive.Partitions;
            lblSize.Text = "Size: " + SelectedDrive.Size + " GB";
            // Clear DataGridViews.
            dgvSMART.Rows.Clear();
            dgvSMART.Refresh();
            dgvSensor.Rows.Clear();
            dgvSensor.Refresh();
            // Get SMART information and update DataGridView dgvSMART.
            List<SMARTinfo> smartInfo = MASConsole.GetSMART(int.Parse(SelectedDrive.Index), _solidigm);
            foreach (SMARTinfo info in smartInfo)
            {
                dgvSMART.Rows.Insert(dgvSMART.Rows.Count, info.GetPropertyValue(SMARTinfo.Property.Action),
                    info.GetPropertyValue(SMARTinfo.Property.Attribute), info.GetPropertyValue(SMARTinfo.Property.Description),
                    info.GetPropertyValue(SMARTinfo.Property.ID), info.GetPropertyValue(SMARTinfo.Property.Normalized),
                    info.GetPropertyValue(SMARTinfo.Property.Raw), info.GetPropertyValue(SMARTinfo.Property.Status),
                    info.GetPropertyValue(SMARTinfo.Property.Threshold), info.GetPropertyValue(SMARTinfo.Property.Worst),
                    info.GetPropertyValue(SMARTinfo.Property.Current), info.GetPropertyValue(SMARTinfo.Property.Low),
                    info.GetPropertyValue(SMARTinfo.Property.High));
            }
            // Get Sensor information and update DataGridView dgvSensor.
            List<SensorInfo> sensorInfos = MASConsole.GetSensorInfo(int.Parse(SelectedDrive.Index), _solidigm);
            foreach (SensorInfo info in sensorInfos)
                dgvSensor.Rows.Insert(dgvSensor.Rows.Count, info.Property, info.Value);
        }

        /// <summary>
        /// Set <see cref="Main"/> controls .Enabled property value to <paramref name="enabled"/>
        /// </summary>
        /// <param name="enabled">.Enabled property value of controls.</param>
        public void SetUIState(bool enabled)
        {
            // Always the opposite to enabled.
            Application.UseWaitCursor = !enabled;
            // Check for InvokeRequired and change .Enabled value.
            if (btnQuickDiagnostic.InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    _canClose = enabled;
                    btnOptimize.Enabled = enabled;
                    btnQuickDiagnostic.Enabled = enabled;
                    btnFullDiagnostic.Enabled = enabled;
                    btnUpdate.Enabled = enabled;
                    cmbxDrive.Enabled = enabled;
                }));
                return;
            }
            _canClose = enabled;
            btnOptimize.Enabled = enabled;
            btnQuickDiagnostic.Enabled = enabled;
            btnFullDiagnostic.Enabled = enabled;
            btnUpdate.Enabled = enabled;
            cmbxDrive.Enabled = enabled;
        }

        /// <summary>
        /// Set <see cref="cmbxDrive"/> items.
        /// </summary>
        private void SetDrives()
        {
            // Get Storage Media Drives.
            // Add them on ComboBox cmbxDrive Item Collection.
            _drivesList = MASConsole.GetDrives(_IntelExclsv);
            for (int cnt = 0; cnt < _drivesList.Count; cnt++)
                cmbxDrive.Items.Add(_drivesList[cnt].Caption);
        }

        /// <summary>
        /// Set ProgressBar and Label control value to indicate process.
        /// </summary>
        /// <param name="progress">MAS progress.</param>
        /// <param name="value">Value of progress.</param>
        public void SetProgressValue(MASConsole.Progress progress, int value)
        {
            // Get the appropriate ProgressBar and Label control.
            // Check if InvokeRequired.
            // Update ProgressBar and Label value.
            switch (progress)
            {
                case MASConsole.Progress.FullDiagnostic:
                case MASConsole.Progress.QuickDiagnostic:
                    // QuickDiagnostic and FullDiagnostic process don't require a Value.
                    if (pbrDiagnstoic.InvokeRequired)
                    {
                        pbrDiagnstoic.Invoke(new MethodInvoker(() =>
                        {
                            if (value != 0) pbrDiagnstoic.MarqueeAnimationSpeed = 50;
                            else pbrDiagnstoic.MarqueeAnimationSpeed = 0;
                        }));
                        return;
                    }
                    if (value != 0) pbrDiagnstoic.MarqueeAnimationSpeed = 50;
                    else pbrDiagnstoic.MarqueeAnimationSpeed = 0;
                    return;
                case MASConsole.Progress.Optimization:
                    if (pbrOptimize.InvokeRequired)
                    {
                        pbrOptimize.Invoke(new MethodInvoker(() => pbrOptimize.Value = value));
                        lblOptimizationProg.Invoke(new MethodInvoker(() => lblOptimizationProg.Text = value + "%"));
                        return;
                    }
                    pbrOptimize.Value = value;
                    lblOptimizationProg.Text = value + "%";
                    return;
                default:
                    return;

            }
        }

        /// <summary>
        /// Append <see cref="rtbxFirmware"/> text.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public void AppendRtxb(string text)
        {
            // Check if .InvokeRequired.
            if (rtbxFirmware.InvokeRequired)
            {
                rtbxFirmware.Invoke(new MethodInvoker(() =>
                {
                    rtbxFirmware.AppendText(text);
                }));
                return;
            }
            rtbxFirmware.AppendText(text);
        }

        /// <summary>
        /// Check if application can terminate.
        /// </summary>
        /// <remarks>Raised from Tray icon.</remarks>
        private void TaskbarExit(object sender, EventArgs args)
        {
            // Check if a task is running in the background.
            if (!_canClose)
            {
                // Inform user of potential risk when closing background Task.
                DialogResult dialogResult = MessageBox.Show("A process is running in the background. Closing this application" +
                    " may cause permanent damage to your SSD.\nWould you like to exit?", 
                    "Background Tasks", MessageBoxButtons.YesNo ,MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) return;
            }
            // Kill task and Exit on user demang.
            ntfiTaskbar.Visible = false;
            foreach (Process prRunningProcess in Process.GetProcesses())
            {
                if (prRunningProcess.ProcessName.ToString() == "MAS7")
                    prRunningProcess.Kill();
            }
        }

        /// <summary>
        /// Hide taskbar and display <see cref="Main"/> Form.
        /// </summary>
        /// <remarks>Raised from Tray icon.</remarks>
        private void TaskbarDoubleClick(object sender, EventArgs args)
        {
            // Show main form on Tray icon double click.
            Show();
            WindowState = FormWindowState.Normal;
            ntfiTaskbar.Visible = false;
        }

        /// <summary>
        /// Update or Display a message on taskbar.
        /// </summary>
        /// <param name="progress">MAS progress.</param>
        /// <param name="progressState">State of progress.</param>
        /// <param name="message">Show message on Taskbar.</param>
        public void UpdateTaskbar(MASConsole.Progress progress, MASConsole.ProgressState progressState, bool message = true)
        {
            // Get current Progress.
            string balloonText, taskbarText;
            switch (progressState)
            {
                case MASConsole.ProgressState.Started:
                    balloonText = "Started ";
                    break;
                case MASConsole.ProgressState.Running:
                    balloonText = "Running ";
                    break;
                default:
                    ntfiTaskbar.Text = "Intel MAS for 7";
                    return;

            }
            // Get current Task.
            switch (progress)
            {
                case MASConsole.Progress.FullDiagnostic:
                    taskbarText = "Full Diagnostic Scan.";
                    break;
                case MASConsole.Progress.QuickDiagnostic:
                    taskbarText = "Quick Diagnostic Scan.";
                    break;
                case MASConsole.Progress.Optimization:
                    taskbarText = "SSD Optimizer.";
                    break;
                case MASConsole.Progress.FirmwareUpdate:
                    taskbarText = "Firmware Update.";
                    break;
                default:
                    return;

            }
            // Update taskbar text and show message if needed.
            ntfiTaskbar.BalloonTipIcon = ToolTipIcon.Info;
            ntfiTaskbar.BalloonTipText = balloonText;
            ntfiTaskbar.Text = balloonText + "- " + taskbarText;
            if (!message) return;
            ShowMessage(ToolTipIcon.Info, balloonText + taskbarText,
                "Tasks will continue running in background. Please minimize system usage.");
        }

        /// <summary>
        /// Check if <see cref="cmbxDrive"/> selected <see cref="MediaDrive"/> item, is an Intel Drive.
        /// </summary>
        private bool GetIsIntel()
        {
            // Check if current selected ComboBox item is an Intel MediaDrive.
            if (!cmbxDrive.Text.Contains("INTEL"))
            {
                ShowMessage(ToolTipIcon.Warning, "Warning", "This feature is available exclusively for Intel SSDs.");
                tbcMain.SelectedTab = tbpgDetails;
                return false;
            } 
            // Check if current selected ComboBox item is empty.
            else if (string.IsNullOrEmpty(cmbxDrive.Text))
            {
                ShowMessage(ToolTipIcon.Warning, "Warning", "Please select an Intel storage media.");
                tbcMain.SelectedTab = tbpgDetails;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set <see cref="Clipboard"/> text.
        /// </summary>
        private void CopyObjectText(object sender, EventArgs args)
        {
            // Sender must be a ToolStripItem or a ContextMenuStrip.
            if (!(sender is ToolStripItem item) || !(item.Owner is ContextMenuStrip strip)) return;
            Clipboard.SetText(strip.SourceControl.Text);
        }

        /// <summary>
        /// Show message to user.
        /// </summary>
        /// <param name="icon">Ballon icon for taskbar notification.</param>
        /// <param name="title">Title of message.</param>
        /// <param name="text">Text of message.</param>
        /// <param name="diagnosticForm">Display <see cref="Diagnostic"/> Form.</param>
        public void ShowMessage(ToolTipIcon icon, string title, string text, bool diagnosticForm = false)
        {
            // Show message as Tray Icon Bubble.
            if (ntfiTaskbar.Visible)
            {
                ntfiTaskbar.BalloonTipIcon = icon;
                ntfiTaskbar.BalloonTipTitle = title;
                ntfiTaskbar.BalloonTipText = text;
                ntfiTaskbar.ShowBalloonTip(6000);
            }
            // Show message on MessageBox or Diagnostic Form.
            else if (!diagnosticForm)
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Diagnostic diagnostic = new Diagnostic(text);
                diagnostic.Text = title;
                diagnostic.ShowDialog();
            }
        }
    }
}