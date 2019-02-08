using System;
using System.Globalization;
using System.Linq;

namespace _12obj
{
    internal class Program
    {

        private static string[] arr = new[] { "Иванов 280.52 52", "Петухов 262.37 84", "Юрьева 1004.08 132", "Бондарев 847.98 116", "Иванов 761.33 77", "Алексеева 523.25 53", "Александров 436.57 64", "Федченко 522.96 128", "Александров 990.63 34", "Сидоров 352.05 22", "Беляева 328.36 131", "Борисова 256.96 120" };
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
                return new {flat = int.Parse(s[2]), debt = float.Parse(s[1], CultureInfo.InvariantCulture) };
            }).OrderBy(e => e.flat);

            var res2 = res.Where(e => e.flat <= 36).Select(e => new {entr = 1, debt = e.debt}).GroupBy(e => e.entr, (k, g) => new {entr = k, debt = g.Sum(r => r.debt)});

            //res2.Concat(

            var res3 = res.Where(e => e.flat > 36 && e.flat <= 72).Select(e => new { entr = 2, debt = e.debt })
                .GroupBy(e => e.entr, (k, g) => new { entr = k, debt = g.Sum(r => r.debt) });

            res2.Concat(res3);


            //var res2 = res.Max(e => e.school);

            //var res22 = res/*.OrderBy(e => e.year.Select(r => r)).Select(e => e.year.Aggregate((x, y) => x + " " + y));

            //var res3 = res.Zip(res22, (e, w) => e.school + " " + w);







            //var res2 = res.Average(e => e.school);

            //    var res3 = res.Where(e => e.school > res2).OrderByDescending(e => e.school).ThenBy(e => e.year).Select(e => e.school + " " + e.year);







            //var res2 = res.Max(e => e.month);

            //var res3 = res.Where(e => res2 == e.month).Select(e => e.year.ToString()).OrderBy(e => e);



            //Console.WriteLine(res2);

            foreach (var item in res2)
            {
                Console.WriteLine(item.entr + " " + item.debt);
            }






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
