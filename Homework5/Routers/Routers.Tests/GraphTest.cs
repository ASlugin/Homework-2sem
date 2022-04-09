using NUnit.Framework;
using Routers;

using System;
using System.IO;

namespace Routers.Tests
{
    public class Tests
    {
        [SetUp]
        public void CreatingFile()
        {
            FileStream output = File.Create("../../../../Routers.Tests/TestInput.txt");
            output.Close();
        }

        [TestCase("4: ")]
        [TestCase("1: 2 (w)")]
        [TestCase("1: r (2)")]
        [TestCase("q: 1 (5)")]
        [TestCase("3: 2 ()")]
        [TestCase("7: 1 {2}, 5 {4}")]
        [TestCase("7: 1 (2); 5 (4)")]
        public void CreatingGraphWithInvalidInputDataShallThrowExceprion(string lineForFile)
        {
            var file = new StreamWriter("../../../../Routers.Tests/TestInput.txt");
            file.WriteLine(lineForFile);
            file.Close();

            bool testFail = true;
            try
            {
                var a = new Graph("../../../../Routers.Tests/TestInput.txt");
            }
            catch (InvalidDataException)
            {
                testFail = false;
            }
            if (testFail)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [TestCase(new object[] { "1: 2 (3), 4 (5)", "2: 1 (4)" })]
        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 1 (5)", "1: 3 (5)"})]
        [TestCase(new object[] { "5: 1 (3), 1 (5)" })]
        public void CreatingGraphWithRepeatedDeclaringEdgeShallThrowException(params string[] linesForFile)
        {
            var file = new StreamWriter("../../../../Routers.Tests/TestInput.txt");
            foreach(var line in linesForFile)
            {
                file.WriteLine(line);
            }
            file.Close();

            bool testFail = true;
            try
            {
                var a = new Graph("../../../../Routers.Tests/TestInput.txt");
            }
            catch (RepeatedDeclaringEdgeException)
            {
                testFail = false;
            }
            if (testFail)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

    }
}