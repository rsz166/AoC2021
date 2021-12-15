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
    public class Day15Test
    {
        private const string FilePath = "../../../files/day15.txt";

        Day15 GetSolver() => new Day15();

        [TestMethod]
        public void Test1()
        {
            string input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
            var solver = GetSolver();
            string output = solver.Solve(input);
            Assert.AreEqual("40", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("717", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
            var solver = GetSolver();
            string output = solver.Solve(input, 5);
            Assert.AreEqual("315", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve(input, 5);
            Console.WriteLine(output);
            Assert.AreEqual("2993", output);
        }
    }
}
