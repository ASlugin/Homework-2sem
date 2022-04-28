using NUnit.Framework;
using Vector;

namespace ControlWorkTask.Tests
{
    public class Tests
    {
        [Test]
        public void AdditionShallReturnNullIsLengthOfVectorsIsDifferent()
        {
            var vector1 = new SparseVector("10203");
            var vector2 = new SparseVector("0102");
            Assert.IsNull(SparseVector.Addition(vector1, vector2));
        }
    }
}