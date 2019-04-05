using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MLE_UE2
{
    public struct DataSet
    {
        public DataSet(DataSetHeader header, DataEntries dataEntries)
        {
            Header = header;
            DataEntries = dataEntries;
        }

        public DataSetHeader Header { get; }
        public DataEntries DataEntries { get; }
    }

    public class DataEntries
    {
        public DataEntries(List<DataEntry> dataEntries)
        {
            DataEntryList = dataEntries;
        }

        private List<DataEntry> DataEntryList { get; }
        public DataEntry this[int i] => DataEntryList[i];

    }

    public struct DataEntry
    {
        public DataEntry(string label, double[] data)
        {
            Data = data;
            Label = label;
        }

        public double this[HeaderValue i] => i.SelectEntry(this);

        public double[] Data { get; }
        public string Label { get; }
    }
}
