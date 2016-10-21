using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{

    public class Processor<TEngine, TEntity, TLogger>
    {
    }

    public class ProcessorBuilder
    {
        public static ProcessorWithEngine<TEngine> CreateEngine<TEngine>()
        {
            return new ProcessorWithEngine<TEngine>();
        }

    }

    public class ProcessorWithEngine<TEngine>
    {
        public ProcessorWithEntity<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorWithEntity<TEngine, TEntity>();
        }
    }

    public class ProcessorWithEntity<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
