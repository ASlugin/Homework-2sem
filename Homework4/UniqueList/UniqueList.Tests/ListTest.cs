using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniqueList;

namespace UniqueList.Tests
{
    public class ListTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> ListCases
            => new TestCaseData[]
            {
                new TestCaseData(new List()),
                new TestCaseData(new UniqueList())
            };

        [TestCaseSource(nameof(ListCases))]
        public void ListShallBeEmptyAfterInitialization(List list)
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestCaseSource(nameof(ListCases))]
        public void ListShallNotBeEmptyAfterAdd(List list)
        {
            list.Add(7, 0);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestCaseSource(nameof(ListCases))]
        public void SizeWorksCorrectly(List list)
        {
            list.Add(12, 0);
            Assert.AreEqual(list.Size, 1);
            list.Add(34, 0);
            Assert.AreEqual(list.Size, 2);
            list.Delete(0);
            Assert.AreEqual(list.Size, 1);
            list.Delete(0);
            Assert.AreEqual(list.Size, 0);
        }

        [TestCaseSource(nameof(ListCases))]
        public void AddByInvalidPosition(List list)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(1, 1));
            list.Add(11, 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(12, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(1, 2));
        }

        [TestCaseSource(nameof(ListCases))]
        public void GetValueWorkAfterAdd(List list)
        {
            for (int i = 0; i < 15; i++)
            {
                list.Add(i * 10 + 1, list.Size);
            }
            for (int i = 0; i < 15; i++)
            {
                Assert.AreEqual(i * 10 + 1, list.GetValue(i));
            }
        }

        [TestCaseSource(nameof(ListCases))]
        public void GetValueShallNotWorkWithInvalidPosition(List list)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValue(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValue(0));
            list.Add(11, 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValue(1));
        }

        [TestCaseSource(nameof(ListCases))]
        public void ChangeValueOfElementShallNotWorkWithInvalidPosition(List list)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValueOfElement(12, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValueOfElement(34, 0));
            list.Add(11, 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValueOfElement(22, 1));
        }

        [Test]
        public void ChangeValueOfElementShallWorkCorrectly()
        {
            List list = new List();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i, list.Size);
                list.ChangeValueOfElement(i * 10 + 1, i);
            }
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i * 10 + 1, list.GetValue(i));
            }
        }

        [TestCaseSource(nameof(ListCases))]
        public void DeleteShallNotWorkWithInvalidPosition(List list)
        {
            list.Add(11, list.Size);
            list.Add(22, list.Size);
            Assert.Throws<AttemptToDeleteNonexistentElement>(() => list.Delete(-1));
            Assert.Throws<AttemptToDeleteNonexistentElement>(() => list.Delete(2));
        }

        [TestCaseSource(nameof(ListCases))]
        public void DeleteShallWorkCorrectly(List list)
        {
            list.Add(12, list.Size);
            list.Add(34, list.Size);
            list.Add(56, list.Size);
            list.Add(78, list.Size);

            list.Delete(0);
            Assert.AreEqual(34, list.GetValue(0));
            list.Delete(list.Size - 1);
            Assert.AreEqual(56, list.GetValue(list.Size - 1));
        }
    }
}