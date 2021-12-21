namespace AocNetLib
{
    public class Day19
    {


        public string Solve(string v)
        {
            var scanners = ParseInput(v);
            Scanner merged = new Scanner(-1) { IsAligned = true };
            scanners[0].IsAligned = true;
            scanners[0].UpdateDirection(0);
            merged.MergeFrom(scanners[0]);
            do
            {
                var notMerged = scanners.Where(x => !x.IsAligned).ToList();
                foreach (var sc in notMerged)
                {
                    if(merged.TryAlign(sc))
                    {
                        sc.IsAligned = true;
                        merged.MergeFrom(sc);
                    }
                }
            } while (!scanners.All(x => x.IsAligned));
            return merged.Beacons.Count.ToString();
        }

        private List<Scanner> ParseInput(string input)
        {
            var lines = input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            List<Scanner> ret = new List<Scanner>();
            Scanner scanner = null;
            int scanIdx = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("---"))
                {
                    scanner = new Scanner(scanIdx++);
                    ret.Add(scanner);
                }
                else if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    var parts = lines[i].Split(',').Select(int.Parse).ToArray();
                    scanner.Beacons.Add(new Beacon(parts[0], parts[1], parts[2], scanner));
                }
            }
            return ret;
        }

        class Scanner
        {
            public Scanner(int idx)
            {
                Idx = idx;
                Beacons = new List<Beacon>();
            }

            public int Idx { get; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int D { get; private set; }

            public List<Beacon> Beacons { get; }

            public bool IsAligned { get; set; }

            public void MergeFrom(Scanner sc)
            {
                foreach (var b in sc.Beacons)
                {
                    if(!Beacons.Any(x=>b.IsSamePosition(x))) Beacons.Add(b);
                }
            }

            internal bool TryAlign(Scanner sc)
            {
                for (int i = 0; i < 24; i++)
                {
                    sc.UpdateDirection(i);
                    foreach (var baseBeacon in Beacons)
                    {
                        foreach (var oppBeacon in sc.Beacons)
                        {
                            sc.X = X + baseBeacon.AbsX - oppBeacon.TransfX;
                            sc.Y = Y + baseBeacon.AbsY - oppBeacon.TransfY;
                            sc.Z = Z + baseBeacon.AbsZ - oppBeacon.TransfZ;
                            int cnt = CountMatching(sc);
                            if (cnt > 1) Console.WriteLine($"Sc:{sc.Idx} Dir:{i} Match:{cnt}");
                            if (cnt >= 12) return true;
                        }
                    }
                }
                return false;
            }

            int CountMatching(Scanner sc)
            {
                int cnt = 0;
                foreach (var b in sc.Beacons)
                {
                    if (Beacons.Any(x => b.IsSamePosition(x))) cnt++;
                }
                return cnt;
            }

            public void UpdateDirection(int d)
            {
                D = d;
                Beacons.ForEach(x => x.UpdateAbs());
            }
        }

        class Beacon
        {
            public Scanner Parent { get; }
            public int RelX { get; }
            public int RelY { get; }
            public int RelZ { get; }
            public int TransfX { get; set; }
            public int TransfY { get; set; }
            public int TransfZ { get; set; }

            public int AbsX => TransfX + Parent.X;
            public int AbsY => TransfY + Parent.Y;
            public int AbsZ => TransfZ + Parent.Z;

            public Beacon(int x, int y, int z, Scanner sc)
            {
                RelX = x;
                RelY = y;
                RelZ = z;
                Parent = sc;
            }

            public void UpdateAbs()
            {
                (TransfX, TransfY, TransfZ) = Transform.Rotate(RelX, RelY, RelZ, Parent.D);
            }

            public bool IsSamePosition(Beacon b)
            {
                return b.AbsX == AbsX && b.AbsY == AbsY && b.AbsZ == AbsZ;
            }
        }

        static class Transform
        {
            /// <summary>
            /// </summary>
            /// <param name="x">X</param>
            /// <param name="y">Y</param>
            /// <param name="z">Z</param>
            /// <param name="d">Direction 0..23</param>
            /// <returns></returns>
            public static (int, int, int) Rotate(int x, int y, int z, int d)
            {
                int x1, y1, z1;
                switch ((d >> 3) & 3)
                {
                    case 0: x1 = x; y1 = y; z1 = z; break;
                    case 1: x1 = y; y1 = z; z1 = x; break;
                    default: x1 = z; y1 = x; z1 = y; break;
                }
                if((d & (1 << 2)) != 0)
                {
                    int tmp = y1;
                    y1 = z1;
                    z1 = tmp;
                }
                if ((d & (1 << 1)) != 0) x1 = -x1;
                if ((d & (1 << 0)) != 0) y1 = -y1;
                int sign = (d & 7);
                sign = ((sign >> 2) ^ (sign >> 1) ^ sign) & 1;
                if(sign == 1) z1 = -z1;
                return (x1, y1, z1);
            }
        }
    }
}