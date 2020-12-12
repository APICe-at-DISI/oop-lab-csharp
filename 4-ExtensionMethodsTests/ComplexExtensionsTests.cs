namespace ExtensionMethods
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComplexExtensionsTests
    {
        private readonly IComplex c1 = new Complex(1, 1);
        private readonly IComplex c2 = new Complex(1, 1);

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(new Complex(2, 2), this.c1.Add(this.c2));
        }

        [TestMethod]
        public void SubtractTest()
        {
            Assert.AreEqual(new Complex(0, 0), this.c1.Subtract(this.c2));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(new Complex(0, 2), this.c1.Multiply(this.c2));
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.AreEqual(new Complex(1, 0), this.c1.Divide(this.c2));
        }

        [TestMethod]
        public void ConjugateTest()
        {
            Assert.AreEqual(new Complex(1, -1), this.c1.Conjugate());
        }

        [TestMethod]
        public void ReciprocalTest()
        {
            Assert.AreEqual(new Complex(0.5, -0.5), this.c1.Reciprocal());
        }
    }
}
