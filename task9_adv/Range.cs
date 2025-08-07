using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_adv
{
    internal class Range<T> where T:IComparable
    {
        public T Min { get; }
        public T Max { get; }
        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("Min should not be greater than Max");

            Min = min;
            Max = max;
        }
        public bool IsInRange(T value)
        {
            if (value == null)
                return false;

            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }
        public dynamic Length()
        {
            // We use dynamic to allow subtraction if T supports it
            dynamic min = Min;
            dynamic max = Max;
            return max - min;
        }
    }
}
