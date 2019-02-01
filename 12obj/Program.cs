using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _12obj
{
    class Program
    {

        private static string[] arr = new[] {"11 83 5 2007", "20 20 9 2004", "10 39 1 2003", "24 20 3 2009", "3 56 5 2006", "3 80 5 2009", "1 89 9 2006", "12 83 11 2004", "28 51 9 2009", "12 89 7 2009", "10 37 9 2005", "29 88 6 2002", "14 86 6 2006", "6 68 11 2002", "9 93 10 2010", "13 27 1 2007", "21 90 7 2001" };
        private static int P = 27;

        static void Main(string[] args)
        {
        //    var res = arr.Select(e =>
        //    {
        //        string[] s = e.Split(' ');
        //        return new {year = int.Parse(s[3]), month = int.Parse(s[2]), hours = int.Parse(s[0])};
        //    }
        //).GroupBy(e => e.year, (k, g) => new { year = k, month = g.Select(r => r.month), hours = g.Select(r => r.hours), sumHour = g.Sum(r => r.hours)}).Where(e => e.hours.Where(r => r > (e.sumHour * P)) ).;

            var res = arr.Select(e =>
                {
                    string[] s = e.Split(' ');
                    return new { year = int.Parse(s[3]), month = int.Parse(s[2]), hours = int.Parse(s[0]) };
                }
            );

            foreach (var q in res)
            {
                Console.WriteLine(q);
            }

            var res2 = res.GroupBy(e => e.year, (k, g) => new { year = k, month = g.Select(r => r.month), hours = g.Where(r => r.hours > (g.Sum(w => w.hours) * (P / 100))), sumHour = g.Sum(r => r.hours) });

            foreach (var q in res2)
            {
                Console.WriteLine(q.year+ " " + q.sumHour);
                for (int i = 0; i < UPPER; i++)
                {
                    foreach (var w in q.)
                    {
                        Console.WriteLine();
                    }
                }
            }




                .GroupBy(e => e.year, (k, g) => new { year = k, month = g.Select(r => r.month), hours = g.Where(r => r.hours > (g.Sum(w => w.hours) * (P / 100))), sumHour = g.Sum(r => r.hours) }).Select( e => new { month = e.hours.Count(), year = e.year}).OrderByDescending(e => e.month).ThenBy(e => e.year).Select(e => e.month + " " + e.year);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }




    }
    }
}
