using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableChaining
{
    public interface IDictionary<K, V>
        : IEnumerable<KeyValuePair<K, V>>
    {
        V Set(K key, V value);
        V Get(K key);
        V this[K key] { get; set; }
        bool Remove(K key);
        int Count { get; }
        void Clear();
    }
}
