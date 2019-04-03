namespace MLE_UE2
{
    public struct DataSetHeader
    {
        public HeaderValue[] headers;
    }
    
    public struct HeaderValue
    {
        public HeaderValue(int id, string value)
        {
            Id = id;
            Value = value;
        }
        public double SelectEntry(DataEntry data) => data.Data[Id];
        
        private int Id { get; } 
        public string Value { get;  } 
    }
}