using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day05 : AdventDayBase, IAdventDay
    {
        private readonly List<string> _map = new();
        private readonly List<string> _instructions = new();
        private List<Stack<string>> stacks;

        public Day05(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/5/input", Cookie);
            var inputArray = input.Split("\n");
            LoadInputs(inputArray);

            InitializeStacks();
            ExecuteMovesOneByOne();
            var part1 = string.Join(" ", stacks.SelectMany(x => x.Count == 0 ? "" : x.Pop()));

            stacks.Clear();

            InitializeStacks();
            ExecuteMovesMultiple();
            var part2 = string.Join(" ", stacks.SelectMany(x => x.Count == 0 ? "" : x.Pop()));

            Helper.PrintResults("one by one", part1, "multiple", part2);
        }

        private void ExecuteMovesOneByOne()
        {
            foreach (var instruction in _instructions)
            {
                var action = instruction.Substring(5);
                var a = action.Split(" from ");
                var b = a[1].Split(" to ");
                var moveTimes = int.Parse(a[0]);

                for (int i = 1; i <= moveTimes; i++)
                {
                    var from = int.Parse(b[0]) - 1;
                    var to = int.Parse(b[1]) - 1;
                    if (stacks[from].Count != 0)
                    {
                        var container = stacks[from].Pop();
                        stacks[to].Push(container);
                    }
                }
            }
        }

        private void ExecuteMovesMultiple()
        {
            foreach (var instruction in _instructions)
            {
                var action = instruction.Substring(5);
                var a = action.Split(" from ");
                var b = a[1].Split(" to ");
                var moveTimes = int.Parse(a[0]);
                var from = int.Parse(b[0]) - 1;
                var to = int.Parse(b[1]) - 1;
                var temp = new Stack<string>();

                for (int i = 1; i <= moveTimes; i++)
                {
                    if (stacks[from].Count != 0)
                    {
                        var container = stacks[from].Pop();
                        temp.Push(container);
                    }
                }
                for (int i = 1; i <= moveTimes; i++)
                {
                    var container = temp.Pop();
                    stacks[to].Push(container);
                }
            }
        }

        private void InitializeStacks()
        {
            var stackCount = Math.Ceiling(_map.Last().Length / 4d);
            stacks = new List<Stack<string>>();
            for (int i = 0; i < stackCount; i++)
            {
                stacks.Add(new Stack<string>());
            }

            for (var i = _map.Count - 1; i >= 0; i--)
            {
                var container = "";
                var containerId = 0;
                foreach (var item in _map[i])
                {
                    container = container + item;
                    if (container == "    ")
                    {
                        containerId++;
                        container = String.Empty;
                    }
                    if (item == ']')
                    {
                        container = container.Replace(" ", "");
                        stacks[containerId++].Push(container);
                        container = String.Empty;
                    }

                }
            }

        }

        private void LoadInputs(string[] inputArray)
        {
            var mapLoaded = false;
            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mapLoaded = true;
                    continue;
                }

                if (!mapLoaded)
                {
                    LoadMapLine(line);
                }
                else
                {
                    LoadInstruction(line);
                }
            }
        }

        private void LoadInstruction(string line)
        {
            _instructions.Add(line);
        }

        private void LoadMapLine(string line)
        {
            _map.Add(line);
        }
    }
}
