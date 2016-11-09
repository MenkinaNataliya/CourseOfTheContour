using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
    
        static void Main(string[] args)
        {
            var timer = new Timer();
            var a = 0;
            using (timer.Start())
            {
                
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            a = 0;
            using (timer.Continue())
            {
               
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
