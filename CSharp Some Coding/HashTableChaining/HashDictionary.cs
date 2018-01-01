namespace HashTableChaining
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HashDictionary<K, V>
        : IDictionary<K, V>
    {
        private const int DEFAULT_CAPACITY = 2;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public int Count
        {
            get { return this.size; }
        }

        public V this[K key]
        {
            get { return this.Get(key); }
            set { this.Set(key, value); }
        }

        public HashDictionary(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new List<KeyValuePair<K, V>>[capacity];
            this.loadFactor = loadFactor;
            unchecked
            {
                this.threshold = (int)(capacity * this.loadFactor);
            }
        }

        public void Clear()
        {
            if (this.table != null)
            {
                this.table = new List<KeyValuePair<K, V>>[this.initialCapacity];
            }
            this.size = 0;
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index % this.table.Length;
            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }
            return this.table[index] as List<KeyValuePair<K, V>>;
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (KeyValuePair<K, V> item in chain)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }

            return default(V);
        }

        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> item = chain[i];
                if (item.Key.Equals(key))
                {
                    KeyValuePair<K, V> newItem = new KeyValuePair<K, V>(key, value);
                    chain[i] = newItem;
                    return item.Value;
                }
            }

            chain.Add(new KeyValuePair<K, V>(key, value));

            if (this.size++ >= this.threshold)
            {
                this.Expand();
            }

            return default(V);
        }

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.threshold = (int)(newCapacity * this.threshold);
            foreach (List<KeyValuePair<K, V>> list in oldTable)
            {
                if (oldTable != null)
                {
                    foreach (KeyValuePair<K, V> item in list)
                    {
                        List<KeyValuePair<K, V>> chain = this.FindChain(item.Key, true);
                        chain.Add(item);
                    }
                }
            }
        }

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<K, V> item = chain[i];
                    if (item.Key.Equals(key))
                    {
                        chain.RemoveAt(i);
                        this.size--;
                        return true;
                    }
                }
            }
            return false;
        }

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (List<KeyValuePair<K, V>> list in this.table)
            {
                if (list != null)
                {
                    foreach (KeyValuePair<K, V> item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}
