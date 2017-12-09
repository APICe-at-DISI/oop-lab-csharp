using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public interface IComplex : IEquatable<IComplex>
    {
        double Real { get; }
        double Imaginary { get; }

        double Modulus { get; }
        double Phase { get; }

        string ToString();
    }

}
