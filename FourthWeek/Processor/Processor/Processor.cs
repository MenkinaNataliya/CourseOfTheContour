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

    public class Processor
    {
        public static Engine<TEngine> CreateEngine<TEngine>()
        {
            return new Engine<TEngine>();
        }

    }

    public class Engine<TEngine>
    {
        public Entity<TEngine, TEntity> For<TEntity>()
        {
            return new Entity<TEngine, TEntity>();
        }
    }

    public class Entity<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
