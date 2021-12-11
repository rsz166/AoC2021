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
    public class Day11Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
            var solver = new Day11();
            string output = solver.Solve(input, 10);
            Assert.AreEqual("204", output);
        }

        [TestMethod]
        public void Test1_2()
        {
            string input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
            var solver = new Day11();
            string output = solver.Solve(input, 100);
            Assert.AreEqual("1656", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day11.txt");
            var solver = new Day11();
            string output = solver.Solve(input, 100);
            Console.WriteLine(output);
            Assert.AreEqual("1655", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
            var solver = new Day11();
            string output = solver.Solve2(input);
            Assert.AreEqual("195", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day11.txt");
            var solver = new Day11();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("337", output);
        }
    }
}
