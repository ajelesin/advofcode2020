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
            var index1 = CalculateIndex(number.Substring(0, 7), 0, 127, 'F');
            var index2 = CalculateIndex(number.Substring(7), 0, 7, 'L');

            var totalIndex = index1 * 8 + index2;
            return totalIndex;
        }

        static int CalculateIndex(string number, int left, int right, char lowerSign)
        {
            for (var i = 0; i < number.Length; i += 1)
            {
                var s = (right - left) / 2 + 1;
                if (number[i] == lowerSign) right -= s; else left += s;
            }

            return right;
        }
    }
}
