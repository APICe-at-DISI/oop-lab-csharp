using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            IMap2D<int, int, int> pitagoricTable = new Map2D<int, int, int>();

            pitagoricTable.Fill(
                    Enumerable.Range(1, 10),
                    Enumerable.Range(1, 10),
                    (i, j) => i * j
                );

            Console.WriteLine(pitagoricTable);

            for (int i = 1; i <= 10; i++)
            {
                if (pitagoricTable[i, i] != i * i)
                {
                    throw new Exception("Wrong implementation");
                }
            }

            var seven = new int[] {7, 14, 21, 28, 35, 42, 49, 56, 63, 70};

            if (pitagoricTable.GetRow(7).Select(t => t.Item2).SequenceEqual(seven))
            {
                throw new Exception("Wrong implementation");
            }

            if (pitagoricTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(seven))
            {
                throw new Exception("Wrong implementation");
            }

            Console.ReadLine();
        }
    }
}
