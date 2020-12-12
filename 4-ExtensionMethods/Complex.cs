namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private const double Tolerance = 1E-7;

        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real => this.re;

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary => this.im;

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(this.re * this.re + this.im * this.im);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(this.im, this.re);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString() => $"{this.re} {(this.im >= 0 ? "+" : "-")} i{Math.Abs(this.im)}";

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return other != null
                   && Math.Abs(this.Imaginary - other.Imaginary) < Tolerance
                   && Math.Abs(this.Real - other.Real) < Tolerance;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj is IComplex)
            {
                return this.Equals(obj as IComplex);
            }

            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.re, this.im);
        }
    }
}
