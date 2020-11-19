using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    class MainDelegatesAndEvents
    {
        static void OnSurnameChanged(string newSurname)
        {
            Console.WriteLine("New surname: " + newSurname);
        }

        static void Main(string[] args)
        {
            Person giovanni = new Person("Giovanni", "Ciatto", 25);

            giovanni.NameChanged += newName => Console.WriteLine("New name: " + newName);

            giovanni.SurnameChanged += (string newSurname) => Console.WriteLine("Surname changed: " + newSurname);

            giovanni.SurnameChanged += OnSurnameChanged;

            giovanni.AgeChanged += delegate(int newAge) {
                Console.WriteLine("New age: " + newAge);
            };

            giovanni.Name = "Mirko";
            giovanni.Surname = "Viroli";
            giovanni.Age = 40;

            Console.ReadKey();

        }
    }
}
