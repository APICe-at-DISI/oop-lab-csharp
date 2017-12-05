using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerablesVsStream
{
    static class EnumerableExample
    {
        public static string PitagoricTable(int n)
        {
            return Enumerable.Range(1, n)
                .Select(i => Enumerable.Range(1, n).Select(j => i + "x" + j + "=" + i * j))
                .Select(xs => xs.Aggregate((a, b) => a + " " + b))
                .Aggregate((a, b) => a + "\n" + b);
        }
    }
}
