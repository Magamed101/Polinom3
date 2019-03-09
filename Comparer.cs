using System;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    public class LexicographicalOrder<T> : IComparer<T> 
    {

        public int Compare(T x, T y)
        {
            var obj1 = x as PolinomItem;
            var obj2 = y as PolinomItem;
            return obj2.Degree.CompareTo(obj1.Degree);
        }

    }
}
