namespace Day08
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Tok = System.Tuple<string, int>;

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }
        
        static void F2()
        {
            var lines = File.ReadAllLines("input.txt");

            var regex = new Regex(@"(\w+) ([+-])(\d+)");
            var pr = new List<Tok>();

            foreach (var line in lines)
            {
                var match = regex.Match(line);

                var cmd = match.Groups[1].Value;
                var s = match.Groups[2].Value;

                var op = int.Parse(match.Groups[3].Value);

                if (s == "-") op = -op;

                var tok = new Tok(cmd, op);
                pr.Add(tok);
            }


            Tok tmp;
            var foundPointer = 0;
            var foundAcc = 0;

            for (var i = 0; i < pr.Count; i++)
            {
                if (pr[i].Item1 == "nop")
                {
                    tmp = pr[i];
                    pr[i] = new Tok("jmp", tmp.Item2);

                    var retCode = Run(pr, out var pointer, out var acc);

                    if (retCode == 0)
                    {
                        foundPointer = pointer;
                        foundAcc = acc;
                        break;
                    }
                    else
                    {
                        pr[i] = tmp;
                    }
                }

                if (pr[i].Item1 == "jmp")
                {
                    tmp = pr[i];
                    pr[i] = new Tok("nop", tmp.Item2);

                    var retCode = Run(pr, out var pointer, out var acc);

                    if (retCode == 0)
                    {
                        foundPointer = pointer;
                        foundAcc = acc;
                        break;
                    }
                    else
                    {
                        pr[i] = tmp;
                    }
                }
            }


            Console.WriteLine($"{foundPointer}, {foundAcc}");
        }

        static void F1()
        {
            var lines = File.ReadAllLines("input.txt");

            var regex = new Regex(@"(\w+) ([+-])(\d+)");
            var pr = new List<Tok>();

            foreach (var line in lines)
            {
                var match = regex.Match(line);

                var cmd = match.Groups[1].Value;
                var s = match.Groups[2].Value;
                
                var op = int.Parse(match.Groups[3].Value);

                if (s == "-") op = -op;

                var tok = new Tok(cmd, op);
                pr.Add(tok);
            }

            var retCode = Run(pr, out var pointer, out var acc);

            Console.WriteLine($"{retCode}, {pointer}, {acc}");
        }

        static int Run(List<Tok> pr, out int outerPointer, out int outerAcc)
        {
            var pointer = 0;
            var acc = 0;
            var executed = new HashSet<int>();

            while (pointer < pr.Count)
            {
                if (executed.Contains(pointer))
                {
                    outerPointer = pointer;
                    outerAcc = acc;
                    return -1;
                }

                executed.Add(pointer);

                var tok = pr[pointer];

                switch (tok.Item1)
                {
                    case "acc":
                        acc += tok.Item2;
                        pointer += 1;
                        continue;
                    case "jmp":
                        pointer += tok.Item2;
                        continue;
                    case "nop":
                        pointer += 1;
                        continue;
                    default:
                        throw new Exception("xui");
                }
            }

            outerPointer = pointer;
            outerAcc = acc;
            return 0;
        }
    }
}
