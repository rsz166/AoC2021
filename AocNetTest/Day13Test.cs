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
    public class Day13Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
            var solver = new Day13();
            string output = solver.Solve(input);
            Assert.AreEqual("17", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day13.txt");
            var solver = new Day13();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("737", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
            var solver = new Day13();
            string output = solver.Solve2(input).Trim();
            Assert.AreEqual(@"#####
#...#
#...#
#...#
#####
.....
.....", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day13.txt");
            var solver = new Day13();
            string output = solver.Solve2(input).Trim();
            Console.WriteLine(output);
            Assert.AreEqual(@"####.#..#...##.#..#..##..####.#..#.###..
...#.#..#....#.#..#.#..#.#....#..#.#..#.
..#..#..#....#.#..#.#..#.###..####.#..#.
.#...#..#....#.#..#.####.#....#..#.###..
#....#..#.#..#.#..#.#..#.#....#..#.#....
####..##...##...##..#..#.#....#..#.#....", output);
        }
    }
}
