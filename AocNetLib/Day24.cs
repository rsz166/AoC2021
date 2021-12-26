namespace AocNetLib
{
    public class Day24
    {
        public string Solve(string code)
        {
            var dec = new Decrypter(code);
            dec.CollectSolutions();
            var result = dec.GetMax();
            dec.Verify(result);
            return string.Concat(result);
        }

        class Decrypter
        {
            AluSolver[] AluParts;
            Alu AluComplete;
            List<AluState>[] solutions;

            public Decrypter(string code)
            {
                var prog = code.Trim().Split('\n').Select(x => x.TrimEnd().Split(' ')).ToList();
                AluComplete = new Alu(prog);
                int cnt = prog.Count(x => x[0] == "inp");
                AluParts = new AluSolver[cnt];
                int partIdx = 0;
                int prevStart = 0;
                for (int i = 0; i < prog.Count; i++)
                {
                    if (prog[i][0] == "inp")
                    {
                        int len = i - prevStart;
                        if (len == 0) continue;
                        AluParts[partIdx++] = new AluSolver(prog.Skip(prevStart).Take(len).ToList());
                        prevStart = i;
                    }
                }
                AluParts[partIdx] = new AluSolver(prog.Skip(prevStart).ToList());
                solutions = new List<AluState>[cnt];
            }

            public void CollectSolutions()
            {
                for (int digit = AluParts.Length - 1; digit >= 0; digit--)
                {
                    List<int> whitelist;
                    if (digit == AluParts.Length - 1) whitelist = new List<int>() { 0 };
                    else whitelist = solutions[digit + 1].Select(x => x.in_z).Distinct().ToList();
                    Console.WriteLine($"Digit {digit} whitelist: {{0}}", string.Join(" ", whitelist));
                    var sol = AluParts[digit].ExpectOutput(whitelist);
                    solutions[digit] = sol;
                    Console.WriteLine($"Digit {digit} done");
                    //File.WriteAllLines($"sol{digit}.txt", sol.Select(x => $"{x.in_arg}\t{x.in_z}\t{x.out_z}"));
                }
                Console.WriteLine("Start Z's: {0}", string.Join(" ", solutions[0].Select(x => x.in_z).Distinct()));
            }

            public void MergeSolutions()
            {
                for (int digit = 1; digit < solutions.Length; digit++)
                {
                    for (int i = 0; i < solutions[digit].Count; i++)
                    {
                        var solIn = solutions[digit][i].in_z;
                        if (!solutions[digit - 1].Any(x => x.out_z == solIn))
                        {
                            solutions[digit].RemoveAt(i);
                            i--;
                        }
                    }
                }
                Console.WriteLine(string.Join(Environment.NewLine, solutions.Select(sol =>
                    string.Join(" ", sol.Select(s => s.in_arg))
                )));
            }

            public int[] GetMax()
            {
                int[] solArgs = new int[solutions.Length];
                IEnumerable<AluState> prevDigit = new List<AluState>() { new AluState(0, 0, 0) };
                for (int i = 0; i < solArgs.Length; i++)
                {
                    IEnumerable<AluState> sol = solutions[i];
                    if (prevDigit != null)
                    {
                        sol = sol.Where(n => prevDigit.Any(p => p.out_z == n.in_z));
                    }
                    if (sol.Count() == 0) throw new Exception("No solution");
                    int maxArg = sol.Max(x => x.in_arg);
                    solArgs[i] = maxArg;
                    prevDigit = sol.Where(x => x.in_arg == maxArg).ToList();
                }
                return solArgs;
            }

            internal void Verify(int[] args)
            {
                AluComplete.Reset();
                AluComplete.Execute(args);
                if (AluComplete.z != 0) throw new Exception("Wrong result");
            }
        }

        class Alu
        {
            List<string[]> prog;

            public int w, x, y, z;

            public Alu(List<string[]> prog)
            {
                this.prog = prog;
            }

            internal void Execute(int[] args)
            {
                int argIdx = 0;
                for (int stepIdx = 0; stepIdx < prog.Count; stepIdx++)
                {
                    var step = prog[stepIdx];
                    switch (step[0])
                    {
                        case "inp": SetReg(step[1], args[argIdx++]); break;
                        case "add": SetReg(step[1], GetReg(step[1]) + GetValue(step[2])); break;
                        case "mul": SetReg(step[1], GetReg(step[1]) * GetValue(step[2])); break;
                        case "div": SetReg(step[1], GetReg(step[1]) / GetValue(step[2])); break;
                        case "mod": SetReg(step[1], GetReg(step[1]) % GetValue(step[2])); break;
                        case "eql": SetReg(step[1], GetReg(step[1]) == GetValue(step[2]) ? 1 : 0); break;
                        default: throw new ArgumentException("Invalid instruction");
                    }
                }
            }

            int GetValue(string s)
            {
                if (int.TryParse(s, out int value)) return value;
                return GetReg(s);
            }

            void SetReg(string reg, int value)
            {
                switch (reg)
                {
                    case "w": w = value; break;
                    case "x": x = value; break;
                    case "y": y = value; break;
                    case "z": z = value; break;
                    default: throw new ArgumentException("Invalid reg");
                }
            }

            int GetReg(string reg)
            {
                switch (reg)
                {
                    case "w": return w;
                    case "x": return x;
                    case "y": return y;
                    case "z": return z;
                    default: throw new ArgumentException("Invalid reg");
                }
            }

            public override string ToString()
            {
                return $"{w} {x} {y} {z}";
            }

            internal void Reset(int w = 0, int x = 0, int y = 0, int z = 0)
            {
                this.w = w;
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        class AluSolver : Alu
        {
            const int ZMax = 100000;
            const int ZMin = -100000;
            const int ArgMin = 1;
            const int ArgMax = 9;

            public AluSolver(List<string[]> prog) : base(prog)
            {
            }

            int TryInput(int initZ, int arg)
            {
                Reset(z: initZ);
                Execute(new int[] { arg });
                return z;
            }

            public List<AluState> ExpectOutput(List<int> outputs)
            {
                var ret = new List<AluState>();
                for (int initZ = ZMin; initZ <= ZMax; initZ++)
                {
                    for (int arg = ArgMin; arg <= ArgMax; arg++)
                    {
                        var result = TryInput(initZ, arg);
                        if (outputs.Contains(result)) ret.Add(new AluState(arg, initZ, result));
                    }
                }
                return ret;
            }
        }

        struct AluState
        {
            public int in_arg, in_z, out_z;

            public AluState(int in_arg, int in_z, int out_z)
            {
                this.in_arg = in_arg;
                this.in_z = in_z;
                this.out_z = out_z;
            }
        }
    }
}