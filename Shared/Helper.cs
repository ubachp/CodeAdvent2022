namespace CodeAdvent2022.Shared
{
    public static class Helper
    {
        public static async Task<string> GetInput(string url, string cookie)
        {
            string html = string.Empty;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("cookie", cookie);
            var response = await client.GetAsync(url);

            var input = await response.Content.ReadAsStringAsync();
            return input;
        }

        public static void PrintResults(string part1Label, int part1, string part2Label, int part2)
        {
            Console.Write($"\tPart1 {part1Label}: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{part1}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\tPart2 {part2Label}: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{part2}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
