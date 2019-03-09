using System;
using System.Linq;

namespace Program
{
    class PolinomItem
    {
        public int Coefficient;
        public Degree Degree;

        public PolinomItem(int[] data)
        {
            Coefficient = data[0];
            Degree = new Degree(data.Skip(1).ToArray());
        }

        public override string ToString()
        {
            var coef = Coefficient < 0 ? $"({Coefficient.ToString()})" : Coefficient.ToString();
            return $"{coef} * {Degree.ToString()}";
        }


    }

}
