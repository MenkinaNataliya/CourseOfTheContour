using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Timer : IDisposable
    {
        private Stopwatch stopWatch;
        public  long ElapsedMilliseconds { get { return stopWatch.ElapsedMilliseconds; } }



        public Timer()
        {
            stopWatch = new Stopwatch();
        }

        public IDisposable Continue()
        {
            stopWatch.Start();
            return this;
        }


        public IDisposable Start()
        {
            stopWatch.Restart();
            stopWatch.Start();
            return this;
        }


        private bool isDisposed = false;

        ~Timer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //финализатор не будет вызываться
        }

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (!isDisposed)
            {
                stopWatch.Stop();
                isDisposed = true;
            }
        }

    }
}
