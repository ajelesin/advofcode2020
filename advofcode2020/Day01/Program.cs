namespace Day01
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
            F2();
        }

        static void F1()
        {
            var numbers = File.ReadAllLines("input.txt")
                .Select(int.Parse)
                .ToList();

            for (var i = 0; i < numbers.Count; i += 1)
                for (var j = i; j < numbers.Count; j += 1)
                    if (numbers[i] + numbers[j] == 2020)
                        Console.WriteLine("{0} x {1} = {2}", numbers[i], numbers[j], numbers[i] * numbers[j]);
        }

        static void F2()
        {
            var numbers = File.ReadAllLines("input.txt")
                .Select(int.Parse)
                .ToList();

            for (var i = 0; i < numbers.Count; i += 1)
                for (var j = i; j < numbers.Count; j += 1)
                    for (var k = j; k < numbers.Count; k += 1)
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            Console.WriteLine("{0} x {1} x {2} = {3}", numbers[i], numbers[j], numbers[k], numbers[i] * numbers[j] * numbers[k]);
        }
    }
}
