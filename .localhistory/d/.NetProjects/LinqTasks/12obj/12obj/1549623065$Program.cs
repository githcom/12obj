using System;
using System.Globalization;
using System.Linq;

namespace _12obj
{
    internal class Program
    {

        private static string[] arr = new[] { "Степанов 27 660.00", "Иванов 21 580.00", "Филиппов 24 1020.00", "Тимофеев 59 680.00", "Степанова 144 120.00", "Иванов 77 680.00", "Борисова 23 600.00", "Филиппов 81 980.00", "Белкин 86 400.00", "Пастухов 142 200.00", "Зайцев 13 760.00", "Алексеева 68 1000.00", "Леонидов 45 980.00" };
        //private static string[] arr = new[] { "72 2007 Петухов", "49 1993 Петухов", "6 1997 Петровский", "97 1993 Сорокина", "99 2005 Юрьева", "41 1998 Петухов", "47 2010 Зайцев", "1 2007 Марченко", "84 2008 Алексеева", "49 2008 Греков", "87 2000 Кузнецов", "55 2006 Борисова", "29 1990 Юсов" };
        //private static string[] arr = new[] { "2007 50 Тимофеев", "1999 54 Руденко", "1990 97 Пастухов", "2008 43 Борисова", "1996 24 Пастухов", "2007 96 Кузнецова", "1997 50 Пономарев", "1998 43 Юсов", "1992 87 Сорокина", "2010 99 Юрьева", "1993 62 Степанов" };

        //private static float P = 27;

        private static void Main(string[] args)
        {
            //    var res = arr.Select(e =>
            //    {
            //        string[] s = e.Split(' ');
            //        return new {year = int.Parse(s[3]), month = int.Parse(s[2]), hours = int.Parse(s[0])};
            //    }
            //).GroupBy(e => e.year, (k, g) => new { year = k, month = g.Select(r => r.month), hours = g.Select(r => r.hours), sumHour = g.Sum(r => r.hours)}).Where(e => e.hours.Where(r => r > (e.sumHour * P)) ).;

            //var res = arr.Select(e =>
            //    {
            //        string[] s = e.Split(' ');
            //        return new { year = int.Parse(s[3]), month = int.Parse(s[2]), hours = int.Parse(s[0]) };
            //    }
            //);

            //var res = arr.Select(e =>
            //{
            //    string[] s = e.Split(' ');
            //    return new {year = int.Parse(s[2]), school = int.Parse(s[1]), student = s[0] };
            //}).GroupBy(e => new { e.school, e.year},  (k, g) => new { school = k.school, year = k.year, student = g.Select(r => r.student).Aggregate((q, w) => q + " " + w) }).OrderBy(e => e.school).ThenByDescending(e => e.year).Select(e => e.school + " " + e.year + " " + e.student);

            var res = arr.Select(e =>
            {
                string[] s = e.Split(' ');
                return new {flat = int.Parse(s[1]), debt = float.Parse(s[2], CultureInfo.InvariantCulture) };
            }).OrderBy(e => e.flat);

            var res1 = res.Where(e => e.flat <= 36).Select((e, i) => new {index = i, elem = e});

            foreach (var VARIABLE in res1)
            {
                Console.WriteLine(VARIABLE);
            }

            var res11 = res1.GroupBy(e => e.elem.flat / 4, (k, g) => g.Select((r => r.elem)));
            Console.WriteLine("");

            foreach (var VARIABLE in res11)
            {
                foreach (var w in VARIABLE)
                {
                    Console.WriteLine(w.flat + " " + w.debt);
                }

                Console.WriteLine("-----");
            }

            var res2 = res.Where(e => e.flat > 36 && e.flat <= 72).Select(e => new { entr = 2, debt = e.debt })
                .GroupBy(e => e.entr, (k, g) => new { entr = k, countDebt = g.Count(), avg = g.Average(r => r.debt) });

            var res3 = res.Where(e => e.flat > 72 && e.flat <= 108).Select(e => new { entr = 3, debt = e.debt })
                .GroupBy(e => e.entr, (k, g) => new { entr = k, countDebt = g.Count(), avg = g.Average(r => r.debt) });

            var res4 = res.Where(e => e.flat > 108 && e.flat <= 144).Select(e => new { entr = 4, debt = e.debt })
                .GroupBy(e => e.entr, (k, g) => new { entr = k, countDebt = g.Count(), avg = g.Average(r => r.debt) });



            //var res77 = res1.Concat(res2).Concat(res3).Concat(res4)/*.Select(e => e.entr + " " + e.debt)*/;

            //var max = res77.Max(e => e.debt);

            //var res1222 = res77/*.Where(e => e.debt == max)*/.Select(e => e.entr + " " + e.entr + " " + e.avg);


            //var res2 = res.Max(e => e.school);

            //var res22 = res/*.OrderBy(e => e.year.Select(r => r)).Select(e => e.year.Aggregate((x, y) => x + " " + y));

            //var res3 = res.Zip(res22, (e, w) => e.school + " " + w);







            //var res2 = res.Average(e => e.school);

            //    var res3 = res.Where(e => e.school > res2).OrderByDescending(e => e.school).ThenBy(e => e.year).Select(e => e.school + " " + e.year);







            //var res2 = res.Max(e => e.month);

            //var res3 = res.Where(e => res2 == e.month).Select(e => e.year.ToString()).OrderBy(e => e);



            //Console.WriteLine(res1222);

            //foreach (var item in res1222)
            //{
            //    Console.WriteLine(item);
            //}






            //Console.WriteLine("res");
            //Console.WriteLine("");
            //foreach (string q in res)
            //{
            //    Console.WriteLine(q);
            //}

            //Console.WriteLine(new string('-', 50));





            //var res2 = arr.Select(e =>
            //    {
            //        string[] s = e.Split(' ');
            //        return new { year = int.Parse(s[3]), month = int.Parse(s[2]), hours = int.Parse(s[0]) };
            //    }
            //).GroupBy(e => e.year, (k, g) => new { year = k, month = g.Select(r => r.month), hours = g.Select(y => y.hours), sumHour = g.Sum(w => w.hours) * (P / 100)}).SelectMany(e => e.hours, (e, h) => new { e = e, hours = h }).Where(e => e.hours > e.e.sumHour).GroupBy(e => e.e.year, (k, g) => new {month = g.Select( r => r.hours), year = k}).Select(e => new {month = e.month.Count(), year = e.year}).OrderByDescending(e => e.month).ThenBy(e => e.year).Select(e => e.month + " " + e.year);
            ////////////






            //Console.WriteLine("res2");
            //Console.WriteLine("");
            //foreach (var q in res2)
            //{
            //Console.WriteLine("year - " + q.year + ", sumHour - " + q.sumHour);
            //for (int i = 0; i < q.month.Count(); i++)
            //{
            //        Console.WriteLine("month - " + q.month.ElementAt(i) + ", " + "hours  - " + q.hours.ElementAt(i));
            //}

            //    Console.WriteLine(q);
            //}
            //Console.WriteLine(new string('-', 50));


            //////////////
            //var res3 = res2.Select( e => new { month = e.hours.Count(), year = e.year}).OrderByDescending(e => e.month).ThenBy(e => e.year).Select(e => e.month + " " + e.year);

            //Console.WriteLine("res3");
            //Console.WriteLine("");
            //foreach (var item in res3)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(new string('-', 50));




        }
    }
}
