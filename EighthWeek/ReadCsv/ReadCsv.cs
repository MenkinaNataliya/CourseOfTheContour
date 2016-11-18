using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;


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
                    if (str == null) yield break;
                    
                    var line = str.Split(',');
                    for (var j = 0; j < line.Length; j++)
                        if (line[j] == "NA") line[j] = null;
                    yield return line;
                }
        }

        public static IEnumerable<T> ReadCsv2<T>(string filename) where T : new()
        {
            List<MemberInfo> members = new List<MemberInfo>();

            using (var stream = new StreamReader(filename))
            {
                
                var tmp = stream.ReadLine()?.Replace("\"", "");//прочитали первую строку с названием столбцов
                if(tmp==null) yield break;
                
                var columnNames = tmp.Split(',');
                var type = typeof(T);
                foreach (var column in columnNames)
                {
                    MemberInfo member = type.GetField(column, BindingFlags.NonPublic | BindingFlags.Instance);
                    member = member ?? type.GetProperty(column, BindingFlags.NonPublic | BindingFlags.Instance);
                    members.Add(member);
                }

                while (true)
                {
                    var line = stream.ReadLine();
                    if (line == null) yield break;

                    var result = new T();
                    var values = line.Split(',');

                    for (var i = 0; i < values.Length; ++i)
                    {
                        if (members[i] != null)
                        {
                            if (members[i].MemberType == MemberTypes.Field)
                            {
                                var member = (FieldInfo) members[i];
                                member.SetValue(result, (T)setValue(values[i]));
                            }
                            if (members[i].MemberType == MemberTypes.Property)
                            {
                                var member = (PropertyInfo) members[i];
                                member.SetValue(result, (T)setValue(values[i]));
                            }
                        }
                    }
                    yield return result;
                }
            }
        }

        private static object setValue(string value)
        {
            if (value == "NA")
                return null;
            int intNum;
            if (int.TryParse(value, out intNum))
                return intNum;
            double doubleNum;
            if (double.TryParse(value, out doubleNum))
                return doubleNum;
            return value;
        }

        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string filename)
        {     
            using (var stream = new StreamReader(filename))
            {
                var tmp = stream.ReadLine()?.Replace("\"", "");
                if(tmp==null) yield break;

                var columnNames = tmp.Split(','); //прочитали первую строку с названием столбцов

                while (true)
                {
                    var line = stream.ReadLine();
                    if (line == null) yield break;

                    var result = new Dictionary<string, object>();
                   
                    var values = line.Split(',');

                    for (var i = 0; i < values.Length; ++i)
                    {
                        result[columnNames[i]] = setValue(values[i]);
                    }
                    yield return result;
                }
            }   
        }
       
    }
}