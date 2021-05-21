using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day4
    {
        static string input = "iwrupvqb";
        static int GetRequiredInt(string input, int zerosCount)
        {
            string match = new string('0', zerosCount);
            int i = 0;
            using (var md5 = MD5.Create())
            {
                while (true)
                {

                    var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes($"{input}{i}"));
                    var hash = string.Join("", hashBytes.Select(b => b.ToString("x2")));
                    if (hash.StartsWith(match))
                    {
                        return i;
                    }

                    i += 1;
                }
            }
        }
        
        // approx. 3 times faster than the other method
        static int GetRequiredIntApproch2(string input , int zerosCount)
        {
            var c = new ConcurrentQueue<int>();
            string match = new string('0', zerosCount);
            Parallel.ForEach(Enumerable.Range(0, int.MaxValue),
                () => MD5.Create(),
                (i, state, md5) =>
                {
                    var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input + i));
                    var hash = string.Join("", hashBytes.Select(b => b.ToString("x2")));

                    if (hash.StartsWith(match))
                    {
                        c.Enqueue(i);
                        state.Stop();
                    }
                    return md5;
                },
                (_) => { });

            return c.Min();

        }
        public static int Part1()
        {
            int result = GetRequiredIntApproch2(input, 5);
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;
        }
        public static int Part2()
        {
            int result = GetRequiredIntApproch2(input, 6);
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;
        }

    }
}
