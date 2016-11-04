using System;
using System.Collections.Generic;
using System.Reflection;
using Framework;


namespace Application
{
    public class Program
    {

        private static List<IPlugin> GetPlugin(string filename)
        {
            var file = Assembly.LoadFile(filename);

           var newPlugin = new List<IPlugin>();

            foreach (var type in file.GetTypes())
            {
                
                if (type.IsClass && type.IsPublic)
                {
                    newPlugin.Add((IPlugin)Activator.CreateInstance(type));
                }
            }
           
            return newPlugin.Count == 0 ? null : newPlugin;
        }

        static void Main(string[] args)
        {
            const string plugin1Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin1/bin/Debug/Plugin1.dll";
            const string plugin2Dll = "E:/учеба/C#/CourseOfTheContour.git/SixthWeek/Framework/Plugin2/bin/Debug/Plugin2.dll";

            var plugin1Obj = GetPlugin(plugin1Dll);
            var plugin2Obj = GetPlugin(plugin2Dll);

            foreach(var item in plugin1Obj)
                Console.WriteLine(item.Name);
            foreach (var item in plugin2Obj)
                Console.WriteLine(item.Name);
            Console.ReadLine();
           

        }
    }
}
