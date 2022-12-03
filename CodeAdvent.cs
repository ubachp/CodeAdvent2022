using CodeAdvent2022.Challenges;

namespace CodeAdvent2022
{
    public class CodeAdvent
    {
        public static string Cookie { get; set; }
        public static async Task Run()
        {
            await new Day01(Cookie).Solve();
            await new Day02(Cookie).Solve();
            await new Day03(Cookie).Solve();
            await new Day04(Cookie).Solve();
        }
    }
}
