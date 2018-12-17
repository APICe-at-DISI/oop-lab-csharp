using System;

namespace ExtensionMethods {

    public static class ComplexExtensions
    {
        public static IComplex Add(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static IComplex Subtract(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static IComplex Multiply(this IComplex c1, IComplex c2)
        {
            return new Complex(
                       c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, 
                       c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
                );
        }
        
        public static IComplex Multiply(this IComplex c1, double scalar)
        {
            return new Complex(
                c1.Real * scalar, 
                c1.Imaginary * scalar
            );
        }
        
        public static IComplex Divide(this IComplex c1, double scalar)
        {
            return c1.Multiply(1.0 / scalar);
        }

        public static IComplex Divide(this IComplex c1, IComplex c2)
        {
            return c1.Multiply(c2.Reciprocal());
        }

        public static IComplex Conjugate(this IComplex c1)
        {
            return new Complex(
                    c1.Real, -c1.Imaginary
                );
        }

        public static IComplex Reciprocal(this IComplex c1)
        {
            return c1.Conjugate().Divide(c1.Modulus * c1.Modulus);
        }
    }

}