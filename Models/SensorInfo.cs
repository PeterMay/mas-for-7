namespace MAS7.Models
{
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
