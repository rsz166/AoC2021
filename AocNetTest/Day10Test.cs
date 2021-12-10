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
    public class Day10Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
            var solver = new Day10();
            string output = solver.Solve(input);
            Assert.AreEqual("26397", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day10.txt");
            var solver = new Day10();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("374061", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
            var solver = new Day10();
            string output = solver.Solve2(input);
            Assert.AreEqual("288957", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day10.txt");
            var solver = new Day10();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("2116639949", output);
        }
    }
}
