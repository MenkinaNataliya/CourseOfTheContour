using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{

    public class BitmapEditor:IDisposable
    {
        private readonly Bitmap bitmap;
        private readonly BitmapData bitmapData;
        public BitmapEditor(Bitmap bitMap)
        {
            bitmap = bitMap;

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitMap.PixelFormat);

            
        }


        public void SetPixel( int x, int y, int r, int g, int b)
        {
          
            var color = Color.FromArgb(255, r,g,b);
            Marshal.WriteByte(bitmapData.Scan0, (byte)(color.ToArgb() << 4));
          
        }

        public void Dispose()
        {
            bitmap.UnlockBits(bitmapData);
        }

    }
}
