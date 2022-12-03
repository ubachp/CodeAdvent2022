using CodeAdvent2022.Shared;
using System.Text;

namespace CodeAdvent2022.Challenges
{
    public class Day03 : AdventDayBase, IAdventDay
    {
        public Day03(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/3/input", Cookie);
            var inputArray = input.Split("\n");
            var prioritySum = 0;
            var priorityTypeSum = 0;

            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                var firstCompartment = inputArray[i].Substring(0, inputArray[i].Length / 2);
                var secondCompartment = inputArray[i].Substring(inputArray[i].Length / 2);

                var intersection = firstCompartment.Intersect(secondCompartment);
                prioritySum += GetPriority(intersection);

                if (i % 3 == 2)
                {
                    var intersectionElf1AndElf2 = inputArray[i - 2].Intersect(inputArray[i - 1]);
                    var intersectionElf2AndElf3 = inputArray[i - 1].Intersect(inputArray[i]);
                    var intersectionElf1Elf2Elf3 = intersectionElf1AndElf2.Intersect(intersectionElf2AndElf3);

                    priorityTypeSum += GetPriority(intersectionElf1Elf2Elf3);
                }

            }

            Helper.PrintResults("priority sum", prioritySum, "priority type sum", priorityTypeSum);
        }

        private static int GetPriority(IEnumerable<char> intersection)
        {
            var commonItemByte = Encoding.ASCII.GetBytes(intersection.ToArray()).FirstOrDefault();
            if (commonItemByte >= 65 && commonItemByte <= 90)
            {
                return commonItemByte - 38;
            }
            else if (commonItemByte >= 97 && commonItemByte <= 122)
            {
                return commonItemByte - 96;
            }

            return 0;
        }
    }
}
