using System.Diagnostics.CodeAnalysis;

namespace AocNetLib
{
    public class Day19
    {
        readonly int[] FinalSolutionD = new int[] { 0, 4, 9, 21, 22, 11, 6, 5, 2, 23, 8, 13, 18, 10, 19, 17, 20, 15, 12, 1, 16, 7, 14, 3, 6, 3, 10, 8, 21, 11, 12, 0, 9, 5, 5, 22, 5, 16, 12, 10 };

        void UpdateDirections(List<Scanner> scanners)
        {
            for (int i = 1; i < scanners.Count; i++)
            {
                scanners[i].UpdateDirection(FinalSolutionD[i]);
            }
        }

        public string Solve(string v, bool isFinal = false)
        {
            var scanners = ParseInput(v);
            if(isFinal) UpdateDirections(scanners);
            Scanner merged = MergeScanners(scanners, isFinal);
            return merged.Beacons.Count.ToString();
        }

        public string Solve2(string v, bool isFinal = false)
        {
            var scanners = ParseInput(v);
            if(isFinal) UpdateDirections(scanners);
            Scanner merged = MergeScanners(scanners, isFinal);
            int max = GetMaxDist(scanners);
            return max.ToString();
        }

        private static int GetMaxDist(List<Scanner> scanners)
        {
            int max = 0;
            for (int i = 0; i < scanners.Count; i++)
            {
                for (int j = 0; j < scanners.Count; j++)
                {
                    int d = scanners[i].GetDistance(scanners[j]);
                    if (d > max) max = d;
                }
            }
            return max;
        }

        private static Scanner MergeScanners(List<Scanner> scanners, bool isFinal)
        {
            Scanner merged = new Scanner(-1) { IsAligned = true };
            scanners[0].IsAligned = true;
            scanners[0].UpdateDirection(0);
            merged.MergeFrom(scanners[0]);
            do
            {
                var notMerged = scanners.Where(x => !x.IsAligned).ToList();
                foreach (var sc in notMerged)
                {
                    if (merged.TryAlign(sc, isFinal))
                    {
                        sc.IsAligned = true;
                        merged.MergeFrom(sc);
                    }
                }
            } while (!scanners.All(x => x.IsAligned));
            return merged;
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
            List<Distance> distances;
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

            internal bool TryAlign(Scanner sc, bool isFinal)
            {
                if (isFinal)
                {
                    if (CheckAlign(sc)) return true;
                }
                else
                {
                    for (int i = 0; i < 24; i++)
                    {
                        sc.UpdateDirection(i);
                        if (CheckAlign(sc)) return true;
                    }
                }
                return false;
            }

            bool CheckAlign(Scanner sc)
            {
                foreach (var baseBeacon in Beacons)
                {
                    foreach (var oppBeacon in sc.Beacons)
                    {
                        sc.X = X + baseBeacon.AbsX - oppBeacon.TransfX;
                        sc.Y = Y + baseBeacon.AbsY - oppBeacon.TransfY;
                        sc.Z = Z + baseBeacon.AbsZ - oppBeacon.TransfZ;
                        int cnt = CountMatching(sc);
                        if (cnt > 1) Console.WriteLine($"Sc:{sc.Idx} Dir:{sc.D} Match:{cnt} Pos:{sc.X},{sc.Y},{sc.Z}");
                        if (cnt >= 12) return true;
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

            public void UpdateDistances()
            {
                List<Distance> dist = new List<Distance>();
                for(int i = 0; i < Beacons.Count; i++)
                {
                    for (int j = i+1; j < Beacons.Count; j++)
                    {
                        dist.Add(Beacons[i] - Beacons[j]);
                    }
                }
                distances = dist.OrderBy(x => x.D).ToList();
            }

            public int GetDistance(Scanner sc)
            {
                return Math.Abs(X - sc.X) + Math.Abs(Y - sc.Y) + Math.Abs(Z - sc.Z);
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

            public static Distance operator -(Beacon a, Beacon b)
            {
                return new Distance(a, b);
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

        struct Distance
        {
            public int x, y, z;
            Beacon a, b;

            public Distance(Beacon a, Beacon b)
            {
                this.a = a;
                this.b = b;
                x = a.AbsX - b.AbsX;
                y = a.AbsY - b.AbsY;
                z = a.AbsZ - b.AbsZ;
            }

            public int D => Math.Abs(x) + Math.Abs(y)+ Math.Abs(z);

            // lazy comparison for fast filtering
            public static bool operator ==(Distance a, Distance b)
            {
                if(Math.Abs(a.D) != Math.Abs(b.D)) return false;
                int ax = Math.Abs(a.x);
                int ay = Math.Abs(a.y);
                int az = Math.Abs(a.z);
                int bx = Math.Abs(b.x);
                int by = Math.Abs(b.y);
                int bz = Math.Abs(b.z);
                if (ax != bx || ax != by || ax != bz) return false;
                if (ay != bx || ay != by || ay != bz) return false;
                if (az != bx || az != by || az != bz) return false;
                return true;
            }

            public static bool operator !=(Distance a, Distance b)
            {
                return !(a == b);
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                return base.Equals(obj);
            }
        }
    }
}