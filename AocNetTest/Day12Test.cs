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
    public class Day12Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";
            var solver = new Day12();
            string output = solver.Solve(input);
            Assert.AreEqual("10", output);
        }

        [TestMethod]
        public void Test1_2()
        {
            string input = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";
            var solver = new Day12();
            string output = solver.Solve(input);
            Assert.AreEqual("19", output);
        }

        [TestMethod]
        public void Test1_3()
        {
            string input = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";
            var solver = new Day12();
            string output = solver.Solve(input);
            Assert.AreEqual("226", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day12.txt");
            var solver = new Day12();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("5874", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";
            var solver = new Day12();
            string output = solver.Solve2(input);
            Assert.AreEqual("36", output);
        }

        [TestMethod]
        public void Test2_2()
        {
            string input = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";
            var solver = new Day12();
            string output = solver.Solve2(input);
            Assert.AreEqual("103", output);
        }

        [TestMethod]
        public void Test2_3()
        {
            string input = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";
            var solver = new Day12();
            string output = solver.Solve2(input);
            Assert.AreEqual("3509", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day12.txt");
            var solver = new Day12();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("153592", output);
        }
    }
}
