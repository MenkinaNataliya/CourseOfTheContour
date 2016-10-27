using Processor1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor1
{
    public class TransactionProcessor<TParameters, TParametersResult>
    {
        public TransactionProcessor(Func<TParameters, bool> checkFunc, Func<TParameters, TParametersResult> registerFunc, Action<TParametersResult> saveFunc)
        {
            this.checkFunc = checkFunc;
            this.registerFunc = registerFunc;
            this.saveFunc = saveFunc;
        }

        private Func<TParameters, bool> checkFunc;
        private Func<TParameters, TParametersResult> registerFunc;
        private Action<TParametersResult> saveFunc;

        public TParametersResult Process(TParameters request)
        {
            if (!checkFunc(request))
                throw new ArgumentException();
            var result = registerFunc(request);
            saveFunc(result);
            return result;
        }

    }
}
