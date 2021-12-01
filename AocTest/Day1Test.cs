using AocLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AocTest
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"199
200
208
210
200
207
240
269
260
263";
            Day1 solver = new Day1();
            string output = solver.Solve(input);
            Assert.AreEqual("7", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../files/day1.txt");
            Day1 solver = new Day1();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("1696", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"199
200
208
210
200
207
240
269
260
263";
            Day1 solver = new Day1();
            string output = solver.Solve2(input);
            Assert.AreEqual("5", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../files/day1.txt");
            Day1 solver = new Day1();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("1737", output);
        }
    }
}
