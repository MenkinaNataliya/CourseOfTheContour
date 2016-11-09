using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication1
{
    class Program
    {
    
        static void Main(string[] args)
        {
            var timer = new Timer();
           
            var bitmap = (Bitmap)Bitmap.FromFile("test.png");
            using (timer.Start())
            {
                for (var i = 0; i < 100; i++)
                    for (var j = 0; j < 100; j++)
                        bitmap.SetPixel(i, j, Color.FromArgb(48,50,98));
                bitmap.Save(@"EndFisrtTest.png");
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            
            using (timer.Continue())
            {
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for (var i = 0; i < 100; i++)
                        for (var j = 0; j < 100; j++)
                            bitmapEditor.SetPixel(i, j, 185, 200, 149);
                }
                bitmap.Save(@"EndSecondTest.png");
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }

    }
}
