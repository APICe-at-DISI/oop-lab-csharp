using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethods;

namespace ExtensionMethods.Tests
{
    [TestClass]
    public class ComplexExtensionsTests
    {
        private readonly IComplex c1 = new Complex(1, 1);
        private readonly IComplex c2 = new Complex(1, 1);

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(new Complex(2, 2), c1.Add(c2));
        }

        [TestMethod]
        public void SubtractTest()
        {
            Assert.AreEqual(new Complex(0, 0), c1.Subtract(c2));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(new Complex(0, 2), c1.Multiply(c2));
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.AreEqual(new Complex(1, 0), c1.Divide(c2));
        }

        [TestMethod]
        public void ConjugateTest()
        {
            Assert.AreEqual(new Complex(1, -1), c1.Conjugate());
        }

        [TestMethod]
        public void ReciprocalTest()
        {
            Assert.AreEqual(new Complex(0.5, -0.5), c1.Reciprocal());
        }
    }
}
