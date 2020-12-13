namespace Day06
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        static void F2()
        {
            var lines = File.ReadAllLines("input.txt");

            var sum = 0;
            var g = new Dictionary<char, int>();
            var gs = 0;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    foreach (var k in g)
                    {
                        if (k.Value == gs)
                        {
                            sum += 1;
                        }
                    }

                    g.Clear();
                    gs = 0;
                    continue;
                }

                foreach (var ch in line)
                {
                    if (g.ContainsKey(ch)) g[ch] += 1;
                    else g.Add(ch, 1);
                }

                gs += 1;
            }
            
            foreach (var k in g)
            {
                if (k.Value == gs)
                {
                    sum += 1;
                }
            }

            g.Clear();
            gs = 0;

            Console.WriteLine(sum);
            
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");

            var sum = 0;
            var g = new HashSet<char>();

            foreach (var line in lines)
            {
                if (line == "")
                {
                    sum += g.Count;
                    g.Clear();
                    continue;
                }

                foreach (var ch in line)
                {
                    g.Add(ch);
                }
            }

            sum += g.Count;
            g.Clear();

            Console.WriteLine(sum);
        }
    }
}
