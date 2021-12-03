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
    public class Day3Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            Day3 solver = new Day3();
            string output = solver.Solve(input);
            Assert.AreEqual("198", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day3.txt");
            Day3 solver = new Day3();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("3885894", output);
        }


        [TestMethod]
        public void Test2()
        {
            string input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            Day3 solver = new Day3();
            string output = solver.Solve2(input);
            Assert.AreEqual("230", output);
        }

        [TestMethod]
        public void Test2_Eliminate1()
        {
            string input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            Day3 solver = new Day3();
            var in2 = Day3.ParseInput(input);
            var output = Day3.Eliminate(in2.ToList(), true);
            Assert.AreEqual(23, output);
        }

        [TestMethod]
        public void Test2_Eliminate0()
        {
            string input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            Day3 solver = new Day3();
            var in2 = Day3.ParseInput(input);
            var output = Day3.Eliminate(in2.ToList(), false);
            Assert.AreEqual(10, output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day3.txt");
            Day3 solver = new Day3();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("4375225", output);
        }
    }
}
