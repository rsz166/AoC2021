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
    public class Day6Test
    {
        [TestMethod]
        public void Test1_18()
        {
            string input = "3,4,3,1,2";
            Day6 solver = new Day6();
            string output = solver.Solve(input, 18);
            Assert.AreEqual("26", output);
        }

        [TestMethod]
        public void Test1_80()
        {
            string input = "3,4,3,1,2";
            Day6 solver = new Day6();
            string output = solver.Solve(input, 80);
            Assert.AreEqual("5934", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day6.txt");
            Day6 solver = new Day6();
            string output = solver.Solve(input, 80);
            Console.WriteLine(output);
            Assert.AreEqual("375482", output);
        }

        [TestMethod]
        public void Test2_256()
        {
            string input = "3,4,3,1,2";
            Day6 solver = new Day6();
            string output = solver.Solve(input, 256);
            Assert.AreEqual("26984457539", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day6.txt");
            Day6 solver = new Day6();
            string output = solver.Solve(input, 256);
            Console.WriteLine(output);
            //Assert.AreEqual("375482", output);
        }
    }
}
