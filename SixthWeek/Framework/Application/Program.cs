using System;
using System.Reflection;
using Framework;


namespace Application
{
    public class Program
    {

        private static IPlugin GetPlugin(string filename)
        {
            var file = Assembly.LoadFile(filename);

            object newPlugin = null;

            foreach (var type in file.GetTypes())
            {
                
                if (type.IsClass && type.IsPublic)
                {
                    newPlugin = Activator.CreateInstance(type);
                }
            }
            return (IPlugin)((IPlugin)newPlugin == null ? null : newPlugin);
        }

        static void Main(string[] args)
        {
            const string plugin1Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin1/bin/Debug/Plugin1.dll";
            const string plugin2Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin2/bin/Debug/Plugin2.dll";

            var plugin1Obj = GetPlugin(plugin1Dll);
            var plugin2Obj = GetPlugin(plugin2Dll);

            Console.WriteLine(plugin1Obj.Name);
            Console.WriteLine(plugin2Obj.Name);
            Console.ReadLine();
           

        }
    }
}
