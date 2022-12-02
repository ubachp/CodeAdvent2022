using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day02 : AdventDayBase, IAdventDay
    {
        private readonly Dictionary<string, int> MovesPointMapping = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 3 },
            { "X", 1 },
            { "Y", 2 },
            { "Z", 3 },
        };

        public Day02(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/2/input", Cookie);
            var inputArray = input.Split("\n");
            var totalPointsPart1 = 0;
            var totalPointsPart2 = 0;

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var part1 = line.Split(' ');
                var part2 = SwitchMoveForOutcome(part1);

                var movePointPart1 = MovesPointMapping[part1[1]];
                var movePointPart2 = MovesPointMapping[part2[1]];

                var roundPointsPart1 = CalculateRoundPoints(part1);
                var roundPointsPart2 = CalculateRoundPoints(part2);

                totalPointsPart1 += movePointPart1 + roundPointsPart1;
                totalPointsPart2 += movePointPart2 + roundPointsPart2;

            }

            Helper.PrintResults("total points", totalPointsPart1, "total points", totalPointsPart2);
        }



        private static string[] SwitchMoveForOutcome(string[] round)
        {
            var switchedMove = (round[0], round[1]) switch
            {
                ("A", "X") => "Z",
                ("A", "Y") => "X",
                ("A", "Z") => "Y",
                ("B", "X") => "X",
                ("B", "Y") => "Y",
                ("B", "Z") => "Z",
                ("C", "X") => "Y",
                ("C", "Y") => "Z",
                ("C", "Z") => "X",
                _ => ""
            };

            return new string[] { round[0], switchedMove };
        }

        private static int CalculateRoundPoints(string[] round)
        {
            return (round[0], round[1]) switch
            {
                ("A", "X") => 3,
                ("A", "Y") => 6,
                ("A", "Z") => 0,
                ("B", "X") => 0,
                ("B", "Y") => 3,
                ("B", "Z") => 6,
                ("C", "X") => 6,
                ("C", "Y") => 0,
                ("C", "Z") => 3,
                _ => 0
            };
        }
    }


}

