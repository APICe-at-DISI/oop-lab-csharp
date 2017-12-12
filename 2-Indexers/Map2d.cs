using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            throw new NotImplementedException();
        }

        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            throw new NotImplementedException();
        }

        public int NumberOfElements
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
