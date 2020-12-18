namespace Day10
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Intd = System.Collections.Generic.Dictionary<long, long>;

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        static void F2()
        {
            var jolts = File.ReadAllLines("input.txt")
                .Select(long.Parse)
                .OrderBy(o => o)
                .ToList();

            long final = jolts.Max() + 3;
            var dists = new Intd { { 0, 1 } };

            foreach (long j in jolts)
            {
                dists[j] = GetDist(dists, j - 1) + GetDist(dists, j - 2) + GetDist(dists, j - 3);
            }

            dists[final] = GetDist(dists, final - 1) + GetDist(dists, final - 2) + GetDist(dists, final - 3);

            Console.WriteLine(dists[final]);
        }

        static long GetDist(Intd dists, long key)
        {
            if (dists.ContainsKey(key)) return dists[key];
            return 0;
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt")
                .Select(int.Parse)
                .ToList();

            var distr = new List<int>();
            var orJolts = new List<int> { 0 };
            int cnt1 = 0, cnt3 = 0;

            orJolts.AddRange(lines.OrderBy(o => o));

            for (var i = 1; i < orJolts.Count; i++)
            {
                var d = orJolts[i] - orJolts[i - 1];
                if (d == 1) cnt1 += 1;
                if (d == 3) cnt3 += 1;
                distr.Add(d);
            }

            distr.Add(3);
            cnt3++;

            Console.WriteLine($"1: {cnt1}; 3: {cnt3}; 1x3: {cnt1 * cnt3}");
        }
    }
}
