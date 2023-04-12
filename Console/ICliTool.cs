using System.Collections.Generic;
using MAS7.Models;

namespace MAS7.Console
{
    public interface ICliTool
    {
        /// <summary>
        /// Run SSD optimizer.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>Used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="showCommandLine">Specifies wheter a Command Line window is used for output.</param>
        void RunOptimizer(Forms.Main form, int index, bool showCommandLine);

        /// <summary>
        /// Run Quick Scan Diagnostic.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>Used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="showCommandLine">Specifies wheter a Command Line window is used for output.</param>
        void RunQuickTest(Forms.Main form, int index, bool showCommandLine);

        /// <summary>
        /// Run Full Scan Diagnostic.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>Used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        /// <param name="showCommandLine">Specifies wheter a Command Line window is used for output.</param>
        void RunFullTest(Forms.Main form, int index, bool showCommandLine);

        /// <summary>
        /// Run Firmware Update.
        /// </summary>
        /// <param name="form">Instance of Main Form.
        /// <para>Used for GUI updates.</para></param>
        /// <param name="index">Media Storage Device index.</param>
        void RunFirmwareUpdate(Forms.Main form, int index);

        /// <summary>
        /// Get SMART information for specified Media Storage Device.
        /// </summary>
        /// <param name="index">Media Storage Device index.</param>
        /// <returns>List of <see cref="SMARTinfo"/> with all SMART properties for a Media Storage Device.</returns>
        List<SMARTinfo> GetSMART(int index);

        /// <summary>
        /// Get Sensor information for specified Media Storage Device.
        /// </summary>
        /// <param name="index">Media Storage Device index.</param>
        /// <returns>List of <see cref="SensorInfo"/> with all Sensor properties for a Media Storage Device.</returns>
        List<SensorInfo> GetSensorInfo(int index);

        /// <summary>
        /// Get Media Storage Devices.
        /// </summary>
        /// <param name="intelExclusive">Specifies wheter to return Intel Storage deivces exclusively.</param>
        /// <returns>List of <see cref="MediaDrive"/> with all Media Storage Devices.</returns>
        List<MediaDrive> GetDrives(bool intelExclusive);

    }
}
