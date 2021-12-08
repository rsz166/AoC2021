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
    public class Day7Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = "16,1,2,0,4,2,7,1,2,14";
            Day7 solver = new Day7();
            string output = solver.Solve(input);
            Assert.AreEqual("37", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day7.txt");
            Day7 solver = new Day7();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("347449", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = "16,1,2,0,4,2,7,1,2,14";
            Day7 solver = new Day7();
            string output = solver.Solve2(input);
            Assert.AreEqual("168", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day7.txt");
            Day7 solver = new Day7();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("98039527", output);
        }
    }
}
