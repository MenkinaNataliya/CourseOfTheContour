using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsv
{
    public class ReadCsv
    {

        public static IEnumerable<string[]> ReadCsv1(string filename)
        {

                using (var stream = new StreamReader(filename))
                    while (true)
                    {
                        var str = stream.ReadLine();
                        if (str == null)
                        {
                            stream.Close();
                            yield break;
                        }
                        var line = str.Split(',');
                        for (var j = 0; j < line.Length; j++)
                        {
                            if (line[j] == "NA") line[j] = null;
                        }
                        yield return line;
                    }

        }
    }
}
