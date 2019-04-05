using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace MLE_UE2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rdr = new StreamReader(args[0]))
            using (var csv = new CsvReader(rdr))
            {
                DataSetHeader? header = null;
                var dataEntries = new List<DataEntry>();
                for (var i = 0; csv.Read(); i++)
                {

                    if (i == 0) header = readHeader(csv);

                    var data = new double[header?.Headers.Length - 1 ?? 0];

                    for (var fieldLoc = 0; fieldLoc < data.Length; fieldLoc++)
                    {
                        csv.TryGetField(fieldLoc, out double field);
                        data[fieldLoc] = field;
                    }

                    csv.TryGetField(data.Length, out string label);
                    dataEntries.Add(new DataEntry(label, data));
                }

                if (header.HasValue)
                {
                    var ds = new DataSet(header.Value, new DataEntries(dataEntries));
                }
            }
        }


        static DataSetHeader readHeader(IReader csv)
        {
            csv.ReadHeader();
            var headerList = new List<HeaderValue>();
            for(var i = 0; csv.TryGetField(i, out string val); i++)
            {
                headerList.Add(new HeaderValue(i, new string(val)));
            }
            csv.Read();
            return new DataSetHeader(headerList.ToArray());
        }
    }
}
