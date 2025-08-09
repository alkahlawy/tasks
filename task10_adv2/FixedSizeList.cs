using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_adv2
{
    internal class FixedSizeList<T>
    {
        private T[] items;
        private int count = 0;
        private int capacity;

        public FixedSizeList(int _capacity)
        {
            if (_capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            capacity = _capacity;
            items = new T[_capacity];
        }

        public void Add(T item)
        {
            if (count >= capacity)
                throw new InvalidOperationException("List is full. Cannot add more elements.");

            items[count] = item;
            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");

            return items[index];
        }

        public int Count => count;
        public int Capacity => capacity;
    }
}
