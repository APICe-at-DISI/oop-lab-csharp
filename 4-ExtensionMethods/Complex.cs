using System;

namespace ExtensionMethods
{
    internal class Complex : IComplex
    {
        private const double TOLERANCE = 1E-7;
        
        private readonly double re;
        private readonly double im;

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public bool Equals(IComplex other)
        {
            return other != null && Math.Abs(Imaginary - other.Imaginary) < TOLERANCE && Math.Abs(Real - other.Real) < TOLERANCE;
        }

        public double Real => re;

        public double Imaginary => im;

        public double Modulus => Math.Sqrt(re * re + im * im);

        public double Phase => Math.Atan2(im, re);

        public override string ToString() => $"{re} {(im >= 0 ? "+" : "-")} i{Math.Abs(im)}";

        public override bool Equals(object obj)
        {
            if (obj is IComplex)
            {
                return Equals(obj as IComplex);
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            hashCode = (hashCode * 397) ^ re.GetHashCode();
            hashCode = (hashCode * 397) ^ im.GetHashCode();
            return hashCode;
        }

    }
}
