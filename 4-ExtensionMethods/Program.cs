using System;

namespace ExtensionMethods
{

    class Program
    {
        static void Main(string[] args)
        {
            IComplex c1 = new Complex(1, 1);
            IComplex c2 = new Complex(1, 1);

            if (!c1.Add(c2).Equals(new Complex(2, 2)))
            {
                throw new Exception("Wrong implementation");
            }

            if (!c1.Subtract(c2).Equals(new Complex(0, 0)))
            {
                throw new Exception("Wrong implementation");
            }

            if (!c1.Multiply(c2).Equals(new Complex(0, 2)))
            {
                throw new Exception("Wrong implementation");
            }

            if (!c1.Divide(c2).Equals(new Complex(1, 0)))
            {
                throw new Exception("Wrong implementation");
            }

            if (!c1.Conjugate().Equals(new Complex(1, -1)))
            {
                throw new Exception("Wrong implementation");
            }

            if (!c1.Reciprocal().Equals(new Complex(0.5, -0.5)))
            {
                throw new Exception("Wrong implementation");
            }
            
            Console.WriteLine("Ok");
        }
    }
}
