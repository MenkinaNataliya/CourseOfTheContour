using System;
using System.Reflection;


namespace Application
{
    public class Program
    {

        private static object GetPlugin(string filename, string pluginName)
        {
            var file = Assembly.LoadFile(filename);
            var newPlugin = new object();

            foreach (var type in file.GetTypes())
            {
                if (type.IsClass && type.IsPublic)
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var inter in interfaces)
                    {
                        if (inter.Name == "IPlugin")
                        {
                            var сonstructor = type.GetConstructor(new[] {typeof(string)});
                            if (сonstructor != null) newPlugin = сonstructor.Invoke(new object[] {pluginName});
                        }
                    }
                }
            }
            return newPlugin;
        }

        static void Main(string[] args)
        {
            const string plugin1Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin1/bin/Debug/Plugin1.dll";
            const string plugin2Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin2/bin/Debug/Plugin2.dll";

            var plugin1Obj = GetPlugin(plugin1Dll, "Plugin1");
            var plugin2Obj = GetPlugin(plugin2Dll, "Plugin2");
            Console.WriteLine(plugin1Obj.GetType().GetProperty("Name").GetValue(plugin1Obj));
            Console.WriteLine(plugin2Obj.GetType().GetProperty("Name").GetValue(plugin2Obj));
            Console.ReadLine();
           

        }
    }
}
