using System.Management;

namespace MAS7.Drives
{
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
}
