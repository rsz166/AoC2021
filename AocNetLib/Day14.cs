using System.Text;

namespace AocNetLib
{
    public class Day14
    {
        public string Solve(string input, int iterations)
        {
            var poly = ParseInput(input);
            for (int i = 0; i < iterations; i++)
            {
                poly.Iterate();
            }
            return poly.GetCountDiff().ToString();
        }

        private Polymer ParseInput(string input)
        {
            var lines = input.Split(new char[] { '\n' }).Select(x => x.Trim()).ToArray();
            var rules = new Dictionary<string, char>(lines.Skip(2).Where(x=>!string.IsNullOrWhiteSpace(x)).Select(x => new KeyValuePair<string, char>(x.Substring(0, 2), x.Last())));
            return new Polymer(lines.First(), rules);
        }

        class Polymer
        {
            long[] pairCounts;
            int[,] ruleTable;
            List<string> indexes;

            public Polymer(string str, Dictionary<string, char> rules)
            {
                int size = rules.Count;
                pairCounts = new long[size];
                ruleTable = new int[size, 2];
                indexes = rules.Keys.ToList();
                for (int i = 0; i < size; i++)
                {
                    var rule = rules.ElementAt(i);
                    var part1 = indexes.IndexOf(String.Concat(rule.Key[0], rule.Value));
                    var part2 = indexes.IndexOf(String.Concat(rule.Value, rule.Key[1]));
                    ruleTable[i, 0] = part1;
                    ruleTable[i, 1] = part2;
                }
                for (int i = 0; i < str.Length-1; i++)
                {
                    var idx = indexes.IndexOf(str.Substring(i, 2));
                    pairCounts[idx]++;
                }
            }

            public void Iterate()
            {
                var countsCopy = pairCounts.ToArray();
                for (int i = 0; i < countsCopy.Length; i++)
                {
                    pairCounts[i] -= countsCopy[i];
                    pairCounts[ruleTable[i, 0]] += countsCopy[i];
                    pairCounts[ruleTable[i, 1]] += countsCopy[i];
                }
            }

            public long GetCountDiff()
            {
                long[] chars = new long['Z' - 'A' + 1];
                for (int i = 0; i < indexes.Count; i++)
                {
                    var s = indexes[i];
                    chars[s[0] - 'A'] += pairCounts[i];
                    chars[s[1] - 'A'] += pairCounts[i];
                }
                var max = (chars.Max()+1)/2;
                var min = (chars.Where(x=>x!=0).Min()+1)/2;
                return max - min;
            }
        }
    }
}