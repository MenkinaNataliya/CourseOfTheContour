using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace ReadCsv
{
    public class ReadCsv
    {
        private static IEnumerable<string[]> ReadFile(string fileName)
        {
            using (var textReader = new StreamReader(fileName))
                while (true)
                {
                    var row = textReader.ReadLine();
                    if (row == null) break;
                    var values = row.Split(',');
                    yield return values;
                }
        }

        public static IEnumerable<string[]> ReadCsv1(string fileName)
        {
            foreach (var line in ReadFile(fileName))
            {
                for (var j = 0; j < line.Length; j++)
                    if (line[j] == "NA") line[j] = null;
                yield return line;
            }
        }

        public static IEnumerable<T> ReadCsv2<T>(string filename) where T : new()
        {
            List<MemberInfo> members = new List<MemberInfo>();
            string[] columnNames = null;
            foreach (var line in ReadFile(filename))
            {
                var type = typeof(T);
                if (columnNames == null)
                {
                    columnNames = line;
                    foreach (var column in columnNames)
                    {
                        MemberInfo member = type.GetField(column, BindingFlags.NonPublic | BindingFlags.Instance);
                        member = member ?? type.GetProperty(column, BindingFlags.NonPublic | BindingFlags.Instance);
                        members.Add(member);
                    }
                }
                else
                {
                    var result = new T();
                    for (var i = 0; i < line.Length; ++i)
                    {
                        if (members[i] == null) continue;
                        if (members[i].MemberType == MemberTypes.Field)
                        {
                            var member = (FieldInfo) members[i];
                            member.SetValue(result, (T) SetValue(line[i]));
                        }
                        if (members[i].MemberType == MemberTypes.Property)
                        {
                            var member = (PropertyInfo) members[i];
                            member.SetValue(result, (T) SetValue(line[i]));
                        }
                    }
                    yield return result;
                }
            }
        }

        private static object SetValue(string value)
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
            string[] columnNames = null;
            foreach (var line in ReadFile(filename))
            {
                if (columnNames == null) columnNames = line;
                else
                {
                    var result = new Dictionary<string, object>();
                    for (var i = 0; i < line.Length; ++i)
                    {
                        result[columnNames[i]] = SetValue(line[i]);
                    }
                    yield return result;
                }
            }
        }

        public static IEnumerable<dynamic> ReadCsv4(string filename)
        {
            string[] columnNames = null;
            foreach (var line in ReadFile(filename))
            {
                if (columnNames == null) columnNames = line;
                else
                {
                    dynamic result = new ExpandoObject();
                    IDictionary<string, dynamic> obj = result;

                    for (var i = 0; i < line.Length; ++i)
                    {
                        obj.Add(columnNames[i], SetValue(line[i]));
                    }
                    yield return result;
                }
            }
        }
    }
}