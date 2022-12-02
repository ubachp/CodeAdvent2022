using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day01 : AdventDayBase, IAdventDay
    {
        public Day01(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/1/input", Cookie);
            var totals = new List<int>();

            var inputArray = input.Split("\n");
            var elfTotal = 0;
            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    totals.Add(elfTotal);
                    elfTotal = 0;
                }
                else
                {
                    elfTotal += int.Parse(line);
                }
            }

            var sorted = totals.OrderByDescending(x => x);

            var first = sorted.First();
            var totalThree = sorted.Take(3).Sum(x => x);

            Helper.PrintResults("top calories", first, "top 3 total calories", totalThree);
        }
    }
}
