using AocNetLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocNetTest
{
    [TestClass]
    public class Day9Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"2199943210
3987894921
9856789892
8767896789
9899965678";
            var solver = new Day9();
            string output = solver.Solve(input);
            Assert.AreEqual("15", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day9.txt");
            var solver = new Day9();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("480", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"2199943210
3987894921
9856789892
8767896789
9899965678";
            var solver = new Day9();
            string output = solver.Solve2(input);
            Assert.AreEqual("1134", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day9.txt");
            var solver = new Day9();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("1045660", output);
        }
    }
}
