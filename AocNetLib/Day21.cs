namespace AocNetLib
{
    public class Day21
    {
        int p1Pos;
        int p2Pos;

        public string Solve(string v)
        {
            ParseInput(v);
            var game = new Game1(p1Pos, p2Pos);
            game.Run();
            return game.Result.ToString();
        }

        public string Solve2(string v)
        {
            ParseInput(v);
            var game = new Game2(p1Pos, p2Pos);
            game.Run();
            return game.Result.ToString();
        }


        private void ParseInput(string input)
        {
            var lines = input.TrimEnd().Split(new char[] { '\n' }).Select(x => x.Trim()).ToArray();
            p1Pos = int.Parse(lines[0].Split(':').Last().Trim());
            p2Pos = int.Parse(lines[1].Split(':').Last().Trim());
        }

        class Game1
        {
            int p1Pos;
            int p2Pos;
            int p1Score;
            int p2Score;
            int rollCnt;
            int dice;

            public int Result => Math.Min(p1Score, p2Score) * rollCnt;

            public Game1(int p1Pos, int p2Pos)
            {
                this.p1Pos = p1Pos;
                this.p2Pos = p2Pos;
            }

            public void Run()
            {
                while (true)
                {
                    if (StepPlayer(ref p1Pos, ref p1Score, RollDice3())) break;
                    if (StepPlayer(ref p2Pos, ref p2Score, RollDice3())) break;
                    Console.WriteLine($"[{rollCnt,5}] p1:{p1Pos} ({p1Score}) p2:{p2Pos} ({p2Score})");
                }
                int score = (p1Score >= 1000) ? p2Score : p1Score;
            }

            private bool StepPlayer(ref int pos, ref int score, int dice)
            {
                pos = (pos + dice - 1) % 10 + 1;
                score += pos;
                return score >= 1000;
            }

            private int RollDice()
            {
                dice++;
                if (dice > 100) dice = 1;
                rollCnt++;
                return dice;
            }

            private int RollDice3()
            {
                return RollDice() + RollDice() + RollDice();
            }
        }
        class Game2
        {
            const int DiceMaxValue = 3;
            const int MaxScore = 21;
            const int MaxPos = 10;
            /// <summary>
            /// stateTable[pos1-1,score1,pos2-1,score2] = number of games in this state
            /// if score reach MaxScore, game ends
            /// </summary>
            long[,,,] stateTable;
            long[,,,] nextStateTable;
            int[] diceCounts;

            public long Result
            {
                get
                {
                    long p1 = GetWinCount(true);
                    long p2 = GetWinCount(false);
                    return Math.Max(p1, p2);
                }
            }

            public Game2(int p1Pos, int p2Pos)
            {
                stateTable = new long[MaxPos, MaxScore + 1, MaxPos, MaxScore + 1];
                nextStateTable = new long[MaxPos, MaxScore + 1, MaxPos, MaxScore + 1];
                stateTable[p1Pos - 1, 0, p2Pos - 1, 0] = 1;
                PrepareDices();
            }

            private void PrepareDices()
            {
                // this will lead to 3 starting zeros
                diceCounts = new int[3 * DiceMaxValue + 1];
                for (int d1 = 1; d1 <= DiceMaxValue; d1++)
                {
                    for (int d2 = 1; d2 <= DiceMaxValue; d2++)
                    {
                        for (int d3 = 1; d3 <= DiceMaxValue; d3++)
                        {
                            diceCounts[d1 + d2 + d3]++;
                        }
                    }
                }
            }

            public void Run()
            {
                do
                {
                    StepGame();
                } while (CheckRunning());
            }

            private bool CheckRunning()
            {
                for (int p1 = 0; p1 < MaxPos; p1++)
                {
                    for (int s1 = 0; s1 < MaxScore; s1++)
                    {
                        for (int p2 = 0; p2 < MaxPos; p2++)
                        {
                            for (int s2 = 0; s2 < MaxScore; s2++)
                            {
                                if (stateTable[p1, s1, p2, s2] > 0) return true;
                            }
                        }
                    }
                }
                return false;
            }

            private void StepGame()
            {
                ClearNextState();
                CalculateNextState(true);
                ClearNextState();
                CalculateNextState(false);
            }

            private void CalculateNextState(bool isP1)
            {
                for (int p1 = 0; p1 < MaxPos; p1++)
                {
                    for (int s1 = 0; s1 < MaxScore; s1++)
                    {
                        for (int p2 = 0; p2 < MaxPos; p2++)
                        {
                            for (int s2 = 0; s2 < MaxScore; s2++)
                            {
                                var gameCount = stateTable[p1, s1, p2, s2];
                                if (gameCount > 0)
                                {
                                    if (isP1)
                                    {
                                        for (int step = 1; step < diceCounts.Length; step++)
                                        {
                                            int p1Next = (p1 + step) % MaxPos;
                                            int s1Next = s1 + p1Next + 1;
                                            if (s1Next > MaxScore) s1Next = MaxScore;
                                            nextStateTable[p1Next, s1Next, p2, s2] += gameCount * diceCounts[step];
                                        }
                                    }
                                    else
                                    {
                                        for (int step = 1; step < diceCounts.Length; step++)
                                        {
                                            int p2Next = (p2 + step) % MaxPos;
                                            int s2Next = s2 + p2Next + 1;
                                            if (s2Next > MaxScore) s2Next = MaxScore;
                                            nextStateTable[p1, s1, p2Next, s2Next] += gameCount * diceCounts[step];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // copy finished games
                for (int p1 = 0; p1 < MaxPos; p1++)
                {
                    for (int p2 = 0; p2 < MaxPos; p2++)
                    {
                        for (int sx = 0; sx < MaxScore; sx++)
                        {
                            nextStateTable[p1, MaxScore, p2, sx] += stateTable[p1, MaxScore, p2, sx];
                            nextStateTable[p1, sx, p2, MaxScore] += stateTable[p1, sx, p2, MaxScore];
                        }
                    }
                }
                var tmp = stateTable;
                stateTable = nextStateTable;
                nextStateTable = tmp;
                Console.WriteLine("Wins: {0} - {1}", GetWinCount(true), GetWinCount(false));
            }

            private void ClearNextState()
            {
                for (int p1 = 0; p1 < MaxPos; p1++)
                {
                    for (int s1 = 0; s1 <= MaxScore; s1++)
                    {
                        for (int p2 = 0; p2 < MaxPos; p2++)
                        {
                            for (int s2 = 0; s2 <= MaxScore; s2++)
                            {
                                nextStateTable[p1, s1, p2, s2] = 0;
                            }
                        }
                    }
                }
            }

            private long GetWinCount(bool isP1)
            {
                long sum = 0;
                for (int p1 = 0; p1 < MaxPos; p1++)
                {
                    for (int p2 = 0; p2 < MaxPos; p2++)
                    {
                        for (int sx = 0; sx < MaxScore; sx++)
                        {
                            if (isP1) sum += stateTable[p1, MaxScore, p2, sx];
                            else sum += stateTable[p1, sx, p2, MaxScore];
                        }
                    }
                }
                return sum;
            }
        }
    }
}