namespace AocNetLib
{
    public class Day24
    {
        public string Solve(string code, params int[] args)
        {
            var prog = code.TrimEnd().Split('\n').Select(x => x.TrimEnd().Split(' ')).ToList();
            var alu = new Alu(prog);
            alu.Execute(args);
            return alu.ToString();
        }

        public bool Solve1(params int[] args)
        {
            int argIdx = 0;
            int w = 0, x = 0, y = 0, z = 0; w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 11;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 8;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 14;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 13;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 10;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 2;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += 0;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 7;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 12;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 11;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 12;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 4;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 12;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 13;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += -8;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 13;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += -9;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 10;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 1;
            x += 11;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 1;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += 0;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 2;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += -5;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 14;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += -6;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 6;
            y *= x;
            z += y;
            w = args[argIdx++];
            x *= 0;
            x += z;
            x %= 26;
            z /= 26;
            x += -12;
            x = x == w ? 1 : 0;
            x = x == 0 ? 1 : 0;
            y *= 0;
            y += 25;
            y *= x;
            y += 1;
            z *= y;
            y *= 0;
            y += w;
            y += 14;
            y *= x;
            z += y;
            return z == 0;
        }

        int[,] par = new int[14, 3]
        {
            {1,11,8  },
            {1,14,13 },
            {1,10,2  },
            {26,0,7  },
            {1,12,11 },
            {1,12,4  },
            {1,12,13 },
            {26,-8,13},
            {26,-9,10},
            {1,11,1  },
            {26,0,2  },
            {26,-5,14},
            {26,-6,6 },
            {26,-12,1}
        };

        public bool Solve2(int[] args)
        {
            int z = 0;
            for (int i = 0; i < args.Length; i++)
            {
                z = (args[i] != (z % 26 + par[i, 1])) ? (z / par[i, 0] * (26) + (args[i] + par[i, 2])) : z;
            }
            return z == 0;
        }

        public Day24()
        {
        }

        Alu alu;

        public Day24(string code)
        {
            var prog = code.Trim().Split('\n').Select(x => x.TrimEnd().Split(' ')).ToList();
            alu = new Alu(prog);
        }

        public void Reset()
        {
            alu.Reset();
        }

        public int Solve3(int initZ, params int[] args)
        {
            alu.Reset();
            alu.z = initZ;
            alu.Execute(args);
            return alu.z;
        }

        class Decripter
        {
            Alu[] AluParts;
            Alu AluComplete;
            List<List<(int, int)>> solutions;

            public Decripter(string code)
            {
                var prog = code.Trim().Split('\n').Select(x => x.TrimEnd().Split(' ')).ToList();
                AluComplete = new Alu(prog);
                int cnt = prog.Count(x => x[0] == "inp");
                AluParts = new Alu[cnt];
                int partIdx = 0;
                int prevStart = 0;
                for (int i = 0; i < prog.Count; i++)
                {
                    if(prog[i][0] == "inp")
                    {
                        int len = i - prevStart;
                        if (len == 0) continue;
                        AluParts[partIdx] = new Alu(prog.Skip(prevStart).Take(len).ToList());
                    }
                }
                solutions=new List<List<(int, int)>>();
            }

            int TryInput(int initZ, int arg)
            {
                alu.Reset();
                alu.z = initZ;
                alu.Execute(args);
                return alu.z
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

            internal void Reset()
            {
                w = 0;
                x = 0;
                y = 0;
                z = 0;
            }
        }
    }
}