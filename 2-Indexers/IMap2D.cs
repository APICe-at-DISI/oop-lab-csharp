using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    public interface IMap2D<TKey1, TKey2, TValue> : IEquatable<IMap2D<TKey1, TKey2, TValue>>
    {
        TValue this[TKey1 key1, TKey2 key2] { get; set; }

        string ToString();

        IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1);

        IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2);

        IList<Tuple<TKey1, TKey2, TValue>> GetElements();

        void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator);

        int NumberOfElements { get; }
    }
}
