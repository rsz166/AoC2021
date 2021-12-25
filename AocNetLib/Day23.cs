namespace AocNetLib
{
    public class Day23
    {
        public string Solve(string v)
        {
            //var absSolver = AbstractSolver.ParseInput(v);
            //var absSolutions = absSolver.Solve();
            var solver = Solver2.ParseInput(v);
            int minResult = int.MaxValue;
            //foreach (var absSol in absSolutions)
            //var absSol = absSolutions.First();
            {
                int result = solver.Solve();
                if(result < minResult) minResult = result;
            }
            return minResult.ToString();
        }

        public string Solve2(string v)
        {
            throw new NotImplementedException();
        }

        public class Solver2
        {
            const int BuffY = 1;
            const int Width = 13;
            const int Height = 5;
#if DEBUG_MSG
            static int GlobalCounter = 0;
#endif
            char[,] initFields;
            char[,] fields;
            List<int> bufferPositions;
            const int SocketCount = 4;
            int[] costs = new int[] { 1, 10, 100, 1000 };
#if DEBUG_MSG
            List<(int, int, int, int)> moves;
            List<(List<(int, int, int, int)>, int)> solutions;
#endif

            public Solver2()
            {
                initFields = new char[Height, Width];
                fields = new char[Height, Width];
                bufferPositions = new List<int>() { 1, 2, 4, 6, 8, 10, 11 };
#if DEBUG_MSG
                moves = new List<(int, int, int, int)>();
                solutions = new List<(List<(int, int, int, int)>,int)>();
#endif
            }

            public int Solve()
            {
                Initialize();
                //PrintField();
                var ret = StepRecursive();
#if DEBUG_MSG
                File.WriteAllLines("result.txt", solutions.Select(sol =>
                    string.Format("{0} {1}",string.Join(" ", sol.Item1.Select(mov => $"{mov.Item1},{mov.Item2}>{mov.Item3},{mov.Item4}")), sol.Item2)
                    ));
#endif
                return ret;
            }

            int StepRecursive(int idx = 0, int cost = 0)
            {
#if DEBUG_MSG
                Console.WriteLine(++GlobalCounter);
                if (GlobalCounter > 100) throw new Exception("Too many iterations");
#endif
                if (CheckComplete())
                {
#if DEBUG_MSG
                    solutions.Add((moves.ToList(), cost));
#endif
                    return cost;
                }
                int minCost = int.MaxValue;
                var steps = GetSteps();
                foreach (var step in steps)
                {
                    int newCost = cost + GetCost(step);
                    Move(step);
#if DEBUG_MSG
                    PrintField();
#endif
                    newCost = StepRecursive(idx + 1, newCost);
                    UnMove(step);
#if DEBUG_MSG
                    Console.WriteLine("<");
#endif
                    if (newCost < minCost) minCost = newCost;
                }
                return minCost;
            }

            private int GetCost((int, int, int, int) step)
            {
                return (Math.Abs(step.Item1 - step.Item3) + Math.Abs(step.Item2 - step.Item4)) * costs[fields[step.Item2, step.Item1]-'A'];
            }

            private void UnMove((int, int, int, int) step)
            {
#if DEBUG_MSG
                moves.RemoveAt(moves.Count - 1);
#endif
                fields[step.Item2, step.Item1] = fields[step.Item4, step.Item3];
                fields[step.Item4, step.Item3] = '.';
            }

            private void Move((int, int, int, int) step)
            {
#if DEBUG_MSG
                moves.Add(step);
#endif
                fields[step.Item4, step.Item3] = fields[step.Item2, step.Item1];
                fields[step.Item2, step.Item1] = '.';
            }

            private List<(int, int, int, int)> GetSteps()
            {
                List<(int, int, int, int)> ret = new List<(int, int, int, int)>();
                var good = GetIsSocketGood();
                // try move in
                for (int sockId = 0; sockId < SocketCount; sockId++)
                {
                    if (good[sockId])
                    {
                        int sockX = GetX(sockId);
                        int buffX = GetBuffX(sockX, (char)(sockId+'A'));
                        if (buffX >= 0)
                        {
                            if (CheckPath(sockX, buffX))
                            {
                                int sockY = GetY(sockX, false);
                                ret.Add((buffX, BuffY, sockX, sockY));
                            }
                        }
                    }
                }
                if (ret.Count > 0) return ret;
                // try move out
                for (int sockId = 0; sockId < SocketCount; sockId++)
                {
                    if (!good[sockId])
                    {
                        int sockX = GetX(sockId);
                        int sockY = GetY(sockX, true);
                        var buffXs = GetAccessibleBuffX(sockX);
                        ret.AddRange(buffXs.Select(x => (sockX, sockY, x, BuffY)));
                    }
                }
                return ret;
            }

            private List<int> GetAccessibleBuffX(int sockX)
            {
                List<int> ret = new List<int>();
                int buffIdxDown = bufferPositions.IndexOf(sockX - 1);
                int buffIdxUp = buffIdxDown + 1;
                while (buffIdxDown >= 0 && fields[BuffY, bufferPositions[buffIdxDown]] == '.')
                {
                    ret.Add(bufferPositions[buffIdxDown]);
                    buffIdxDown--;
                }
                while (buffIdxUp < bufferPositions.Count && fields[BuffY, bufferPositions[buffIdxUp]] == '.')
                {
                    ret.Add(bufferPositions[buffIdxUp]);
                    buffIdxUp++;
                }
                return ret;
            }

            private bool CheckPath(int sockX, int buffX)
            {
                int step = sockX < buffX ? 1 : -1;
                while (sockX != buffX)
                {
                    if (fields[BuffY, sockX] != '.') return false;
                    sockX += step;
                }
                return true;
            }

            int GetBuffX(int sockX, char value)
            {
                int buffX = -1;
                int minDist = int.MaxValue;
                for (int i = 0; i < bufferPositions.Count; i++)
                {
                    int x = bufferPositions[i];
                    if (fields[BuffY, x] == value)
                    {
                        int dist = Math.Abs(x - sockX);
                        if (dist < minDist)
                        {
                            buffX = x;
                            minDist = dist;
                        }
                    }
                }
                return buffX;
            }

            private static int GetX(int sockedId)
            {
                return sockedId * 2 + 3;
            }

            private int GetY(int sockX, bool isOccupied)
            {
                int sockY = Height - 2;
                while (fields[sockY, sockX] != '.') sockY--;
                if(isOccupied) sockY++;
                if (sockY <= 1) return -1;
                return sockY;
            }

            void PrintField()
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write(fields[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            private bool[] GetIsSocketGood()
            {
                bool[] ret = new bool[SocketCount];
                for (int i = 0; i < SocketCount; i++) ret[i] = GetIsSocketGood(i);
                return ret;
            }

            private bool GetIsSocketGood(int sockId)
            {
                char c = (char)('A' + sockId);
                int x = sockId * 2 + 3;
                for (int y = 2; y < Height - 1; y++)
                {
                    if (fields[y, x] != c && fields[y, x] != '.') return false;
                }
                return true;
            }

            private bool CheckComplete()
            {
                for (int j = 3; j < Width - 3; j += 2)
                {
                    char c = (char)('A' + (j - 3) / 2);
                    for (int i = 2; i < Height - 1; i++)
                    {
                        if (fields[i, j] != c) return false;
                    }
                }
                return true;
            }

            void Initialize()
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        fields[i, j] = initFields[i, j];
                    }
                }
            }

            public static Solver2 ParseInput(string input)
            {
                var lines = input.TrimEnd().Split('\n').Select(x => x.TrimEnd()).ToArray();
                var ret = new Solver2();
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        char c = j < lines[i].Length ? lines[i][j] : '#';
                        if (c == ' ') c = '#';
                        ret.initFields[i, j] = c;
                    }
                }
                return ret;
            }
        }
    }
}