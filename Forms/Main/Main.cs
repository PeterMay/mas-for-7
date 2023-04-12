using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MAS7.Console;
using MAS7.Enums;
using MAS7.Models;

namespace MAS7.Forms
{
    /// <summary>
    /// <see cref="Form"/> used as the Main GUI dialog for MAS7.
    /// </summary>
    public partial class Main : Form
    {

        private bool _canCloseSafely = true, _intelExclsv, _commandLine, _minimizeTray, _closeTray, _isSolidigm;
        private int _selectedDriveIndex;
        private string _selectedDriveText;
        private List<MediaDrive> _drivesList = new List<MediaDrive>();
        private ICliTool _cliTool;

        /// <summary>
        /// Initializes a new instance of <see cref="Main"/> Form.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            Icon = Properties.Resources.icon;
            ntfiTaskbar.Icon = Icon;

            SetUiState(false);
            if (!GetIsCurrentPathValid())
            {
                using (Settings settings = new Settings())
                {
                    settings.ShowDialog();
                    if (!GetIsCurrentPathValid()) Environment.Exit(101);
                }
            }

            UpdatePrivateFieldsFromProperties();
            SetCmbxDrives();
            SetUiState(true);
        }

        /// <summary>
        /// Append <see cref="rtbxFirmware"/> text.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public void AppendFirmwareRtxb(string text)
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
        /// Show message to user.
        /// </summary>
        /// <param name="icon">Ballon icon for taskbar notification.</param>
        /// <param name="title">Title of message.</param>
        /// <param name="message">Message Text.</param>
        /// <param name="diagnosticForm">Display <see cref="Diagnostic"/> Form.</param>
        public void ShowMessage(ToolTipIcon icon, string title, string message, bool diagnosticForm = false)
        {
            if (ntfiTaskbar.Visible)
            {
                ntfiTaskbar.BalloonTipIcon = icon;
                ntfiTaskbar.BalloonTipTitle = title;
                ntfiTaskbar.BalloonTipText = message;
                ntfiTaskbar.ShowBalloonTip(6000);
            }
            else if (!diagnosticForm)
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Diagnostic diagnostic = new Diagnostic(message);
                diagnostic.Text = title;
                diagnostic.ShowDialog();
            }
        }

        /// <summary>
        /// Set ProgressBar and Label control value to indicate process.
        /// </summary>
        /// <param name="progress">MAS progress.</param>
        /// <param name="value">Value of progress.</param>
        public void SetProgressValue(Progress progress, int value)
        {
            switch (progress)
            {
                case Progress.FullDiagnostic:
                case Progress.QuickDiagnostic:
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
                case Progress.Optimization:
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
        /// Update or Display a message on taskbar.
        /// </summary>
        /// <param name="progress">MAS progress.</param>
        /// <param name="progressState">State of progress.</param>
        public void UpdateTaskbar(Progress progress, ProgressState progressState)
        {
            string balloonText, taskbarText;
            switch (progressState)
            {
                case ProgressState.Started:
                    balloonText = "Started ";
                    break;
                case ProgressState.Running:
                    balloonText = "Running ";
                    break;
                default:
                    ntfiTaskbar.Text = "Intel MAS for 7";
                    return;

            }
            switch (progress)
            {
                case Progress.FullDiagnostic:
                    taskbarText = "Full Diagnostic Scan.";
                    break;
                case Progress.QuickDiagnostic:
                    taskbarText = "Quick Diagnostic Scan.";
                    break;
                case Progress.Optimization:
                    taskbarText = "SSD Optimizer.";
                    break;
                case Progress.FirmwareUpdate:
                    taskbarText = "Firmware Update.";
                    break;
                default:
                    return;

            }
            // Update taskbar text and show message if needed.
            ntfiTaskbar.BalloonTipIcon = ToolTipIcon.Info;
            ntfiTaskbar.BalloonTipText = balloonText;
            ntfiTaskbar.Text = balloonText + "- " + taskbarText;
            ShowMessage(ToolTipIcon.Info, balloonText + taskbarText,
                "Tasks will continue running in background. Please minimize system usage.");
        }




        /// <summary>
        /// Check if application can terminate.
        /// </summary>
        /// <remarks>Raised on <see cref="Main"/> Closing Event.</remarks>
        private void OnMainClosing(object sender, FormClosingEventArgs args)
        {
            if (!_canCloseSafely && (ntfiTaskbar.Visible || !_closeTray))
            {
                DialogResult drFormClosingMsg = MessageBox.Show("A process is running in the background. Closing this application" +
                    " may cause permanent damage to your SSD.\nWould you like to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drFormClosingMsg == DialogResult.Yes)
                {
                    ntfiTaskbar.Visible = false;
                    KillTasks();
                }
                else if (drFormClosingMsg == DialogResult.No)
                    args.Cancel = true;
            }
            else if (!_canCloseSafely && _closeTray)
            {
                args.Cancel = true;
                Hide();
                ntfiTaskbar.Visible = true;
                ShowMessage(ToolTipIcon.Info, "Background Tasks", "Tasks will continue running in background. Please minimize system usage.");
            }
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
        private void OnMainResize(object sender, EventArgs args)
        {
            if (WindowState == FormWindowState.Minimized && _minimizeTray)
            {
                Hide();
                ntfiTaskbar.Visible = true;
            }
        }

        /// <summary>
        /// Run SSD optimizer on current <see cref="MediaDrive"/>.
        /// </summary>
        private void OnRunOptimizationClick(object sender, EventArgs args)
        {
            if (!GetIsDriveCompatible()) return;
            UpdateTaskbar(Progress.Optimization, ProgressState.Started);
            SetTaskIsRunning(true);
            int index = int.Parse(_drivesList[_selectedDriveIndex].Index);
            Task optimizer = new Task(() => _cliTool.RunOptimizer(this, index, _commandLine));
            optimizer.ContinueWith(_ => SetTaskIsRunning(false));
            optimizer.Start();
        }

        /// <summary>
        /// Run Quick Diagnostic Scan on current <see cref="MediaDrive"/>.
        /// </summary>
        private void OnRunQuickDiagnosticClick(object sender, EventArgs args)
        {
            if (!GetIsDriveCompatible()) return;
            UpdateTaskbar(Progress.QuickDiagnostic, ProgressState.Started);
            SetTaskIsRunning(true);
            int index = int.Parse(_drivesList[_selectedDriveIndex].Index);
            Task quickTest = new Task(() => _cliTool.RunQuickTest(this, index, _commandLine));
            quickTest.ContinueWith(_ => SetTaskIsRunning(false));
            quickTest.Start();

        }

        /// <summary>
        /// Run Full Diagnostic Scan on current <see cref="MediaDrive"/>.
        /// </summary>
        private void OnRunFullDiagnosticClick(object sender, EventArgs args)
        {
            if (!GetIsDriveCompatible()) return;
            UpdateTaskbar(Progress.FullDiagnostic, ProgressState.Started);
            SetTaskIsRunning(true);
            int index = int.Parse(_drivesList[_selectedDriveIndex].Index);
            Task fullTest = new Task(() => _cliTool.RunFullTest(this, index, _commandLine));
            fullTest.ContinueWith(_ => SetTaskIsRunning(false));
            fullTest.Start();
        }

        /// <summary>
        /// Run Firmware Update on current <see cref="MediaDrive"/>.
        /// </summary>
        private void OnRunUpdateClick(object sender, EventArgs args)
        {
            if (!GetIsDriveCompatible()) return;
            rtbxFirmware.Clear();
            UpdateTaskbar(Progress.FirmwareUpdate, ProgressState.Started);
            SetTaskIsRunning(true);
            int index = int.Parse(_drivesList[_selectedDriveIndex].Index);
            Task firmwareUpdate = new Task(() => _cliTool.RunFirmwareUpdate(this, index));
            firmwareUpdate.ContinueWith(_ => SetTaskIsRunning(false));
            firmwareUpdate.Start();
        }

        /// <summary>
        /// Open <see cref="Settings"/>> Form.
        /// </summary>
        private void OnSettingsOpenClick(object sender, EventArgs args)
        {
            DialogResult dialogResult;
            using (Settings settings = new Settings())
            {
                settings.ShowDialog();
                dialogResult = settings.DialogResult;
            }
            if (dialogResult != DialogResult.OK) return;

            ClearDataGridViews();
            cmbxDrive.Items.Clear();
            _drivesList.Clear();
            if (!GetIsCurrentPathValid())
            {
                SetUiState(false);
                return;
            }
            UpdatePrivateFieldsFromProperties();
            SetCmbxDrives();
            SetUiState(true);
        }

        /// <summary>
        /// Select current <see cref="MediaDrive"/>.
        /// </summary>
        private void OnSelectDriveIndexChange(object sender, EventArgs args)
        {
            // Info.
            _selectedDriveIndex = cmbxDrive.SelectedIndex;
            _selectedDriveText = cmbxDrive.Text;
            MediaDrive SelectedDrive = _drivesList[_selectedDriveIndex];
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

            // SMART.
            ClearDataGridViews();
            List<SMARTinfo> smartInfo = _cliTool.GetSMART(int.Parse(SelectedDrive.Index));
            foreach (SMARTinfo info in smartInfo)
            {
                dgvSMART.Rows.Insert(dgvSMART.Rows.Count, info.Action, info.Attribute, info.Description,
                    info.ID, info.Normalized, info.Raw, info.Status, info.Threshold, info.Worst,
                    info.Current, info.Low, info.High);
            }

            // Sensors.
            List<SensorInfo> sensorInfos = _cliTool.GetSensorInfo(int.Parse(SelectedDrive.Index));
            foreach (SensorInfo info in sensorInfos)
                dgvSensor.Rows.Insert(dgvSensor.Rows.Count, info.Property, info.Value);
        }

        /// <summary>
        /// Check if application can terminate.
        /// </summary>
        /// <remarks>Raised from Tray icon.</remarks>
        private void OnTaskbarExit(object sender, EventArgs args)
        {
            if (!_canCloseSafely)
            {
                DialogResult dialogResult = MessageBox.Show("A process is running in the background. Closing this application" +
                    " may cause permanent damage to your SSD.\nWould you like to exit?",
                    "Background Tasks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) return;
            }
            ntfiTaskbar.Visible = false;
            KillTasks();
        }

        /// <summary>
        /// Hide taskbar and display <see cref="Main"/> Form.
        /// </summary>
        /// <remarks>Raised from Tray icon.</remarks>
        private void OnTaskbarDoubleClick(object sender, EventArgs args)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ntfiTaskbar.Visible = false;
        }

        /// <summary>
        /// Set <see cref="Clipboard"/> text.
        /// </summary>
        private void OnCopyObjectEvent(object sender, EventArgs args)
        {
            if (!(sender is ToolStripItem item) || !(item.Owner is ContextMenuStrip strip)) return;
            Clipboard.SetText(strip.SourceControl.Text);
        }



        /// <summary>
        /// Clear DataGridView rows.
        /// </summary>
        private void ClearDataGridViews()
        {
            dgvSMART.Rows.Clear();
            dgvSMART.Refresh();
            dgvSensor.Rows.Clear();
            dgvSensor.Refresh();
        }

        /// <summary>
        /// Kill Intel MAS and Solidigm Storage Tool processes.
        /// </summary>
        private void KillTasks()
        {
            foreach (Process prRunningProcess in Process.GetProcesses())
            {
                if (prRunningProcess.ProcessName.ToString() == "IntelMAS" ||
                    prRunningProcess.ProcessName.ToString() == "sst")
                    prRunningProcess.Kill();
            }
            Environment.Exit(100);
        }

        /// <summary>
        /// Check if current path for MAS or SST CLI executable is valid.
        /// </summary>
        /// <returns>True if path is valid</returns>
        private bool GetIsCurrentPathValid()
        {
            return (File.Exists(Properties.Settings.Default.MASPath + "\\IntelMAS.exe") ||
                File.Exists(Properties.Settings.Default.MASPath + "\\sst.exe"));
        }

        /// <summary>
        /// Check if selected <see cref="MediaDrive"/> item from <see cref="cmbxDrive"/> , is an Intel Drive.
        /// </summary>
        /// <returns>True if selected drive is Intel.</returns>
        private bool GetIsDriveCompatible()
        {
            if (_drivesList.Count == 0 || string.IsNullOrEmpty(_selectedDriveText) || !_selectedDriveText.Contains("INTEL"))
            {
                ShowMessage(ToolTipIcon.Warning, "Warning", "This feature is available exclusively for Intel SSDs.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set <see cref="cmbxDrive"/> items.
        /// </summary>
        private void SetCmbxDrives()
        {
            for (int cnt = 0; cnt < _drivesList.Count; cnt++)
                cmbxDrive.Items.Add(_drivesList[cnt].Caption);
        }

        /// <summary>
        /// Set Task is Running flag.
        /// </summary>
        /// <param name="taskIsRunning">Task is Running Value.</param>
        private void SetTaskIsRunning(bool taskIsRunning)
        {
            Application.UseWaitCursor = taskIsRunning;
            _canCloseSafely = !taskIsRunning;
            SetUiState(!taskIsRunning);
        }

        /// <summary>
        /// Set "Enabled" property value on appropriate controls.
        /// </summary>
        /// <param name="state">.Value of controls "enabled" state.</param>
        private void SetUiState(bool state)
        {
            if (btnQuickDiagnostic.InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    btnOptimize.Enabled = state;
                    btnQuickDiagnostic.Enabled = state;
                    btnFullDiagnostic.Enabled = state;
                    btnUpdate.Enabled = state;
                    btnSettings.Enabled = state;
                    cmbxDrive.Enabled = state;
                }));
                return;
            }
            btnOptimize.Enabled = state;
            btnQuickDiagnostic.Enabled = state;
            btnFullDiagnostic.Enabled = state;
            btnUpdate.Enabled = state;
            btnSettings.Enabled = state;
            cmbxDrive.Enabled = state;
        }

        /// <summary>
        /// Get correct private field values from properties.
        /// </summary>
        private void UpdatePrivateFieldsFromProperties()
        {
            _intelExclsv = Properties.Settings.Default.IntelExclusive;
            _commandLine = Properties.Settings.Default.CommandLine;
            _minimizeTray = Properties.Settings.Default.MinimizeOnTray;
            _closeTray = Properties.Settings.Default.CloseOnTray;
            _isSolidigm = Properties.Settings.Default.Solidigm;
            if (!_isSolidigm) _cliTool = new MasCli();
            else _cliTool = new SstCli();
            _drivesList = _cliTool.GetDrives(_intelExclsv);
        }

    }
}