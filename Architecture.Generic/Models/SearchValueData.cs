namespace Architecture.Generic.Models
{
    public class SearchValueData
    {
        public SearchValueData()
        {
            DataType = DataTypeString;
        }
        public SearchValueData(string name, string value, bool isEqual = false, bool isNotEqual = false, bool isNull = false)
        {
            Name = name;
            Value = value;
            IsEqual = isEqual;
            IsNotEqual = isNotEqual;
            IsNull = isNull;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsEqual { get; set; }
        public bool IsNotEqual { get; set; }
        public bool IsNull { get; set; }
        public string DataType { get; set; }

        public const string DataTypeString = "string";
        public const string DataTypeBoolean = "bool";

    }
}
