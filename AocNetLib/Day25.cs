namespace AocNetLib
{
    public class Day25
    {
        public string Solve(string v)
        {
            var map = ParseInput(v);
            //Console.WriteLine(map);
            int cnt = 0;
            bool isMoved;
            do
            {
                isMoved = false;
                if (map.Move('>')) isMoved = true;
                if (map.Move('v')) isMoved = true;
                cnt++;
                //Console.WriteLine(cnt);
                //Console.WriteLine(map);
            } while (isMoved);
            return cnt.ToString();
        }

        Map ParseInput(string input)
        {
            return new Map(input.TrimEnd().Split(new char[] { '\n' }).Select(x => x.Trim().ToCharArray()).ToArray());
        }

        class Map
        {
            int Width, Height;
            char[][] map;
            char[][] cache;
            public Map(char[][] map)
            {
                this.map = map;
                Height = map.Length;
                Width = map[0].Length;
                cache = new char[Height][];
                for (int i = 0; i < Height; i++)
                {
                    cache[i] = new char[Width];
                }
            }

            void CopyCache()
            {
                for (int r = 0; r < Height; r++)
                {
                    for (int c = 0; c < Width; c++)
                    {
                        cache[r][c] = map[r][c];
                    }
                }
            }

            public bool Move(char target)
            {
                CopyCache();
                bool moved = false;
                for (int r = 0; r < Height; r++)
                {
                    for (int c = 0; c < Width; c++)
                    {
                        if (map[r][c] == target)
                        {
                            if(target == '>')
                            {
                                if (map[r][(c + 1)%Width] == '.')
                                {
                                    cache[r][(c + 1) % Width] = target;
                                    cache[r][c] = '.';
                                    moved = true;
                                }
                            }
                            else
                            {
                                if (map[(r+1)%Height][c] == '.')
                                {
                                    cache[(r + 1) % Height][c] = target;
                                    cache[r][c] = '.';
                                    moved = true;
                                }
                            }
                        }
                    }
                }
                var tmp = map;
                map = cache;
                cache = tmp;
                return moved;
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, map.Select(x=>string.Concat(x)));
            }
        }
    }
}