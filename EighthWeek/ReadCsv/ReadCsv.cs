using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsv
{
    public class ReadCsv
    {
        public static string[] lines = File.ReadAllLines("airquality.csv");

        public static IEnumerable<string[]> ReadCsv1
        {
            get
            {
                foreach (var t in lines)
                {
                    var line = t.Split(',');
                    for (var j = 0; j < line.Length; j++)
                    {
                        if (line[j] == "NA") line[j] = null;
                    }
                    yield return line;
                }
            }
        }

    }
}
