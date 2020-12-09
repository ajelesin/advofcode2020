namespace Day03
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        static void F1()
        {
            var file = File.ReadAllLines("input.txt");

            var triesMap = new List<List<bool>>();

            foreach (var line in file)
            {
                var row = new List<bool>();

                foreach (var ch in line)
                {
                    row.Add(ch == '#');
                }

                triesMap.Add(row);
            }

            var columns = triesMap[0].Count;
            var rows = triesMap.Count;


            var prop = new int[5, 3] {{ 1, 1, 0 }, { 1, 3, 0 }, {1, 5, 0 }, {1, 7, 0 }, {2, 1, 0 }};
            var m = 1;

            for (var i = 0; i < prop.GetLength(0); i++)
            {
                var cpc = 0;
                for (var cpr = 0; cpr < rows; cpr += prop[i, 0])
                {
                    if (triesMap[cpr][cpc % columns])
                        prop[i, 2] += 1;

                    cpc += prop[i, 1];
                }

                m *= prop[i, 2];
            }

            Console.WriteLine(m);
        }
    }
}
