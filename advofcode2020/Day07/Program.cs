namespace Day07
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using MapMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>;
    using IntMap = System.Collections.Generic.Dictionary<string, int>;

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        static void F2()
        {
            var lines = File.ReadAllLines("input.txt");

            var d = new MapMap();
            var regex = new Regex(@"(?:(\d)+ )?(\w+ \w+) bag");
            var foundColor = "shiny gold";

            foreach (var line in lines)
            {
                var matches = regex.Matches(line);

                var bagColor = matches[0].Groups[2].Value;
                var containList = new IntMap();

                for (var i = 1; i < matches.Count; i++)
                {
                    if (matches[i].Groups[0].Value.Contains("no other bag"))
                        break;

                    var color = matches[i].Groups[2].Value;
                    var amount = int.Parse(matches[i].Groups[1].Value);
                    containList.Add(color, amount);
                }

                d.Add(bagColor, containList);
            }

            var sum = Count(foundColor, d);

            Console.WriteLine(sum);
        }

        static int Count(string currentColor, MapMap d)
        {
            var colorMap = d[currentColor];

            if (colorMap.Count == 0)
                return 0;

            var sum = 0;

            foreach (var map in colorMap)
            {
                var iterateColor = map.Key;
                var w = map.Value;

                var t = Count(iterateColor, d);
                sum += w * t + w;
            }

            return sum;
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");

            var d = new MapMap();
            var regex = new Regex(@"(?:(\d)+ )?(\w+ \w+) bag");
            var foundColor = "shiny gold";

            foreach (var line in lines)
            {
                var matches = regex.Matches(line);

                var bagColor = matches[0].Groups[2].Value;
                var containList = new IntMap();

                for (var i = 1; i < matches.Count; i++)
                {
                    if (matches[i].Groups[0].Value.Contains("no other bag"))
                        break;

                    var color = matches[i].Groups[2].Value;
                    var amount = int.Parse(matches[i].Groups[1].Value);
                    containList.Add(color, amount);
                }

                d.Add(bagColor, containList);
            }

            var markedColor = new HashSet<string>();

            foreach (var map in d)
            {
                var iterateColor = map.Key;
                var sum = Check(foundColor, iterateColor, d);
                if (sum > 0)
                    markedColor.Add(iterateColor);
            }

            Console.WriteLine(markedColor.Count - 1);
        }

        static int Check(string foundColor, string currentColor, MapMap d)
        {
            if (foundColor == currentColor)
                return 1;

            var colorMap = d[currentColor];

            if (colorMap.Count == 0)
                return 0;

            var sum = 0;

            foreach (var map in colorMap)
            {
                var iterateColor = map.Key;
                sum += Check(foundColor, map.Key, d);
            }

            return sum;
        }
    }
}
