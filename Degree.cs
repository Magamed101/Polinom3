using System;

namespace Program
{
    class Degree : IComparable
    {
        public int[] Arr;
        public int Count { get { return Arr.Length; } }

        public Degree(int[] data)
        {
            Arr = data;
        }

        public int CompareTo(object obj)
        {
            var item = obj as Degree;
            if (Arr[0] > item.Arr[0]) return 1;
            if (Arr[0] < item.Arr[0]) return -1;
            if (Arr[1] > item.Arr[1]) return 1;
            if (Arr[1] < item.Arr[1]) return -1;
            if (Arr[2] > item.Arr[2]) return 1;
            if (Arr[2] < item.Arr[2]) return -1;
            return 0;
        }

        public int Pow(int[] point)
        {
            var result = 0.0;
            for (int i = 0; i < Arr.Length; i++)
            {
                result += Math.Pow(point[i], Arr[i]);
            }
            return (int)result;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Degree;
            return Arr[0].Equals(item.Arr[0]) && Arr[1].Equals(item.Arr[1]) && Arr[1].Equals(item.Arr[1]);
        }

        public override string ToString()
        {
            return $"(x^{Arr[0].ToString()} y^{Arr[1].ToString()} z^{Arr[2].ToString()})";
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return Arr[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                Arr[index] = value;
            }

        }

    }
}