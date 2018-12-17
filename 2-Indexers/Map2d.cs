using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {

        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> data = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
       

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return data[Tuple.Create(key1, key2)]; }
            set { data[Tuple.Create(key1, key2)] = value; }
        }

        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return data.Keys
                .Where(k1k2 => k1k2.Item1.Equals(key1))
                .Select(k1k2 => Tuple.Create(k1k2.Item2, data[k1k2]))
                .ToList();
        }

        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return data.Keys
                .Where(k1k2 => k1k2.Item2.Equals(key2))
                .Select(k1k2 => Tuple.Create(k1k2.Item1, data[k1k2]))
                .ToList();
        }

        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return data.Keys
                .Select(k1k2 => Tuple.Create(k1k2.Item1, k1k2.Item2, data[k1k2]))
                .ToList();
        }

        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            var keys2Array = keys2.ToArray();
            
            foreach (var k1 in keys1)
            {
                foreach (var k2 in keys2Array)
                {
                    this[k1, k2] = generator(k1, k2);
                }
            }
        }

        public int NumberOfElements => data.Count;

        protected bool Equals(Map2D<TKey1, TKey2, TValue> other)
        {
            return Equals(data, other.data);
        }

        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other is Map2D<TKey1, TKey2, TValue> otherMap2d)
            {
                return Equals(otherMap2d);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Map2D<TKey1, TKey2, TValue>) obj);
        }

        public override int GetHashCode()
        {
            return data != null ? data.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return "{ " + String.Join(", ", this.GetElements()
                       .Select(e => $"({e.Item1}, {e.Item2}) -> {e.Item3}")) + "}";
        }
    }
}
