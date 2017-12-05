using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    //public class ExtComplex : Complex {
    
    //}

    //static class ComplexExtensions
    //{
    //    public static double GetModulus(this Complex c)
    //    {
    //        return Math.Sqrt(c.Re * c.Re + c.Im * c.Im);
    //    }

    //    public static double GetPhase(this Complex c)
    //    {
    //        return Math.Atan2(c.Im, c.Re);
    //    }

    //    public static double ToDeg(this double rad)
    //    {
    //        return rad * 180 / Math.PI;
    //    }
    //}

    class ExtensionMethodsExample
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(2, 2);

            Complex c3 = c1 * c2;

            Console.WriteLine("( " + c1 + ") * (" + c2 + ") = " + c3);

            //Console.WriteLine("|c3| = " + c3.GetModulus());

            //Console.WriteLine("ph(c3) = " + c3.GetPhase().ToDeg() + "°");

            //Console.ReadKey();
        }
    }
}
