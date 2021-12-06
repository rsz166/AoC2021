namespace AocNetLib
{
    public class Day6
    {
        public string Solve(string input, int days)
        {
            School school = ParseInput(input);
            for (int day = 0; day < days; day++)
            {
                school.Iterate();
            }
            return school.Count.ToString();
        }

        private School ParseInput(string input)
        {
            return new School(input.Split(',').Select(x => int.Parse(x)));
        }

        class School
        {
            long[] schoolGroups;

            public long Count => schoolGroups.Sum();

            public School(IEnumerable<int> list)
            {
                schoolGroups = new long[9];
                foreach (int i in list)
                {
                    schoolGroups[i]++;
                }
            }

            public void Iterate()
            {
                long zeros = schoolGroups[0];
                for (int i = 1; i < schoolGroups.Length; i++)
                {
                    schoolGroups[i - 1] = schoolGroups[i];
                }
                schoolGroups[schoolGroups.Length - 1] = 0;
                schoolGroups[8] += zeros;
                schoolGroups[6] += zeros;
            }
        }
    }
}