using System;
using System.Linq;

namespace _12obj
{
    internal class Program
    {

        private static string[] arr = new[] { "Кузнецов 9 1999", "Кузнецова 93 1996", "Александров 60 2009", "Зайцев 59 2005", "Кондратьев 46 2001", "Беляева 82 2008", "Леонидов 18 2006", "Демидов 75 2010", "Беляева 17 2009", "Леонидов 10 2007", "Фролов 37 2000", "Якимов 39 1998", "Сергеев 3 2007", "Петровский 75 1995", "Петров 60 1990", "Греков 96 2009", "Сергеев 25 2010", "Кузнецова 19 1998", "Иванов 81 1999", "Иванов 38 1993", "Пономарев 25 2010", "Александров 66 1992", "Степанова 11 2004", "Юрьева 69 1996", "Пономарев 18 2006", "Юрьев 82 1999", "Борисова 8 1998", "Петровский 61 2010", "Юрьев 33 2005", "Белкин 69 1998", "Беляева 28 1998", "Семенов 9 2009", "Иванова 22 1997", "Федченко 51 1994", "Петухов 54 1999", "Петров 83 2007", "Иванова 27 1996", "Петров 58 2010", "Волкова 38 1992", "Бондарев 65 1992", "Марченко 1 2005", "Кондратьев 82 2005", "Семенов 43 2005", "Петровский 77 2006", "Семенов 40 2010", "Сорокина 67 2007", "Бондарев 71 1995", "Иванова 63 1992", "Юрьева 90 1999", "Петровский 69 1997", "Греков 33 1995", "Сорокина 95 2003", "Марченко 4 1999", "Тимофеев 90 1993", "Яшин 69 2008", "Волкова 80 2009", "Пономарев 67 2001", "Волкова 71 2001", "Пастухов 47 2006", "Юсов 12 1994", "Иванова 55 1994", "Петровский 97 2008", "Юрьева 83 2009", "Алексеева 93 1995", "Юрьева 39 1996" };
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


            var res = arr.Select(e =>
            {
                string[] s = e.Split(' ');
                return new {student = s[0], school = int.Parse(s[1])/*, year = int.Parse(s[1])*/ };
            }).GroupBy(e => e.school, (k, g) => new {school = k, student = g.Select(r => r.student), studCount = g.Count()/*, year = g.OrderBy(r => r.year)*//*.First()/* g.Select(r => r.year)*/ })/*OrderBy(e => e.school).Select(e => e.school + " " + e.studCount + " " + e.student.First())*/;


            var res2 = res.Max(e => e.studCount);

            var res3 = res.Where(e => e.studCount == res2).SelectMany(e => e.student, (e, s) => new {school = e.school, student = s}).OrderBy(e => e.school).Select(e => e.school + " " + e.student);




                //var res2 = res.Average(e => e.school);

                //    var res3 = res.Where(e => e.school > res2).OrderByDescending(e => e.school).ThenBy(e => e.year).Select(e => e.school + " " + e.year);




               


            //var res2 = res.Max(e => e.month);

            //var res3 = res.Where(e => res2 == e.month).Select(e => e.year.ToString()).OrderBy(e => e);



            //Console.WriteLine(res2);

            foreach (var item in res3)
            {
                Console.WriteLine(item);
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
