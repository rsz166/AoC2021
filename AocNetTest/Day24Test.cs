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
    public class Day24Test : TestBase<Day24>
    {
        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("", solver.Solve(GetFinalInput()));
        }

        //[TestMethod]
        //public void Final1()
        //{
        //    var solver = GetSolver();
        //    long val = 95000000000000;
        //    while(true)
        //    {
        //        if (val < 94990000000000) throw new Exception("timeout");
        //        //if (val < 90000000000000) throw new Exception("timeout");
        //        if ((val & 0xffff) == 0) Console.WriteLine(val);
        //        var inputs = val.ToString().PadLeft(14, '0').Select(x => x - '0').ToArray();
        //        if (!inputs.Contains(0))
        //        {
        //            if (solver.Solve2(inputs)) break;
        //        }
        //        val--;
        //    }
        //    Console.WriteLine("Solution found");
        //    Console.WriteLine(val);
        //    //Assert.AreEqual("906093", output);
        //}

//        [TestMethod]
//        public void Test2()
//        {
//            var solver = GetSolver();
//            Assert.AreEqual("444356092776315", solver.Solve2(@"Player 1 starting position: 4
//Player 2 starting position: 8"));
//        }

//        [TestMethod]
//        public void Final2()
//        {
//            var solver = GetSolver();
//            string output = solver.Solve2(GetFinalInput());
//            Console.WriteLine(output);
//            //Assert.AreEqual("274291038026362", output);
//        }
    }
}
