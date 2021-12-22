namespace AocNetLib
{
    public class Day22
    {
        public string Solve(string v)
        {
            var steps = ParseInput(v);
            var map = new Map(steps);
            map.Run();
            return map.Count50().ToString();
        }
        public string Solve2(string v)
        {
            var steps = ParseInput(v);
            var map = new Map(steps);
            map.Run();
            return map.CountAll().ToString();
        }

        private List<Step> ParseInput(string input)
        {
            return input.TrimEnd().Split('\n').Select(ParseLine).ToList();
        }

        private Step ParseLine(string line)
        {
            //on x=10..12,y=10..12,z=10..12
            //0  1 2  34  5 6  78  9 101112
            var parts = line.Trim().Split(' ', ',', '.', '=');
            return new Step(parts[0] == "on",
                int.Parse(parts[2]), int.Parse(parts[4]) + 1,
                int.Parse(parts[6]), int.Parse(parts[8]) + 1,
                int.Parse(parts[10]), int.Parse(parts[12]) + 1);
        }

        public struct Step
        {
            public bool Value;
            public int X1, X2;
            public int Y1, Y2;
            public int Z1, Z2;

            public Step(bool value, int x1, int x2, int y1, int y2, int z1, int z2)
            {
                Value = value;
                X1 = x1;
                X2 = x2;
                Y1 = y1;
                Y2 = y2;
                Z1 = z1;
                Z2 = z2;
            }

            public override string ToString()
            {
                return $"{Value} {X1}..{X2},{Y1}..{Y2},{Z1}..{Z2}";
            }
        }

        class Map
        {
            List<Step> steps;
            List<int> borderX;
            List<int> borderY;
            List<int> borderZ;
            bool[,,] zones;

            public Map(List<Step> steps)
            {
                this.steps = steps;
                borderX = Enumerable.Concat(Enumerable.Concat(steps.Select(x => x.X1), steps.Select(x => x.X2)), new int[] { -50, 51 }).Distinct().OrderBy(x => x).ToList();
                borderY = Enumerable.Concat(Enumerable.Concat(steps.Select(x => x.Y1), steps.Select(x => x.Y2)), new int[] { -50, 51 }).Distinct().OrderBy(x => x).ToList();
                borderZ = Enumerable.Concat(Enumerable.Concat(steps.Select(x => x.Z1), steps.Select(x => x.Z2)), new int[] { -50, 51 }).Distinct().OrderBy(x => x).ToList();
                zones = new bool[borderX.Count - 1, borderY.Count - 1, borderZ.Count - 1];
            }

            void ExecuteStep(Step s)
            {
                int x1 = borderX.IndexOf(s.X1);
                int x2 = borderX.IndexOf(s.X2);
                int y1 = borderY.IndexOf(s.Y1);
                int y2 = borderY.IndexOf(s.Y2);
                int z1 = borderZ.IndexOf(s.Z1);
                int z2 = borderZ.IndexOf(s.Z2);
                for (int x = x1; x < x2; x++)
                {
                    for (int y = y1; y < y2; y++)
                    {
                        for (int z = z1; z < z2; z++)
                        {
                            zones[x, y, z] = s.Value;
                        }
                    }
                }
            }

            public void Run()
            {
                foreach (var step in steps)
                {
                    ExecuteStep(step);
                }
            }

            public long Count50()
            {
                long sum = 0;
                int x1 = borderX.IndexOf(-50);
                int x2 = borderX.IndexOf(51);
                int y1 = borderY.IndexOf(-50);
                int y2 = borderY.IndexOf(51);
                int z1 = borderZ.IndexOf(-50);
                int z2 = borderZ.IndexOf(51);
                for (int x = x1; x < x2; x++)
                {
                    for (int y = y1; y < y2; y++)
                    {
                        for (int z = z1; z < z2; z++)
                        {
                            if(zones[x, y, z])
                            {
                                int dx = borderX[x + 1] - borderX[x];
                                int dy = borderY[y + 1] - borderY[y];
                                int dz = borderZ[z + 1] - borderZ[z];
                                sum += (long)dx * dy * dz;
                            }
                        }
                    }
                }
                return sum;
            }

            public long CountAll()
            {
                long sum = 0;
                for (int x = 0; x < borderX.Count-1; x++)
                {
                    for (int y = 0; y < borderY.Count-1; y++)
                    {
                        for (int z = 0; z < borderZ.Count-1; z++)
                        {
                            if (zones[x, y, z])
                            {
                                int dx = borderX[x + 1] - borderX[x];
                                int dy = borderY[y + 1] - borderY[y];
                                int dz = borderZ[z + 1] - borderZ[z];
                                sum += (long)dx * dy * dz;
                            }
                        }
                    }
                }
                return sum;
            }
        }

    }
}