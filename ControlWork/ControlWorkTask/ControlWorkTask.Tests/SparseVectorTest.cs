using NUnit.Framework;
using Vector;

namespace ControlWorkTask.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdditionShallReturnNullIsLengthOfVectorsIsDiferent()
        {
            var vector1 = new SparseVector("10203");
            var vector2 = new SparseVector("0102");
            Assert.AreEqual(null, SparseVector.Addition(vector1, vector2));
        }
    }
}