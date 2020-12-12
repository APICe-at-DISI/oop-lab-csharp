using System;

namespace ExtensionMethods
{
    /// <summary>
    /// The static class declares extension methods for complex numbers.
    /// </summary>
    public static class ComplexExtensions
    {
        /// <summary>
        /// Add two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the sum.</returns>
        public static IComplex Add(this IComplex c1, IComplex c2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Substract <paramref name="c2"/> from <paramref name="c1"/>.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the difference.</returns>
        public static IComplex Subtract(this IComplex c1, IComplex c2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiply two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the product.</returns>
        public static IComplex Multiply(this IComplex c1, IComplex c2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Divide two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the quotient.</returns>
        public static IComplex Divide(this IComplex c1, IComplex c2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the complex conjugate of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The complex conjugate of a complex number is the number with an equal real part
        /// and an imaginary part equal in magnitude, but opposite in sign.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex conjugate.</returns>
        public static IComplex Conjugate(this IComplex c1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the reciprocal of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The multiplicative inverse (or reciprocal) of a complex number is a number,
        /// that when multiplied with that complex number, gives an answer of 1.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex reciprocal.</returns>
        public static IComplex Reciprocal(this IComplex c1)
        {
            throw new NotImplementedException();
        }
    }
}
