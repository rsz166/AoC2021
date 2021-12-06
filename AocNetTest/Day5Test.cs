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
    public class Day5Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            Day5 solver = new Day5();
            string output = solver.Solve(input);
            Assert.AreEqual("5", output);
        }


        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day5.txt");
            Day5 solver = new Day5();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("6564", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            Day5 solver = new Day5();
            string output = solver.Solve2(input);
            Assert.AreEqual("12", output);
        }


        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day5.txt");
            Day5 solver = new Day5();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("19172", output);
        }
    }
}
