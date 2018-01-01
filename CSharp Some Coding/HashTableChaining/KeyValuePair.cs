namespace HashTableChaining
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct KeyValuePair<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public KeyValuePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public TKey Key
        {
            get { return this.key; }
        }

        public TValue Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');

            if (this.Key != null)
            {
                sb.Append(this.Key.ToString());
            }

            sb.Append(", ");

            if (this.Value != null)
            {
                sb.Append(this.Value.ToString());
            }

            sb.Append(']');

            return sb.ToString();
        }
    }
}
