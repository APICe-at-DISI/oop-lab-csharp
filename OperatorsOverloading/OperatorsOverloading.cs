using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{

    class OperatorsOverloading
    {
        static void Main(string[] args)
        {
            StrangeInt x = 7;
            StrangeInt y = 3;

            Console.WriteLine((x + y).ToString()); // 10?
            Console.WriteLine((x - y).ToString()); // 4?
            Console.WriteLine((x * y).ToString()); // 21?
            Console.WriteLine((x / y).ToString()); // 2?

            Console.ReadKey();
            Console.WriteLine();

            int r1 = x + y;
            int r2 = x - y;
            int r3 = x * y;
            int r4 = x / y;

            Console.WriteLine(r1);
            Console.WriteLine(r2);
            Console.WriteLine(r3);
            Console.WriteLine(r4);

            Console.ReadKey();
        }
    }
}
