namespace Day09
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

        static void F2()
        {
            const int len = 25;

            var numbers = File.ReadAllLines("input.txt")
                .Select(long.Parse)
                .ToList();

            var k = 0;
            var foundPair = true;

            for (k = len; k < numbers.Count && foundPair; k += 1)
            {
                foundPair = false;

                for (var i = k - len; i <= k - 1 && !foundPair; i += 1)
                {
                    for (var j = i + 1; j <= k - 1 && !foundPair; j += 1)
                    {
                        foundPair = numbers[i] + numbers[j] == numbers[k];
                    }
                }
            }

            long sum = 0, min = long.MaxValue, max = long.MinValue;
            Queue<long> seq = new Queue<long>();

            for (var m = 0; m < k - 2; m += 1)
            {
                seq.Enqueue(numbers[m]);
                sum += numbers[m];

                while (sum > numbers[k - 1])
                {
                    var n = seq.Dequeue();
                    sum -= n;
                }

                if (sum == numbers[k - 1]) break;
            }

            foreach (var n in seq)
            {
                if (n > max) max = n;
                if (n < min) min = n;
            }

            Console.WriteLine($"N = {numbers[k - 1]}, S = {sum}, m = {min}, M = {max}, m + M = {min + max}");
        }

        static void F1()
        {
            const int len = 25;

            var numbers = File.ReadAllLines("input.txt")
                .Select(long.Parse)
                .ToList();

            var k = 0;
            var foundPair = true;

            for (k = len; k < numbers.Count && foundPair; k += 1)
            {
                foundPair = false;

                for (var i = k - len; i <= k - 1 && !foundPair; i += 1)
                {
                    for (var j = i + 1; j <= k - 1 && !foundPair; j += 1)
                    {
                        foundPair = numbers[i] + numbers[j] == numbers[k];
                    }
                }
            }

            Console.WriteLine(numbers[k - 1]);
        }
    }
}
