using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{

    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = List.From(1, 2, 3, 4, 5);
            int[] res1 = new int[] { 3, 4, 5, 4, 3 };
            int[] res2 = new int[] { 3, 4, 4, 3 };

            List<int> lst1 = List.Append(lst.Tail.Tail, List.From(4, 3));

            if (lst1 != (List<int>) res1)
            {
                throw new Exception("Wrong implementation");
            }

            List<int> lst2 = lst;
            lst2 += List.From(4, 3);

            if (lst2 != lst1)
            {
                throw new Exception("Wrong implementation");
            }

            List<int> lst3 = lst;
            lst3 -= 5;

            if (lst3 != (List<int>)res2)
            {
                throw new Exception("Wrong implementation");
            }

            if (lst3 >= lst1)
            {
                throw new Exception("Wrong implementation");
            }

            if (lst1 <= lst2)
            {
                throw new Exception("Wrong implementation");
            }

            Console.ReadLine();
        }
    }
}
