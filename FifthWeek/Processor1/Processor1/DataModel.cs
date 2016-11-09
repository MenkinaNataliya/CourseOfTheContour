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
        private List<List<int>> table =new List<List<int>>();
        private int width;

        private readonly List<IObserver> observers;

        public DataModel(int width, int height)
        {
            this.width = width;
            observers = new List<IObserver>();

            for (var i = 0; i < height; i++)
            {
                table.Add(new List<int>());
                for (int j = 0; j < width; j++)
                    table[i].Add(new int());
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
                table[rowIndex-1].Add(new int());

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
