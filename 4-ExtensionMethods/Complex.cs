using System;

namespace ExtensionMethods
{
    internal class Complex : IComplex
    {
        private double re;
        private double im;

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public bool Equals(IComplex other)
        {
            throw new System.NotImplementedException();
        }

        public double Real
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public double Imaginary
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public double Modulus
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public double Phase
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override string ToString()
        {
            // TODO improve
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            // TODO improve
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // TODO improve
            return base.GetHashCode();
        }

    }
}