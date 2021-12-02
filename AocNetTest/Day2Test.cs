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
    public class Day2Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            Day2 solver = new Day2();
            string output = solver.Solve(input);
            Assert.AreEqual("150", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day2.txt");
            Day2 solver = new Day2();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("1714950", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            Day2 solver = new Day2();
            string output = solver.Solve2(input);
            Assert.AreEqual("900", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day2.txt");
            Day2 solver = new Day2();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            //Assert.AreEqual("1714950", output);
        }
    }
}
