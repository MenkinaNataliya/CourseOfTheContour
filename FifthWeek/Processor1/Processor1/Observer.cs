using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor1
{

    public interface IObserver
    {
        void Update();
    }
    class LoggingSystem : IObserver
    {
        public void Update()
        {
        }
    }

    class DisplaySystem : IObserver 
    {
        public void Update()
        {
        }
    }
}
