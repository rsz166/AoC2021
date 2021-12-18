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
    public class Day18Test : TestBase<Day18>
    {
        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("4140", solver.Solve(@"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"));
        }

        [TestMethod]
        public void Test1_1()
        {
            var solver = GetSolver();
            Assert.AreEqual("29", solver.Solve(@"[9,1]"));
        }

        [TestMethod]
        public void Test1_2()
        {
            var solver = GetSolver();
            Assert.AreEqual("143", solver.Solve(@"[[1,2],[[3,4],5]]"));
        }

        [TestMethod]
        public void Test1_3()
        {
            var solver = GetSolver();
            Assert.AreEqual("1384", solver.Solve(@"[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]"));
        }

        [TestMethod]
        public void Test1_4()
        {
            var solver = GetSolver();
            Assert.AreEqual("3488", solver.Solve(@"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]"));
        }

        [TestMethod]
        public void Test1_5()
        {
            var solver = GetSolver();
            Assert.AreEqual("445", solver.Solve(@"[1,1]
[2,2]
[3,3]
[4,4]"));
        }

        [TestMethod]
        public void Test1_6()
        {
            var solver = GetSolver();
            Assert.AreEqual("791", solver.Solve(@"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]"));
        }

        [TestMethod]
        public void Test1_7()
        {
            var solver = GetSolver();
            Assert.AreEqual("1137", solver.Solve(@"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]"));
        }

        [TestMethod]
        public void Final1()
        {
            var solver = GetSolver();
            string output = solver.Solve(GetFinalInput());
            Console.WriteLine(output);
            Assert.AreEqual("2541", output);
        }

        [TestMethod]
        public void Test2()
        {
            var solver = GetSolver();
            Assert.AreEqual("3993", solver.Solve2(@"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"));
        }

        [TestMethod]
        public void Final2()
        {
            var solver = GetSolver();
            string output = solver.Solve2(GetFinalInput());
            Console.WriteLine(output);
            Assert.IsTrue(int.Parse(output) > 4585);
        }
    }
}
