namespace Day05
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
            var lines = File.ReadAllLines("input.txt");

            int max = int.MinValue, min = int.MaxValue, sum = 0;

            foreach (var line in lines)
            {
                var seatId = CalculateSeatId(line);
                
                if (seatId > max) max = seatId;
                if (seatId < min) min = seatId;

                sum += seatId;
            }

            var fullSum = (max - min + 1) * (max + min) / 2;
            var lookingSeatId = fullSum - sum;

            Console.WriteLine(lookingSeatId);
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");

            var maxSeatId = 0;

            foreach (var line in lines)
            {
                var seatId = CalculateSeatId(line);
                if (seatId > maxSeatId) maxSeatId = seatId;
            }

            Console.WriteLine(maxSeatId);
        }

        static int CalculateSeatId(string number)
        {
            var sum = 0;

            for (var i = 0; i < 7; i ++)
            {
                if (number[i] == 'F') sum <<= 1;
                else sum = (sum << 1) | 1;
            }

            for (var i = 7; i < 10; i++)
            {
                if (number[i] == 'L') sum <<= 1;
                else sum = (sum << 1) | 1;
            }

            return sum;
        }
    }
}
