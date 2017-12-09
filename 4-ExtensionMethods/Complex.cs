using System;

namespace ExtensionMethods {

    internal class Complex : IComplex
    {
        public Complex(double re, double im) { }

        public bool Equals(IComplex other)
        {
            throw new NotImplementedException();
        }

        public double Real
        {
            get { throw new NotImplementedException(); }
        }
        public double Imaginary
        {
            get { throw new NotImplementedException(); }
        }
        public double Modulus
        {
            get { throw new NotImplementedException(); }
        }

        public double Phase
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}