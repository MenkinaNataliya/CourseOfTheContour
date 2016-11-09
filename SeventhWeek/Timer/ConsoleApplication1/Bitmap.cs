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
        private readonly byte[] valuesPixel;
        public BitmapEditor(Bitmap bitMap)
        {
            bitmap = bitMap;

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitMap.PixelFormat);

            valuesPixel = new byte[bitmapData.Stride * bitmap.Height];
            Marshal.Copy(bitmapData.Scan0, valuesPixel, 0, bitmapData.Stride * bitmap.Height);
        }

        ~BitmapEditor()
        {
             Dispose(false);
        }

        public void SetPixel(int x, int y, int r, int g, int b)
        {
            int index = bitmapData.Stride * y + 3 * x;
            valuesPixel[index + 2] = (byte)r; 
            valuesPixel[index + 1] = (byte)g;
            valuesPixel[index + 0] = (byte)b;

        }

        private bool isDisposed = false;


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (!isDisposed)
            {
                Marshal.Copy(valuesPixel, 0, bitmapData.Scan0, bitmapData.Stride * bitmap.Height);
                bitmap.UnlockBits(bitmapData);
                isDisposed = true;
            }
        }
    }
}
