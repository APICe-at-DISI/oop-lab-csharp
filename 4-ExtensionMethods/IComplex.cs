using System;

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
