using NUnit.Framework;
using MapFilterFold;
using System;
using System.Collections.Generic;

namespace MapFilterFold.Tests
{
    public class Tests
    {
        [Test]
        public void MapShallWorkCorrectly()
        {
            Assert.AreEqual(Functions.Map(new List<int>(), x => x * 3), new List<int>());
            Assert.AreEqual(Functions.Map(new List<int>() { 1, 5, -99 }, x => x * 3), new List<int>() { 3, 15, -297 });
            Assert.AreEqual(Functions.Map(new List<char>() { ' ', 'r', '7' }, x => x.ToString() + "1"), new List<string>() { " 1", "r1", "71" });
            Assert.AreEqual(Functions.Map(new List<double>() { 1.234, -5.004, 0.1 }, x => -x), new List<double>() { -1.234, 5.004, -0.1 });
            Assert.AreEqual(Functions.Map(new List<string>() { "a b c d", "qw er ty", "2 3 5 7 11" }, x => x.Replace(" ", "")), new List<string>() { "abcd", "qwerty", "235711" });
        }

        [Test]
        public void FilterShallWorkCorrectly()
        {
            Assert.AreEqual(Functions.Filter(new List<int>(), x => (x > 10 || x < -10)), new List<int>());
            Assert.AreEqual(Functions.Filter(new List<int>() { 12, 5, -99, 140, -10 }, x => (x > 10 || x < -10)), new List<int>() { 12, -99, 140});
            Assert.AreEqual(Functions.Filter(new List<char>() { ' ', '1', '5', '3', 'q', 'a', ',', '7' }, x => x >= '0' && x <= '9'), new List<char>() { '1', '5', '3', '7' });
            Assert.AreEqual(Functions.Filter(new List<string>() { "abcd", "qwerty", "ololo" }, x => x.Length > 4), new List<string>() { "qwerty", "ololo" });
        }

        [Test]
        public void FoldShallWorkCorrectly()
        {
            Assert.AreEqual(Functions.Fold(new List<int>(), 1, (acc, elem) => acc * elem), 1);
            Assert.AreEqual(Functions.Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem), 6);
            Assert.AreEqual(Functions.Fold(new List<string>() { "abc", "qwerty" }, 0, (acc, elem) => acc + elem.Length), 9);
            Assert.AreEqual(Functions.Fold(new List<double>() { 1.234, -5.004, 0.1 }, 0, (acc, elem) => acc + (int)elem / 1), -4);
        }

    }
}