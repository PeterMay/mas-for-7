using System;
using System.Management;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace MAS7.MAS
{
    /// <summary>
    /// <see langword="static"/> Provides access to Intel/Solidigm Memory and Storage CLI functions.
    /// </summary>
    public static class MASConsole
    {
        /// <summary>
        /// Type of Memory and Storage tool Progress.
        /// </summary>
        public enum Progress
        {
            Optimization,
            FullDiagnostic,
            QuickDiagnostic,
            FirmwareUpdate
        }

        /// <summary>
        /// State of Progress of different tasks.
        /// </summary>
        public enum ProgressState
        {
            Started,
            Running,
            Finished
        }

        /// <summary>
        /// Start new Process
        /// </summary>
        /// <param name="arguments">Arguments passed on Process. </param>
        /// <param name="commandLine">Specifies wheter a Command Line window is used for output. </param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        /// <returns>Appropriate Process to run MAS tasks.</returns>
        private static Process NewProcess(string arguments, bool commandLine, bool solidigm)
        {
            // Run IntelMAS.exe or sst.exe with arguments.
            Process intelProcess = new Process();
            if (solidigm) intelProcess.StartInfo.FileName = Properties.Settings.Default.MASPath + "\\sst.exe";
            else intelProcess.StartInfo.FileName = Properties.Settings.Default.MASPath + "\\IntelMAS.exe";
            intelProcess.StartInfo.Arguments = arguments;
            // Check user settings. If true, then create CMD window.
            if (commandLine)
            {
                intelProcess.StartInfo.UseShellExecute = true;
                intelProcess.StartInfo.CreateNoWindow = false;
            }
            else
            {
                intelProcess.StartInfo.UseShellExecute = false;
                intelProcess.StartInfo.RedirectStandardOutput = true;
                intelProcess.StartInfo.RedirectStandardError = true;
                intelProcess.StartInfo.CreateNoWindow = true;
            }
            return intelProcess;
        }

        /// <summary>
        /// Run SSD optimizer.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>To be used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="commandLine">Specifies wheter a Command Line window is used for output.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        public static void RunOptimizer(Forms.Main form, int index, bool commandLine, bool solidigm)
        {
            // Check for sst.exe
            if (solidigm)
            {
                MessageBox.Show("SSD Optimization feature is only available when using Intel Memory and Storage Tool.", "Feature not available",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Enable UI.
                form.SetUIState(true);
                // Update Taskbar text.
                form.UpdateTaskbar(Progress.Optimization, ProgressState.Finished);
                return;
            }
            // Create new process.
            Process intelProcess = NewProcess("start -intelssd " + index + " -optimizer", commandLine, solidigm);
            intelProcess.Start();
            // Return if CMD is used.
            if (commandLine) return;
            string output = "Nothing to report.";
            // Read every line.
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
            {
                // If output contains "Status", then Process is finished.
                if (output.Contains("Status")) break;
                // If output contains "Optimizing", then update progress bar value.
                if (output.Contains("Optimizing"))
                    form.SetProgressValue(Progress.Optimization, int.Parse(output.Substring(12, output.Length - 13)));
            }
            // Show balloon on Taskbar or Message.
            form.ShowMessage(ToolTipIcon.Info, "Finished!", output);
            // Progress value to 0.
            form.SetProgressValue(Progress.Optimization, 0);
            // Enable UI.
            form.SetUIState(true);
            // Update Taskbar text.
            form.UpdateTaskbar(Progress.Optimization, ProgressState.Finished);

        }

        /// <summary>
        /// Run Quick Scan Diagnostic.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>To be used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="commandLine">Specifies wheter a Command Line window is used for output.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        public static void RunQuickTest(Forms.Main form, int index, bool commandLine, bool solidigm)
        {
            // Create new process.
            Process intelProcess;
            if (solidigm) intelProcess = NewProcess("start -scan -ssd " + index.ToString() + " FullScan = false IncludeSystemInfo = true", commandLine, solidigm);
            else intelProcess = NewProcess("start -scan -intelssd " + index.ToString() + " FullScan = false IncludeSystemInfo = true", commandLine, solidigm);
            intelProcess.Start();
            // Return if CMD is used.
            if (commandLine) return;
            string output, result = "";
            bool log = false;
            // Start progress bar.
            form.SetProgressValue(Progress.QuickDiagnostic, 1);
            // Read every line.
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
            {
                if (output.Contains("- Scan"))
                {
                    // Stop progress bar.
                    form.SetProgressValue(Progress.QuickDiagnostic, 0);
                    log = true;
                }
                if (log)
                {
                    if (output.Length > 10)
                        result = result + output + "\n";
                }
            }
            // Show balloon on Taskbar or Message.
            form.ShowMessage(ToolTipIcon.Info, "Finished!", result, true);
            // Enable UI.
            form.SetUIState(true);
            // Update Taskbar text.
            form.UpdateTaskbar(Progress.QuickDiagnostic, ProgressState.Finished);
        }

        /// <summary>
        /// Run Full Scan Diagnostic.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>To be used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="commandLine">Specifies wheter a Command Line window is used for output.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        public static void RunFullTest(Forms.Main form, int index, bool commandLine, bool solidigm)
        {
            // Create new process.
            Process intelProcess;
            if (solidigm) intelProcess = NewProcess("start -scan -ssd " + index.ToString() + " FullScan = true IncludeSystemInfo = true", commandLine, solidigm);
            else intelProcess = NewProcess("start -scan -intelssd " + index.ToString() + " FullScan = true IncludeSystemInfo = true", commandLine, solidigm);
            intelProcess.Start();
            // Return is CMD is used.
            if (commandLine) return;

            string output, result = "";
            bool log = false;
            // Start progress bar.
            form.SetProgressValue(Progress.QuickDiagnostic, 1);
            // Read every line.
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
            {
                if (output.Contains("- Scan"))
                {
                    // Stop progress bar.
                    form.SetProgressValue(Progress.QuickDiagnostic, 0);
                    log = true;
                }
                if (log)
                {
                    if (output.Length > 10)
                        result = result + output + "\n";
                }
            }
            // Show balloon on Taskbar or Message.
            form.ShowMessage(ToolTipIcon.Info, "Finished!", output);
            // Enable UI.
            form.SetUIState(true);
            // Update Taskbar text.
            form.UpdateTaskbar(Progress.FirmwareUpdate, ProgressState.Finished);
        }

        /// <summary>
        /// Run Firmware Update.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>To be used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        public static void RunFirmwareUpdate(Forms.Main form, int index, bool solidigm)
        {
            // Create new process.
            Process intelProcess;
            if (solidigm) intelProcess = NewProcess("load -f -ssd " + index, false, solidigm);
            else intelProcess = NewProcess("load -f -intelssd " + index, false, solidigm);
            intelProcess.Start();
            // Output to RichTextBox.
            string output;
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
                form.AppendRtxb(output);
            // Show balloon on Taskbar or Message.
            form.ShowMessage(ToolTipIcon.Info, "Finished!", "Completed Firmware Update.");
            // Enable UI.
            form.SetUIState(true);
            // Update Taskbar text.
            form.UpdateTaskbar(Progress.QuickDiagnostic, ProgressState.Finished);
        }

        /// <summary>
        /// Get SMART information for specified Media Storage Device.
        /// </summary>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        /// <returns>List of <see cref="SMARTinfo"/> with all SMART properties for a Media Storage Device.</returns>
        public static List<SMARTinfo> GetSMART(int index, bool solidigm)
        {
            // Create new process.
            Process intelProcess;
            if (solidigm) intelProcess = NewProcess("show -a -ssd " + index + " -smart IncludeNVMeSmartHealthLog=true", false, solidigm);
            else intelProcess = NewProcess("show -a -smart -intelssd " + index + " IncludeNVMeSmartHealthLog=true", false, solidigm);
            intelProcess.Start();

            List<SMARTinfo> smartList = new List<SMARTinfo>();
            SMARTinfo info = new SMARTinfo();
            string output;
            // Get output and add info to appropriate property.
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
            {
                if (output.Contains(" -"))
                    info.AddPropertyValue(SMARTinfo.Property.Attribute, output.Substring(2, 2));
                else if (output.Contains("Action"))
                    info.AddPropertyValue(SMARTinfo.Property.Action, output.Substring(9));
                else if (output.Contains("Description"))
                    info.AddPropertyValue(SMARTinfo.Property.Description, output.Substring(14));
                else if (output.Contains("ID"))
                    info.AddPropertyValue(SMARTinfo.Property.ID, output.Substring(5));
                else if (output.Contains("Normalized"))
                    info.AddPropertyValue(SMARTinfo.Property.Normalized, output.Substring(13));
                else if (output.Contains("Raw"))
                    info.AddPropertyValue(SMARTinfo.Property.Raw, output.Substring(6));
                else if (output.Contains("Status"))
                    info.AddPropertyValue(SMARTinfo.Property.Status, output.Substring(9));
                else if (output.Contains("Threshold"))
                    info.AddPropertyValue(SMARTinfo.Property.Threshold, output.Substring(12));
                else if (output.Contains("CurrentTemperature"))
                    info.AddPropertyValue(SMARTinfo.Property.Current, output.Substring(21));
                else if (output.Contains("HighestTemperature"))
                    info.AddPropertyValue(SMARTinfo.Property.High, output.Substring(21));
                else if (output.Contains("LowestTemperature"))
                    info.AddPropertyValue(SMARTinfo.Property.Low, output.Substring(20));
                else if (output.Contains("Worst"))
                {
                    info.AddPropertyValue(SMARTinfo.Property.Worst, output.Substring(8));
                    info.FillEmptyValues();
                    smartList.Add(info);
                    info = new SMARTinfo();
                }
            }
            return smartList;
        }

        /// <summary>
        /// Get Sensor information for specified Media Storage Device.
        /// </summary>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="solidigm">Use sst.exe or IntelMAS.exe </param>
        /// <returns>List of <see cref="SensorInfo"/> with all Sensor properties for a Media Storage Device.</returns>
        public static List<SensorInfo> GetSensorInfo(int index, bool solidigm)
        {
            // Create new process.
            Process intelProcess;
            if (solidigm) intelProcess = NewProcess("show -a -ssd " + index + " -sensor", false, solidigm);
            else intelProcess = NewProcess("show -a -sensor -intelssd " + index, false, solidigm);
            intelProcess.Start();

            string output;
            List<SensorInfo> sensorList = new List<SensorInfo>();
            // Get output and add info to appropriate property.
            while ((output = intelProcess.StandardOutput.ReadLine()) != null)
            {
                if (output.Length <= 3) continue;
                sensorList.Add(new SensorInfo(output.Substring(0, output.IndexOf(':') - 1), output.Substring(output.IndexOf(':') + 2)));
            }
            return sensorList;
        }

        /// <summary>
        /// Get Media Storage Devices.
        /// </summary>
        /// <param name="intelExclusive">Specifies wheter to return Intel Storage deivces exclusively.</param>
        /// <returns>List of <see cref="MediaDrive"/> with all Media Storage Devices.</returns>
        public static List<MediaDrive> GetDrives(bool intelExclusive)
        {
            // Check if sst.exe or IntelMAS.exe path is accurate.
            if (!File.Exists(Properties.Settings.Default.MASPath + "\\IntelMAS.exe") && !File.Exists(Properties.Settings.Default.MASPath + "\\sst.exe")) return null;

            int drivesCnt = 0;
            List<MediaDrive> mediaDrives = new List<MediaDrive>();

            // Search for Win32_DiskDrives.
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            // For each ManagementObject in Win32_DiskDrives.
            foreach (ManagementObject managementObject in moSearcher.Get())
            {
                // Make a new MediaDrive.
                MediaDrive newDrive = new MediaDrive(managementObject);
                // Check if non-Intel Drives matter.
                if (intelExclusive && newDrive.Model.Substring(0, 5) == "INTEL" || !intelExclusive)
                {
                    // Add drive to list, update combo boxes increase total drive count.
                    mediaDrives.Add(newDrive);
                    drivesCnt++;
                }
            }
            // If I dont have any drives, show message then exit.
            if (drivesCnt == 0)
            {
                MessageBox.Show("Could not detect any storage media. Try running the application with admin priviliges." +
                    "\nIntel MAS for Windows 7 will now termiante.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(101);
            }
            return mediaDrives;

        }
    }

    /// <summary>
    /// Represents a Media Storage Device.
    /// </summary>
    public class MediaDrive
    {
        #region MediaDrive Properties
        public string Caption { get; }
        public string FirmwareRevision { get; }
        public string InterfaceType { get; }
        public string MediaType { get; }
        public string Model { get; }
        public string Partitions { get; }
        public string SerialNumber { get; }
        public string Size { get; }
        public string Status { get; }
        public string Index { get; }
        #endregion

        public MediaDrive(ManagementObject moDrive)
        {
            Caption = moDrive["Caption"].ToString();
            FirmwareRevision = moDrive["FirmwareRevision"].ToString();
            InterfaceType = moDrive["InterfaceType"].ToString();
            MediaType = moDrive["MediaType"].ToString();
            Model = moDrive["Model"].ToString();
            Partitions = moDrive["Partitions"].ToString();
            SerialNumber = moDrive["SerialNumber"].ToString();
            Size = (decimal.Parse(moDrive["Size"].ToString()) / 1073741824).ToString().Substring(0, 8);
            Status = moDrive["Status"].ToString();
            Index = moDrive["Index"].ToString();
        }
    }

    /// <summary>
    /// Provides access to values of all SMART properties of a <see cref="MediaDrive"/>.
    /// </summary>
    public class SMARTinfo
    {
        /// <summary>
        /// Type of SMART property.
        /// </summary>
        public enum Property
        {
            Action,
            Attribute,
            Description,
            ID,
            Normalized,
            Raw,
            Status,
            Threshold,
            Worst,
            Current,
            High,
            Low
        }

        #region SMARTinfo Properties
        protected string Action { get; set; }
        protected string Attribute { get; set; }
        protected string Description { get; set; }
        protected string ID { get; set; }
        protected string Normalized { get; set; }
        protected string Raw { get; set; }
        protected string Status { get; set; }
        protected string Threshold { get; set; }
        protected string Worst { get; set; }
        protected string Current { get; set; }
        protected string High { get; set; }
        protected string Low { get; set; }
        #endregion

        /// <summary>
        /// Set value of a SMART property.
        /// </summary>
        /// <param name="propertyType">Type of SMART <see cref="Property"/>.</param>
        /// <param name="value">New value of SMART property.</param>
        public void AddPropertyValue(Property propertyType, string value)
        {
            // Just a precaution.
            if (value == null) value = "Unknown";
            switch (propertyType)
            {
                case Property.Action:
                    Action = value;
                    break;
                case Property.Attribute:
                    Attribute = value;
                    break;
                case Property.Description:
                    Description = value;
                    break;
                case Property.ID:
                    ID = value;
                    break;
                case Property.Normalized:
                    Normalized = value;
                    break;
                case Property.Raw:
                    Raw = value;
                    break;
                case Property.Status:
                    Status = value;
                    break;
                case Property.Threshold:
                    Threshold = value;
                    break;
                case Property.Worst:
                    Worst = value;
                    break;
                case Property.Current:
                    Current = value;
                    break;
                case Property.High:
                    High = value;
                    break;
                case Property.Low:
                    Low = value;
                    break;
            }
        }

        /// <summary>
        /// Get value of a SMART property.
        /// </summary>
        /// <param name="propertyType">Type of SMART <see cref="Property"/>.</param>
        public string GetPropertyValue(Property propertyType)
        {
            switch (propertyType)
            {
                case Property.Action:
                    return Action;
                case Property.Attribute:
                    return Attribute;
                case Property.Description:
                    return Description;
                case Property.ID:
                    return ID;
                case Property.Normalized:
                    return Normalized;
                case Property.Raw:
                    return Raw;
                case Property.Status:
                    return Status;
                case Property.Threshold:
                    return Threshold;
                case Property.Worst:
                    return Worst;
                case Property.Current:
                    return Current;
                case Property.High:
                    return High;
                case Property.Low:
                    return Low;
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Fill all empty SMART <see cref="Property"/> values.
        /// </summary>
        public void FillEmptyValues()
        {
            if (string.IsNullOrEmpty(Action)) Action = "Unknown";
            if (string.IsNullOrEmpty(Attribute)) Attribute = "Unknown";
            if (string.IsNullOrEmpty(Description)) Description = "Unknown";
            if (string.IsNullOrEmpty(ID)) ID = "Unknown";
            if (string.IsNullOrEmpty(Normalized)) Normalized = "Unknown";
            if (string.IsNullOrEmpty(Raw)) Raw = "Unknown";
            if (string.IsNullOrEmpty(Status)) Status = "Unknown";
            if (string.IsNullOrEmpty(Threshold)) Threshold = "Unknown";
            if (string.IsNullOrEmpty(Worst)) Worst = "Unknown";
            if (string.IsNullOrEmpty(Current)) Status = "Unknown";
            if (string.IsNullOrEmpty(High)) Threshold = "Unknown";
            if (string.IsNullOrEmpty(Low)) Worst = "Unknown";
        }
    }

    /// <summary>
    /// Provides access to values of all properties of a <see cref="MediaDrive"/>'s sensors.
    /// </summary>
    public class SensorInfo
    {
        public string Property { get; }
        public string Value { get; }

        public SensorInfo(string property, string value)
        {
            Property = property;
            Value = value;
        }
    }
}