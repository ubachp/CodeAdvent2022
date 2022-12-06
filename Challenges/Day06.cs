using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day06 : AdventDayBase, IAdventDay
    {
        public Day06(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/6/input", Cookie);

            int i = 4;
            for (i = 4; i < input.Length; i++)
            {
                var marker = input.Substring(i - 4, 4);

                var allUnique = marker.Distinct().Count() == 4;

                if (allUnique) break;
            }

            int j = 14;
            for (j = 14; j < input.Length; j++)
            {
                var marker = input.Substring(j - 14, 14);

                var allUnique = marker.Distinct().Count() == 14;

                if (allUnique) break;
            }


            Helper.PrintResults("after 4", i, "after 14", j);
        }

        
    }
}
