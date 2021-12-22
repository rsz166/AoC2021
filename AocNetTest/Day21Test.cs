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
    public class Day21Test : TestBase<Day21>
    {
        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("739785", solver.Solve(@"Player 1 starting position: 4
Player 2 starting position: 8"));
        }

        [TestMethod]
        public void Final1()
        {
            var solver = GetSolver();
            string output = solver.Solve(GetFinalInput());
            Console.WriteLine(output);
            Assert.AreEqual("906093", output);
        }

        [TestMethod]
        public void Test2()
        {
            var solver = GetSolver();
            Assert.AreEqual("444356092776315", solver.Solve2(@"Player 1 starting position: 4
Player 2 starting position: 8"));
        }


        [TestMethod]
        public void Test2_1()
        {
            var solver = GetSolver();
            Assert.AreEqual("", solver.Solve2(@"Player 1 starting position: 2
Player 2 starting position: 1"));
        }
        [TestMethod]
        public void Final2()
        {
            var solver = GetSolver();
            string output = solver.Solve2(GetFinalInput());
            Console.WriteLine(output);
            //Assert.AreEqual("4647", output);
        }
    }
}
