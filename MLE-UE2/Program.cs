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
                for (var i = 0; csv.Read(); i++)
                {
                    
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
            return new DataSetHeader
            {
                headers = headerList.ToArray()
            };
        }
    }
}
