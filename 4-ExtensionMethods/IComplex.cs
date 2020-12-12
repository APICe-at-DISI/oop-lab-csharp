namespace ExtensionMethods
{
    using System;

    /// <summary>
    /// The interface models a <a href="https://en.wikipedia.org/wiki/Complex_number">complex number</a>.
    /// </summary>
    public interface IComplex : IEquatable<IComplex>
    {
        /// <summary>
        /// Gets the real part of the complex number.
        /// </summary>
        double Real { get; }

        /// <summary>
        /// Gets the imaginary part of the complex number.
        /// </summary>
        double Imaginary { get; }

        /// <summary>
        /// Gets the modulus of the complex number.
        /// </summary>
        double Modulus { get; }

        /// <summary>
        /// Gets the phase of the complex number.
        /// </summary>
        double Phase { get; }

        /// <inheritdoc cref="object.ToString"/>
        string ToString();
    }
}
