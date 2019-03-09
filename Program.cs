using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    class Polinom3 : IEnumerable<PolinomItem>
    {
        public List<PolinomItem> Polinom { get; set; }

        public Polinom3(string fileName)
        {
            Polinom = new List<PolinomItem>();
            var delimiterChars = new char[] { ' ', ',', '.', ':', ';', '\t', '\n' };
            var data = fileName.Split(delimiterChars).Select(e => int.Parse(e)).ToArray();
            for (var i = 0; i < data.Length; i += 4) 
            {
                Polinom.Add(new PolinomItem(data.Skip(i).Take(4).ToArray()));
            }
            Sort();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Polinom.Count; i++) 
            {
                var sign = i != Polinom.Count - 1 ? "+" : "";
                result.Append(Polinom[i] + $" {sign} ");
            }
            return result.ToString();
        }

        public void Insert(int coef, int deg1, int deg2, int deg3)
        {
            var add = new PolinomItem(new int[] { coef, deg1, deg2, deg3 });
            var index = Polinom.BinarySearch(add);
            if (index <= 0) Polinom.Add(add);
            else Polinom[index] = add;
            Sort();
        }

        public void Delete(int deg1, int deg2, int deg3)
        {
            var deg = new Degree(new int[] { deg1, deg2, deg3 });
            for (int i = 0; i < Polinom.Count; i++)
            {
                if (Polinom[i].Degree.Equals(deg)) Polinom.RemoveAt(i);
            }
        }

        public void Add(Polinom3 p)
        {
            Polinom.AddRange(p);
            Sort();
        }

        public void Derivate(int i)
        {
            for (var j = 0; j < Polinom.Count; j++)
            {
                var temp = Polinom[i].Degree[i];
                Polinom[i].Degree[i]--;
                Polinom[i].Coefficient *= temp;
            }
        }

        public int Value(int x, int y, int z)
        {
            var result = 0.0;
            var point = new int[] { x, y, z };
            foreach (var e in Polinom)
            {
                result += e.Coefficient * e.Degree.Pow(point);
            }
            return (int)result;
        }

        public int[] MinCoef()
        {
            var min = new PolinomItem(new int[] { int.MaxValue, 0, 0, 0 });
            foreach (var e in Polinom)
            {
                if (e.Coefficient < min.Coefficient)
                {
                    min = e;
                }
            }
            return min.Degree.Arr;
        }

        public IEnumerator<PolinomItem> GetEnumerator()
        {
            for (var i = 0; i < Polinom.Count; i++)
            {
                yield return Polinom[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Sort()
        {
            Polinom.Sort(new LexicographicalOrder<PolinomItem>());
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var test = new Polinom3("2 3 1 4\n-5 2 1 0\n2 7 1 9");
            Console.WriteLine(test);
        }
        
}
} 
