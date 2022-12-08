using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day07 : AdventDayBase, IAdventDay
    {
        private List<string> _instructions = new();
        private Dictionary<string, int> _directories = new();
        public Day07(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            var totalSize = 0;
            string input = await Helper.GetInput(@"https://adventofcode.com/2022/day/7/input", Cookie);
            //            input = @"$ cd /
            //$ ls
            //dir a
            //14848514 b.txt
            //8504156 c.dat
            //dir d
            //$ cd a
            //$ ls
            //dir e
            //29116 f
            //2557 g
            //62596 h.lst
            //$ cd e
            //$ ls
            //584 i
            //$ cd ..
            //$ cd ..
            //$ cd d
            //$ ls
            //4060174 j
            //8033020 d.log
            //5626152 d.ext
            //7214296 k";
            LoadInput(input);
            var currentPath = string.Empty;
            foreach (var instruction in _instructions)
            {
                if (string.IsNullOrWhiteSpace(instruction)) continue;
                var array = instruction.Split(' ');

                if (instruction.StartsWith("$ cd"))
                {
                    currentPath = ChangeDirectory(currentPath, array);
                    //Console.WriteLine(currentPath);
                }
                else if (instruction.StartsWith("$ ls"))
                { }
                else if (!instruction.StartsWith("dir"))
                {
                    var size = int.Parse(array[0]);

                    if (_directories.ContainsKey(currentPath))
                    {
                        _directories[currentPath] += size;
                    }
                    else
                    {
                        _directories.Add(currentPath, size);
                    }

                    if (currentPath != "/")
                    {
                        var parentDirectory = currentPath.Substring(0, currentPath.LastIndexOf('/'));
                        if (string.IsNullOrEmpty(parentDirectory)) _directories["/"] += size;

                        while (!string.IsNullOrEmpty(parentDirectory))
                        {
                            _directories[parentDirectory] += size;
                            parentDirectory = parentDirectory.Substring(0, parentDirectory.LastIndexOf('/'));
                            if (string.IsNullOrEmpty(parentDirectory)) _directories["/"] += size;
                        }
                    }


                }

            }

            foreach (var item in _directories.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
                if (item.Value <= 100000)
                {
                    totalSize += item.Value;
                }
            }


            Helper.PrintResults("", totalSize, "", 0);
        }

        private string ChangeDirectory(string currentPath, string[] array)
        {
            var path = array[2].Replace("\r", string.Empty);
            if (path == "..")
            {
                currentPath = currentPath.Substring(0, currentPath.LastIndexOf('/'));
                if (currentPath.Length == 0) currentPath = "/";
            }
            else
            {
                if (path == "/")
                {
                    currentPath = path;
                }
                else
                {
                    if (currentPath.Length > 1) currentPath = $"{currentPath}/";
                    currentPath = $"{currentPath}{path}";
                }

            }
            if (!_directories.ContainsKey(currentPath))
            {
                _directories.Add(currentPath, 0);
            }

            return currentPath;
        }

        private void LoadInput(string input)
        {
            var inputArray = input.Split('\n');
            foreach (var line in inputArray)
            {
                _instructions.Add(line);
            }
        }
    }
}
