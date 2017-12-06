using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class MainProperties
    {
        static void Main(string[] args)
        {
            Person giovanni = new Person("Giovanni", "Ciatto", new DateTime(1994, 1, 4));

            Console.WriteLine(giovanni);
            Console.ReadKey();

            //giovanni.Age = 25;

            //Console.WriteLine(giovanni);
            //Console.ReadKey();

            //Person giovanni1 = new Person() {
            //    FullName = "Giovanni Ciatto",
            //    BirthDate = new DateTime(1992, 1, 4)
            //};

            //Console.WriteLine(giovanni1);
            //Console.ReadKey();
        }
    }
}
