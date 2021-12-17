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
    public class Day17Test
    {
        private const string FilePath = "../../../files/day17.txt";

        Day17 GetSolver() => new();

        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("45", solver.Solve(@"target area: x=20..30, y=-10..-5"));
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("4753", output);
        }

        [TestMethod]
        public void Test2()
        {
            var solver = GetSolver();
            Assert.AreEqual("112", solver.Solve2(@"target area: x=20..30, y=-10..-5"));
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("1546", output);
        }
    }
}
