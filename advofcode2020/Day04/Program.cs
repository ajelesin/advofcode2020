namespace Day04
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

        public static void F1()
        {
            var regex = new Regex(@"((\S+):(\S+))");
            var lines = new List<string>();

            using (var fs = File.OpenRead("input.txt"))
            using (var sr = new StreamReader(fs))
            {
                var sb = new StringBuilder();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        sb.AppendLine(line);
                    }
                    else
                    {
                        lines.Add(sb.ToString());
                        sb.Clear();
                    }
                }

                lines.Add(sb.ToString());
                sb.Clear();
            }

            var valid = 0;
            foreach (var line in lines)
            {
                var matches = regex.Matches(line);

                if (matches.Count == 8)
                {
                    valid += 1;
                }

                else if (matches.Count == 7)
                {
                    var cidExists = false;

                    foreach (Match match in matches)
                    {
                        var field = match.Groups[2].Value;
                        if (field == "cid")
                        {
                            cidExists = true;
                            break;
                        }
                    }

                    if (!cidExists)
                    {
                        valid += 1;
                    }
                }
            }

            Console.WriteLine(valid);
        }

        private static HashSet<string> AlowedEcl = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        private static HashSet<string> RequiredFields = new HashSet<string> { "pid", "ecl", "hcl", "hgt", "eyr", "iyr", "byr" };

        public static void F2()
        {
            var lines = new List<string>();

            using (var fs = File.OpenRead("input.txt"))
            using (var sr = new StreamReader(fs))
            {
                var sb = new StringBuilder();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        sb.AppendLine(line);
                    }
                    else
                    {
                        lines.Add(sb.ToString());
                        sb.Clear();
                    }
                }

                lines.Add(sb.ToString());
                sb.Clear();
            }

            var regex = new Regex(@"((\S+):(\S+))");
            var valid = 0;

            foreach (var line in lines)
            {
                var matches = regex.Matches(line);

                if (matches.Count < 7 || matches.Count > 8)
                    continue;

                var fields = new Dictionary<string, string>();

                foreach (Match match in matches)
                {
                    fields.Add(match.Groups[2].Value, match.Groups[3].Value);
                }

                if (RequiredFields.Except(fields.Keys).Any())
                    continue;

                var pidValid = ValidatePid(fields["pid"]);
                if (!pidValid) continue;

                var eclValid = ValidateEcl(fields["ecl"]);
                if (!eclValid) continue;

                var hclValid = ValidateHcl(fields["hcl"]);
                if (!hclValid) continue;

                var hgtValid = ValidateHgt(fields["hgt"]);
                if (!hgtValid) continue;

                var eyrValid = ValidateEyr(fields["eyr"]);
                if (!eyrValid) continue;

                var iyrValid = ValidateIyr(fields["iyr"]);
                if (!iyrValid) continue;

                var byrValid = ValidateByr(fields["byr"]);
                if (!byrValid) continue;

                valid += 1;
            }

            Console.WriteLine(valid);
        }

        private static bool ValidateByr(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length != 4) return false;

            var parsed = int.TryParse(value, out var numvalue);
            if (!parsed) return false;
            return numvalue >= 1920 && numvalue <= 2002;
        }

        private static bool ValidateIyr(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length != 4) return false;

            var parsed = int.TryParse(value, out var numvalue);
            if (!parsed) return false;
            return numvalue >= 2010 && numvalue <= 2020;

        }

        private static bool ValidateEyr(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length != 4) return false;

            var parsed = int.TryParse(value, out var numvalue);
            if (!parsed) return false;
            return numvalue >= 2020 && numvalue <= 2030;
        }

        private static bool ValidateHgt(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length < 3) return false;

            var mes = value.Substring(value.Length - 2, 2);
            var num = value.Substring(0, value.Length - 2);
            var parsed = int.TryParse(num, out var numvalue);

            if (!parsed) return false;

            if (mes == "in") return numvalue >= 59 && numvalue <= 76;
            if (mes == "cm") return numvalue >= 150 && numvalue <= 193;

            return false;
        }

        private static bool ValidateHcl(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (value.Length != 7) return false;

            if (value[0] != '#') return false;

            for (var i = 1; i < 7; i++)
                if (!((value[i] >= '0' && value[i] <= '9') || (value[i] >= 'a' && value[i] <= 'f')))
                    return false;

            return true;
        }

        private static bool ValidateEcl(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return AlowedEcl.Contains(value);
        }

        private static bool ValidatePid(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (value.Length != 9) return false;

            foreach (var ch in value)
                if (ch < '0' || ch > '9')
                    return false;

            return true;
        }


    }
}
