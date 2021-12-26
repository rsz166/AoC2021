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
            Assert.AreEqual("0 -5 0 0", solver.Solve(@"inp x
mul x -1", 5));
        }

        [TestMethod]
        public void Test1_1()
        {
            var solver = GetSolver();
            Assert.AreEqual("0 6 0 1", solver.Solve(@"inp z
inp x
mul z 3
eql z x", 2,6));
        }

        string[] CodeParts =
        {
@"inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 13
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x 0
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 7
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 4
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 13
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x -8
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 13
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 1
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x 0
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 14
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x -6
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 6
mul y x
add z y",@"
inp w
mul x 0
add x z
mod x 26
div z 26
add x -12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 14
mul y x
add z y
"
        };

        [TestMethod]
        public void Test1_2()
        {
            for (int codeIdx = 0; codeIdx < CodeParts.Length; codeIdx++)
            {
                var solver = new Day24(CodeParts[codeIdx]);
                var sb = new StringBuilder();
                for (int j = -500; j <= 500; j++)
                {
                    sb.AppendFormat("\t{0}", j);
                }
                sb.AppendLine();
                for (int i = 1; i < 10; i++)
                {
                    sb.Append(i);
                    for (int j = -500; j <= 500; j++)
                    {
                        sb.AppendFormat("\t{0}", solver.Solve3(j, i));
                    }
                    sb.AppendLine();
                }
                File.WriteAllText($"result_{codeIdx}.txt", sb.ToString());
            }
        }

        [TestMethod]
        public void Final1()
        {
            var solver = GetSolver();
            long val = 95000000000000;
            while(true)
            {
                if (val < 94990000000000) throw new Exception("timeout");
                //if (val < 90000000000000) throw new Exception("timeout");
                if ((val & 0xffff) == 0) Console.WriteLine(val);
                var inputs = val.ToString().PadLeft(14, '0').Select(x => x - '0').ToArray();
                if (!inputs.Contains(0))
                {
                    if (solver.Solve2(inputs)) break;
                }
                val--;
            }
            Console.WriteLine("Solution found");
            Console.WriteLine(val);
            //Assert.AreEqual("906093", output);
        }

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
