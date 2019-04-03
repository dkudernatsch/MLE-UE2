using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MLE_UE2
{
    public struct DataSet
    {
        public DataSetHeader Header { get; }
        public DataEntries DataEntries { get; }
    }

    public class DataEntries
    {
        private List<DataEntry> DataEntryList { get; set; } = new List<DataEntry>();
        public DataEntry this[int i] => DataEntryList[i];
        
    }
    
    public struct DataEntry
    {
        DataEntry(string label, double[] data)
        {
            Data = data;
            Label = label;
        }

        public double this[HeaderValue i] => i.SelectEntry(this);
        
        public double[] Data { get; }
        public string Label { get; }
    }
}