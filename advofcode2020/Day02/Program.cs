namespace Day02
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");
            var valid = 0;

            var regex = new Regex(@"(\d+)-(\d+) (\w{1}): (\w+)");


            foreach (var line in lines)
            {
                var count = 0;

                var match = regex.Match(line);
                var min = int.Parse(match.Groups[1].Value);
                var max = int.Parse(match.Groups[2].Value);
                var ch = match.Groups[3].Value[0];
                var pwd = match.Groups[4].Value;

                foreach (var item in pwd)
                {
                    if (item == ch) count++;
                }

                if (count >= min && count <= max)
                    valid++;
            }

            Console.WriteLine(valid);
        }

        static void F2()
        {
            var lines = File.ReadAllLines("input.txt");
            var valid = 0;

            var regex = new Regex(@"(\d+)-(\d+) (\w{1}): (\w+)");


            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var firstIndex = int.Parse(match.Groups[1].Value) - 1;
                var secondIndex = int.Parse(match.Groups[2].Value) - 1;
                var ch = match.Groups[3].Value[0];
                var pwd = match.Groups[4].Value;

                if ((pwd[firstIndex] == ch ^ pwd[secondIndex] == ch))
                    valid++;
            }

            Console.WriteLine(valid);
        }
    }
}
