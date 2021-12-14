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
    public class Day14Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
            var solver = new Day14();
            string output = solver.Solve(input, 10);
            Assert.AreEqual("1588", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day14.txt");
            var solver = new Day14();
            string output = solver.Solve(input, 10);
            Console.WriteLine(output);
            Assert.AreEqual("2740", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
            var solver = new Day14();
            string output = solver.Solve(input, 40);
            Assert.AreEqual("2188189693529", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day14.txt");
            var solver = new Day14();
            string output = solver.Solve(input, 40);
            Console.WriteLine(output);
            Assert.AreEqual("2959788056211", output);
        }
    }
}
