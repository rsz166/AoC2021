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
    public class Day16Test
    {
        private const string FilePath = "../../../files/day16.txt";

        Day16 GetSolver() => new Day16();

        [TestMethod]
        public void Test1()
        {
            var solver = GetSolver();
            Assert.AreEqual("6", solver.Solve(@"D2FE28"));
        }

        [TestMethod]
        public void Test1_1()
        {
            var solver = GetSolver();
            Assert.AreEqual("16", solver.Solve(@"8A004A801A8002F478"));
        }

        [TestMethod]
        public void Test1_2()
        {
            var solver = GetSolver();
            Assert.AreEqual("12", solver.Solve(@"620080001611562C8802118E34"));
        }

        [TestMethod]
        public void Test1_3()
        {
            var solver = GetSolver();
            Assert.AreEqual("23", solver.Solve(@"C0015000016115A2E0802F182340"));
        }

        [TestMethod]
        public void Test1_4()
        {
            var solver = GetSolver();
            Assert.AreEqual("31", solver.Solve(@"A0016C880162017C3686B18A3D4780"));
        }

        [TestMethod]
        public void Final1()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve(input);
            Console.WriteLine(output);
            Assert.AreEqual("860", output);
        }

        [TestMethod]
        public void Test2_1()
        {
            var solver = GetSolver();
            Assert.AreEqual("3", solver.Solve2(@"C200B40A82"));
        }

        [TestMethod]
        public void Test2_2()
        {
            var solver = GetSolver();
            Assert.AreEqual("54", solver.Solve2(@"04005AC33890"));
        }

        [TestMethod]
        public void Test2_3()
        {
            var solver = GetSolver();
            Assert.AreEqual("7", solver.Solve2(@"880086C3E88112"));
        }

        [TestMethod]
        public void Test2_4()
        {
            var solver = GetSolver();
            Assert.AreEqual("9", solver.Solve2(@"CE00C43D881120"));
        }

        [TestMethod]
        public void Test2_5()
        {
            var solver = GetSolver();
            Assert.AreEqual("1", solver.Solve2(@"D8005AC2A8F0"));
        }

        [TestMethod]
        public void Test2_6()
        {
            var solver = GetSolver();
            Assert.AreEqual("0", solver.Solve2(@"F600BC2D8F"));
        }

        [TestMethod]
        public void Test2_7()
        {
            var solver = GetSolver();
            Assert.AreEqual("0", solver.Solve2(@"9C005AC2F8F0"));
        }

        [TestMethod]
        public void Test2_8()
        {
            var solver = GetSolver();
            Assert.AreEqual("1", solver.Solve2(@"9C0141080250320F1802104A08"));
        }

        [TestMethod]
        public void Final2()
        {
            string input = File.ReadAllText(FilePath);
            var solver = GetSolver();
            string output = solver.Solve2(input);
            Console.WriteLine(output);
            //Assert.AreEqual("2993", output);
        }
    }
}
