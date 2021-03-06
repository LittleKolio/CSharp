﻿namespace Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomTuple<T, U>
    {
        public CustomTuple(T item1, U item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T Item1 { get; }
        public U Item2 { get; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
