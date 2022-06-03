using NUnit.Framework;

using System;
using System.IO;

namespace Routers.Tests
{
    public class Tests
    {
        private string pathToInputFile = "../../../../Routers.Tests/TestInput.txt";

        private void PrintDataToFile(string[] linesForFile)
        {
            var file = new StreamWriter(pathToInputFile);
            foreach (var line in linesForFile)
            {
                file.WriteLine(line);
            }
            file.Close();
        }

        [SetUp]
        public void CreatingFile()
        {
            FileStream output = File.Create(pathToInputFile);
            output.Close();
        }

        [TestCase(new object[] { "4: " })]
        [TestCase(new object[] { "1: 2 (w)" })]
        [TestCase(new object[] { "1: r (2)" })]
        [TestCase(new object[] { "q: 1 (5)" })]
        [TestCase(new object[] { "3: 2 ()" })]
        [TestCase(new object[] { "7: 1 {2}, 5 {4}" })]
        [TestCase(new object[] { "7: 1 (2); 5 (4)" })]
        public void CreatingGraphWithInvalidInputDataShallThrowExceprion(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            Assert.Throws<InvalidDataException>(() => new Graph(pathToInputFile));
        }

        [TestCase(new object[] { "1: 2 (3), 4 (5)", "2: 1 (4)" })]
        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 1 (5)", "1: 3 (5)"})]
        [TestCase(new object[] { "5: 1 (3), 1 (5)" })]
        public void CreatingGraphWithRepeatedDeclaringEdgeShallThrowException(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            bool testFail = true;
            try
            {
                var graph = new Graph(pathToInputFile);
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

        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 1 (4)" })]
        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 1 (5), 2 (3)", "5: 3 (5)" })]
        [TestCase(new object[] { "1: 2 (12), 3 (13)", "3: 2 (32), 4 (34)", "4: 5(45), 6(46)", "5: 6(56)" })]
        public void IsGraphConnectivityShallReturnTrueIfGraphIsConnectivity(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            var graph = new Graph(pathToInputFile);
            Assert.IsTrue(graph.IsGraphConnected());
        }

        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 5 (4)" })]
        [TestCase(new object[] { "1: 2(3), 3(6), 4(5)", "5: 6 (5)", "3: 4 (5)" })]
        [TestCase(new object[] { "1: 2 (12), 3 (13)", "3: 2 (32)", "4: 5(45), 6(46)", "5: 6(56)" })]
        public void IsGraphConnectivityShallReturnFalseIfGraphIsNotConnectivity(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            var graph = new Graph(pathToInputFile);
            Assert.IsFalse(graph.IsGraphConnected());
        }

        [TestCase(new object[] { "1: 2 (3), 3 (5)", "2: 3 (4)" })]
        [TestCase(new object[] { "1: 2 (3), 4 (5)", "3: 1 (5), 2 (3)", "5: 3 (5)" })]
        [TestCase(new object[] { "1: 2 (12), 3 (13)", "3: 2 (32), 4 (34)", "4: 5(45), 6(46)", "5: 6(56)" })]
        public void GraphShallBeConnectivityAfterRemoveUnnecessaryEdges(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            var graph = new Graph(pathToInputFile);
            graph.RemoveUnnecessaryEdges();
            Assert.IsTrue(graph.IsGraphConnected());
        }

        [TestCase(new object[] { "1: 2 (10), 3 (5)", "2: 3 (1)" })]
        public void PrintGraphToFileShallWorkCorrectly(params string[] linesForFile)
        {
            PrintDataToFile(linesForFile);
            var graph = new Graph(pathToInputFile);
            graph.RemoveUnnecessaryEdges();
            graph.PrintGraphToFile("../../../../Routers.Tests/Output.txt");
            
            using var outputFile = new StreamReader("../../../../Routers.Tests/Output.txt");
            Assert.IsTrue(String.Compare(outputFile.ReadLine(), "1: 2 (10), 3 (5)") == 0);
        }
    }
}