namespace MAS7.Drives
{
    /// <summary>
    /// Provides access to values of all SMART properties of a <see cref="MediaDrive"/>.
    /// </summary>
    public class SmartInfo
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
}
