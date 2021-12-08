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
    public class Day8Test
    {
        [TestMethod]
        public void Test1()
        {
            string input = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";
            var solver = new Day8();
            string output = solver.Solve(input);
            Assert.AreEqual("26", output);
        }

        [TestMethod]
        public void Test1_2()
        {
            string input = @"abcefg cf acdeg acdfg bcdf abdfg abdefg acf abcdefg abcdfg | cf";
            var solver = new Day8();
            string output = solver.Solve(input);
            Assert.AreEqual("1", output);
        }

        [TestMethod]
        public void Test1_3()
        {
            string input = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | be";
            var solver = new Day8();
            string output = solver.Solve(input);
            Assert.AreEqual("1", output);
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText("../../../files/day8.txt");
            var solver = new Day8();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("301", output);
        }

        [TestMethod]
        public void Test2()
        {
            string input = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";
            var solver = new Day8();
            string output = solver.Solve2(input);
            Assert.AreEqual("61229", output);
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText("../../../files/day8.txt");
            var solver = new Day8();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            Assert.AreEqual("908067", output);
        }
    }
}
