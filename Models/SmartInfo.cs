namespace MAS7.Models
{
    /// <summary>
    /// Provides access to values of all SMART properties of a <see cref="MediaDrive"/>.
    /// </summary>
    public class SMARTinfo
    {
        public string Action { get; set; }
        public string Attribute { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string Normalized { get; set; }
        public string Raw { get; set; }
        public string Status { get; set; }
        public string Threshold { get; set; }
        public string Worst { get; set; }
        public string Current { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
    }

}
