namespace Day07
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using ContainMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>;
    using ColorMap = System.Collections.Generic.Dictionary<string, int>;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");

            var d = new ContainMap();
            var regex = new Regex(@"(?:(\d)+ )?(\w+ \w+) bag");
            var foundColor = "shiny gold";

            foreach (var line in lines)
            {
                var matches = regex.Matches(line);

                var bagColor = matches[0].Groups[2].Value;
                var containList = new ColorMap();

                for (var i = 1; i < matches.Count; i ++)
                {
                    var color = matches[i].Groups[2].Value;
                    var amount = int.Parse(matches[i].Groups[1].Value);
                    containList.Add(color, amount);
                }

                d.Add(bagColor, containList);
            }

            var sum = 0;
            foreach (var map in d)
            {
                var iterateColor = map.Key;
                sum += Check(foundColor, iterateColor, d);
            }

            Console.WriteLine(sum);
        }

        static int Check(string foundColor, string currentColor, ContainMap d)
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
