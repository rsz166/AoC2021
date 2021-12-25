using AocNetLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocNetTest
{
    [TestClass]
    public class Day23Test : TestBase<Day23>
    {
        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("12521", solver.Solve(@"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########"));
        }

        [TestMethod]
        public void Final1()
        {
            var solver = GetSolver();
            string output = solver.Solve(GetFinalInput());
            Console.WriteLine(output);
            Assert.AreEqual("15358", output);
        }

        [TestMethod]
        public void Test2()
        {
            var solver = GetSolver();
            Assert.AreEqual("44169", solver.Solve2(@"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########"));
        }

        [TestMethod]
        public void Final2()
        {
            var solver = GetSolver();
            string output = solver.Solve2(GetFinalInput());
            Console.WriteLine(output);
            Assert.AreEqual("51436", output);
        }
    }
}
