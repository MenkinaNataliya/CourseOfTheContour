using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processor1
{

    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public class DataModel : IObservable
    {
        private Dictionary<int, int> table = new Dictionary<int, int>();

        private readonly List<IObserver> observers;

        public DataModel()
        {
            observers = new List<IObserver>();
        }
        public void Put(int row, int column, int value)
        {
            table[row*10 + column] = value;
            NotifyObservers();
        }

       

        public void InsertRow(int rowIndex)
        {
            this.table = Insert(rowIndex, true);
            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            this.table = Insert(columnIndex, false);
            NotifyObservers();
        }

        public int Get(int row, int column)
        {
            int result;
            if (table.TryGetValue(row * 10 + column, out result))
            {
                return table[row * 10 + column];
            }
            
            return 0;
        }


        private Dictionary<int, int> Insert(int index, bool flag)
        {
            var newTable = new Dictionary<int, int>();
            foreach (var key in table.Keys)
            {
                int comparisonValue;
                int valueForAdd;
                if (flag)
                {
                    comparisonValue = key / 10;
                    valueForAdd = 10;
                }
                else
                {
                    comparisonValue = key % 10;
                    valueForAdd = 1;
                }
                if (comparisonValue >= index)
                {
                    newTable[key + valueForAdd] = table[key];
                    int result;
                    if (!newTable.TryGetValue(key, out result))
                    {
                        newTable[key] = 0;
                    }
                }
                else
                {
                    newTable[key] = table[key];
                }
            }
            return newTable;
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }

        
    }
   
}
