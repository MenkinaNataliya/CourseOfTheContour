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


        public void SetPixel(int x, int y, int r, int g, int b)
        {
            IntPtr ptr = bitmapData.Scan0 + (bitmapData.Width * y + x) * 3;
            byte[] valuesPixel = new byte[3];

            valuesPixel[0] = (byte)b;
            valuesPixel[1] = (byte)g;
            valuesPixel[2] = (byte)r;

            Marshal.Copy(valuesPixel, 0, ptr,3);
        }


        public void Dispose()
        {
            bitmap.UnlockBits(bitmapData);
        }

    }
}
