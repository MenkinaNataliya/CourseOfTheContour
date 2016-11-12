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
                for (var i = 0; i < bitmap.Width; i++)
                    for (var j = 0; j < bitmap.Height; j++)
                        bitmap.SetPixel(i, j, Color.FromArgb(48,15,198));
                bitmap.Save(@"EndFisrtTest.png");
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            
            using (timer.Continue())
            {
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for (var i = 0; i < bitmap.Width; i++)
                        for (var j = 0; j < bitmap.Height; j++)
                            bitmapEditor.SetPixel(i, j, 185, 100, 19);
                }
                bitmap.Save(@"EndSecondTest.png");
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }

    }
}
