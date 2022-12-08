using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day08 : AdventDayBase, IAdventDay
    {
        private List<List<int>> _grid = new();
        public Day08(string cookie) : base(cookie)
        {
        }


        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/8/input", Cookie);

//            input = @"30373
//25512
//65332
//33549
//35390";

            LoadGrid(input);

            var (totalVisibleTrees, totalScenic) = CheckInteriorTrees();

            var outbound = (2*_grid.Count) + (2*_grid[0].Count-4);
            Helper.PrintResults("total visible", totalVisibleTrees + outbound, "scenic", totalScenic);
        }

        private (int, int) CheckInteriorTrees()
        {
            var total = 0;
            var totalScenic = 0;
            for (int i = 1; i < _grid.Count-1; i++)
            {
                
                for (int j = 1; j < _grid[i].Count-1; j++)
                {
                    
                    var visible = IsVisible(i, j);
                    total += visible ? 1 : 0;

                    var scenic = CheckScenic(i, j);
                    totalScenic = scenic > totalScenic ? scenic : totalScenic;

                    //Console.Write(visible ? "x" : _grid[i][j]);
                }
                //Console.WriteLine();
            }
            return (total, totalScenic);
        }

        private int CheckScenic(int row, int col)
        {
            var height = _grid[row][col];
            bool visibleLeft = true;
            bool visibleRight = true;
            bool visibleTop = true;
            bool visibleDown = true;
            var scenicScore = 0;
            var scenicTop = 0;
            var scenicDown = 0;
            var scenicLeft = 0;
            var scenicRight = 0;

            //check left
            for (int i = col-1; i >= 0; i--)
            {
                var x = _grid[row][i];
                scenicLeft++;
                if (height <=x)
                {
                    visibleLeft = false;
                    break;
                }
            }

            //check right
            for (int i = col +1 ; i < _grid[0].Count; i++)
            {
                var x = _grid[row][i];
                scenicRight++;
                if (height <= x)
                {
                    visibleRight = false;
                    break;
                }
            }

            //check top
            for (int i = row - 1; i >= 0; i--)
            {
                var x = _grid[i][col];
                scenicTop++;
                if (height <= x)
                {
                    visibleTop = false;
                    break;
                }

            }

            //check down
            for (int i = row + 1; i < _grid.Count; i++)
            {
                var x = _grid[i][col];
                scenicDown++;
                if (height <= x)
                {
                    visibleDown = false;
                    break;
                }
            }

            return scenicTop * scenicDown * scenicLeft * scenicRight;

        }

        private bool IsVisible(int row, int col)
        {
            var height = _grid[row][col];
            bool visibleLeft = true;
            bool visibleRight = true;
            bool visibleTop = true;
            bool visibleDown = true;

            //check left
            for (int i = col - 1; i >= 0; i--)
            {
                var x = _grid[row][i];
                if (height <= x)
                {
                    visibleLeft = false;
                    break;
                }
            }

            //check right
            for (int i = col + 1; i < _grid[0].Count; i++)
            {
                var x = _grid[row][i];
                if (height <= x)
                {
                    visibleRight = false;
                    break;
                }
            }

            //check top
            for (int i = row - 1; i >= 0; i--)
            {
                var x = _grid[i][col];
                if (height <= x)
                {
                    visibleTop = false;
                    break;
                }
            }

            //check down
            for (int i = row + 1; i < _grid.Count; i++)
            {
                var x = _grid[i][col];
                if (height <= x)
                {
                    visibleDown = false;
                    break;
                }
            }

            return visibleLeft || visibleRight || visibleTop || visibleDown;

        }

        private void LoadGrid(string input)
        {
            var inputArray = input.Replace("\r", string.Empty).Split("\n");

            foreach (var row in inputArray)
            {
                if (string.IsNullOrWhiteSpace(row)) continue;
                var r = new List<int>();
                foreach (var tree in row)
                {
                    r.Add(tree-48);
                }
                _grid.Add(r);
            }
        }
    }
}
