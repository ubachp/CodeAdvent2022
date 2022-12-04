using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day04 : AdventDayBase, IAdventDay
    {
        public Day04(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/4/input", Cookie);
            var inputArray = input.Split("\n");
            var totalPairs = 0;
            var totalOverlap = 0;

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var pair = line.Split(',');

                var firstRange = pair[0].Split("-");
                var secondRange = pair[1].Split("-");

                var firstRangeStart = int.Parse(firstRange[0]);
                var firstRangeEnd = int.Parse(firstRange[1]);
                var secondRangeStart = int.Parse(secondRange[0]);
                var seconRangeEnd = int.Parse(secondRange[1]);

                var firstRangeList = Enumerable.Range(firstRangeStart, firstRangeEnd - firstRangeStart + 1);
                var secondRangeList = Enumerable.Range(secondRangeStart, seconRangeEnd - secondRangeStart + 1);

                var intersectionCount1 = firstRangeList.Intersect(secondRangeList).Count();
                var intersectionCount2 = secondRangeList.Intersect(firstRangeList).Count();

                totalPairs += intersectionCount1 == firstRangeList.Count() || intersectionCount2 == secondRangeList.Count() ? 1 : 0;
                totalOverlap += intersectionCount1 > 0 || intersectionCount2 > 0 ? 1 : 0;
            }

            Helper.PrintResults("total pairs", totalPairs, "total overlap", totalOverlap);
        }
    }
}
