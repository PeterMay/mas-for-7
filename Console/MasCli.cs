using System.Management;
using System.Collections.Generic;
using System.Diagnostics;
using MAS7.Enums;
using MAS7.Models;

namespace MAS7.Console
{
    /// <summary>
    /// <see langword="static"/> Provides access to Intel/Solidigm Memory and Storage CLI functions.
    /// </summary>
    public class MasCli : ICliTool
    {

        /// <summary>
        /// Start new Process
        /// </summary>
        /// <param name="arguments">Arguments passed on Process. </param>
        /// <param name="showCommandLine">Specifies wheter a Command Line window is used for output. </param>
        /// <returns>Appropriate Process to run MAS tasks.</returns>
        private Process NewProcess(string arguments, bool showCommandLine)
        {
            Process process = new Process();
            process.StartInfo.FileName = Properties.Settings.Default.MASPath + "\\IntelMAS.exe";
            process.StartInfo.Arguments = arguments;
            if (showCommandLine)
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
            }
            else
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
            }
            return process;
        }

        /// <inheritdoc />
        public void RunOptimizer(Forms.Main form, int index, bool showCommandLine)
        {
            Process process = NewProcess("start -intelssd " + index + " -optimizer", showCommandLine);
            process.Start();
            if (showCommandLine)
            {
                process.WaitForExit();
                return;
            }

            string output;
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                // If output contains "Status", then Process is finished.
                if (output.Contains("Status")) break;
                // If output contains "Optimizing", then update progress bar value.
                if (output.Contains("Optimizing"))
                    form.SetProgressValue(Progress.Optimization, int.Parse(output.Substring(12, output.Length - 13)));
            }

            form.ShowMessage(System.Windows.Forms.ToolTipIcon.Info, "Finished!", output);
            form.SetProgressValue(Progress.Optimization, 0);
            form.UpdateTaskbar(Progress.Optimization, ProgressState.Finished);
        }

        /// <inheritdoc />
        public void RunQuickTest(Forms.Main form, int index, bool showCommandLine)
        {
            // Create new process.
            Process process = NewProcess("start -scan -intelssd " + index.ToString() + " FullScan = false IncludeSystemInfo = true", 
                showCommandLine);
            process.Start();
            if (showCommandLine)
            {
                process.WaitForExit();
                return;
            }

            string output, result = "";
            bool log = false;
            form.SetProgressValue(Progress.QuickDiagnostic, 1);
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                // If output contains "- Scan", then start logging progress.
                if (output.Contains("- Scan"))
                {
                    form.SetProgressValue(Progress.QuickDiagnostic, 0);
                    log = true;
                }
                if (log && output.Length > 10) result = result + output + "\n";
            }

            form.ShowMessage(System.Windows.Forms.ToolTipIcon.Info, "Finished!", result, true);
            form.UpdateTaskbar(Progress.QuickDiagnostic, ProgressState.Finished);
        }

        /// <inheritdoc />
        public void RunFullTest(Forms.Main form, int index, bool showCommandLine)
        {
            Process process = NewProcess("start -scan -intelssd " + index.ToString() + " FullScan = true IncludeSystemInfo = true", 
                showCommandLine);
            process.Start();
            if (showCommandLine)
            {
                process.WaitForExit();
                return;
            }

            string output, result = "";
            bool log = false;
            form.SetProgressValue(Progress.QuickDiagnostic, 1);
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                // If output contains "- Scan", then start logging progress.
                if (output.Contains("- Scan"))
                {
                    form.SetProgressValue(Progress.QuickDiagnostic, 0);
                    log = true;
                }
                if (log && output.Length > 10) result = result + output + "\n";
            }

            form.ShowMessage(System.Windows.Forms.ToolTipIcon.Info, "Finished!", output);
            form.UpdateTaskbar(Progress.FirmwareUpdate, ProgressState.Finished);
        }

        /// <inheritdoc />
        public void RunFirmwareUpdate(Forms.Main form, int index)
        {
            Process process = NewProcess("load -f -intelssd " + index, false);
            process.Start();

            string output;
            while ((output = process.StandardOutput.ReadLine()) != null)
                form.AppendFirmwareRtxb(output);

            form.ShowMessage(System.Windows.Forms.ToolTipIcon.Info, "Finished!", "Completed Firmware Update.");
            form.UpdateTaskbar(Progress.QuickDiagnostic, ProgressState.Finished);
        }

        /// <inheritdoc />
        public List<SMARTinfo> GetSMART(int index)
        {
            Process process = NewProcess("show -a -smart -intelssd " + index + " IncludeNVMeSmartHealthLog=true", 
                false);
            process.Start();

            List<SMARTinfo> smartList = new List<SMARTinfo>();
            SMARTinfo info = new SMARTinfo();
            string output;
            // Get output and add info to appropriate property.
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                if (output.Contains(" -"))
                    info.Attribute = output.Substring(2, 2);
                else if (output.Contains("Action"))
                    info.Action = output.Substring(9);
                else if (output.Contains("Description"))
                    info.Description = output.Substring(14);
                else if (output.Contains("ID"))
                    info.ID = output.Substring(5);
                else if (output.Contains("Normalized"))
                    info.Normalized = output.Substring(13);
                else if (output.Contains("Raw"))
                    info.Raw = output.Substring(6);
                else if (output.Contains("Status"))
                    info.Status = output.Substring(9);
                else if (output.Contains("Threshold"))
                    info.Threshold = output.Substring(12);
                else if (output.Contains("CurrentTemperature"))
                    info.Current = output.Substring(21);
                else if (output.Contains("HighestTemperature"))
                    info.High = output.Substring(21);
                else if (output.Contains("LowestTemperature"))
                    info.Low = output.Substring(20);
                else if (output.Contains("Worst"))
                {
                    info.Worst = output.Substring(8);
                    smartList.Add(info);
                    info = new SMARTinfo();
                }
            }
            return smartList;
        }

        /// <inheritdoc />
        public List<SensorInfo> GetSensorInfo(int index)
        {
            Process process = NewProcess("show -a -sensor -intelssd " + index, false);
            process.Start();

            string output;
            List<SensorInfo> sensorList = new List<SensorInfo>();
            // Get output and add info to appropriate property.
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                if (output.Length <= 3 || output.Contains("Property not found")) continue;
                sensorList.Add(new SensorInfo(
                    output.Substring(0, output.IndexOf(':') - 1),
                    output.Substring(output.IndexOf(':') + 2)));
            }
            return sensorList;
        }

        /// <inheritdoc />
        public List<MediaDrive> GetDrives(bool intelExclusive)
        {
            int drivesCnt = 0;
            List<MediaDrive> mediaDrives = new List<MediaDrive>();

            // Search for Win32_DiskDrives.
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            // For each ManagementObject in Win32_DiskDrives.
            foreach (ManagementObject managementObject in moSearcher.Get())
            {
                MediaDrive newDrive = new MediaDrive(managementObject);
                // Check if non-Intel Drives matter.
                if (intelExclusive && newDrive.Model.Substring(0, 5) == "INTEL" || !intelExclusive)
                {
                    mediaDrives.Add(newDrive);
                    drivesCnt++;
                }
            }
            return mediaDrives;
        }

    }

}