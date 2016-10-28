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
        //private Dictionary<int, int> table = new Dictionary<int, int>();
        private List<List<int>> table =new List<List<int>>();
        private int width;

        private readonly List<IObserver> observers;

        public DataModel(int width, int height)
        {
            this.width = width;
            observers = new List<IObserver>();

            for (var i = 0; i < height; i++)
            {
                table.Add(new List<int>(width));
                for (int j = 0; j < width; j++)
                {
                    table[i].Add(new int());
                }
                
            }
               
            
        }
        public void Put(int row, int column, int value)
        {
            
            table[row-1][column-1] = value;
            NotifyObservers();
        }


        public void InsertRow(int rowIndex)
        {
            table.Insert(rowIndex-1, new List<int>());
            for (var i = 0; i < width; i++)
            {
                table[rowIndex-1].Add(new int());
            }

            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            foreach (var row in table)
                row.Insert(columnIndex-1, default(int));

            width++;
            NotifyObservers();
        }

        public int Get(int row, int column)
        {
          return table[row-1 ][column-1];
        }


        //private Dictionary<int, int> Insert(int index, bool flag)
        //{
        //    var newTable = new Dictionary<int, int>();
        //    foreach (var key in table.Keys)
        //    {
        //        int comparisonValue;
        //        int valueForAdd;
        //        if (flag)
        //        {
        //            comparisonValue = key / 10;
        //            valueForAdd = 10;
        //        }
        //        else
        //        {
        //            comparisonValue = key % 10;
        //            valueForAdd = 1;
        //        }
        //        if (comparisonValue >= index)
        //        {
        //            newTable[key + valueForAdd] = table[key];
        //            int result;
        //            if (!newTable.TryGetValue(key, out result))
        //            {
        //                newTable[key] = 0;
        //            }
        //        }
        //        else
        //        {
        //            newTable[key] = table[key];
        //        }
        //    }
        //    return newTable;
        //}
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
