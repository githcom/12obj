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
                return new { flat = int.Parse(s[1]), debt = float.Parse(s[2], CultureInfo.InvariantCulture) };
            }).OrderBy(e => e.flat);

            ////////////////////////////////
            var res1 = res.Where(e => e.flat <= 36);

            var res11 = Enumerable.Range(1, 36);

            var res112 = res11.GroupJoin(res1, r => r, e => e.flat, (r, e) => e.DefaultIfEmpty().Select(t => new { flat = r, e = t })).SelectMany(e => e);

            int floor1 = 0;

            var res113 = res112.GroupBy(e => (e.flat - 1) / 4,
                (k, g) => new { /*floor = ++floor1,*/ flatAll = g.Select(r => r.flat), elem = g.Select(r => r.e), flat = g.Select(r => r.e.flat), debt = g.Select(r => r.e.debt) }).Select((e, i) => new { floor = i + 1, flatAll = e.flatAll, elem = e.elem, flat = e.flat, debt = e.debt });

            Console.WriteLine("res1");

            foreach (var q in res113)
            {
                Console.Write("Floor - " + q.floor + ", ");
                for (int i = 0; i < q.elem.Count(); i++)
                {
                    if (q.elem.ElementAt(i) != null && q.elem.ElementAt(i).flat != 0 && q.elem.ElementAt(i).debt != ((float)0))
                    {
                        Console.WriteLine("");
                        Console.Write("__________flat - " + q.elem.ElementAt(i).flat + ", debt - " + q.elem.ElementAt(i).debt + ", ");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine(new string('_', 50));

            /////////////////////////////////////////////////


            var res2 = res.Where(e => e.flat > 36 && e.flat <= 72);

            var res22 = Enumerable.Range(37, 36);

            var res212 = res22.GroupJoin(res2, r => r, e => e.flat, (r, e) => e.DefaultIfEmpty().Select(t => new { flat = r, e = t })).SelectMany(e => e);

            int floor2 = 0;

            var res213 = res212.GroupBy(e => (e.flat - 1) / 4,
                (k, g) => new { /*floor = ++floor2,*/ flatAll = g.Select(r => r.flat), elem = g.Select(r => r.e), flat = g.Select(r => r.e.flat), debt = g.Select(r => r.e.debt) }).Select((e, i) => new { floor = i + 1, flatAll = e.flatAll, elem = e.elem, flat = e.flat, debt = e.debt});


            Console.WriteLine("res2");

            foreach (var q in res213)
            {
                Console.Write("Floor - " + q.floor + ", ");
                for (int i = 0; i < q.elem.Count(); i++)
                {
                    if (q.elem.ElementAt(i) != null && q.elem.ElementAt(i).flat != 0 && q.elem.ElementAt(i).debt != ((float)0))
                    {
                        Console.WriteLine("");
                        Console.Write("__________flat - " + q.elem.ElementAt(i).flat + ", debt - " + q.elem.ElementAt(i).debt + ", ");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine(new string('_', 50));


            //////////////////////////////////////////////////

            var res3 = res.Where(e => e.flat > 72 && e.flat <= 108);

            var res33 = Enumerable.Range(73, 36);

            var res312 = res33.GroupJoin(res3, r => r, e => e.flat, (r, e) => e.DefaultIfEmpty().Select(t => new { flat = r, e = t })).SelectMany(e => e);

            int floor3 = 0;

            var res313 = res312.GroupBy(e => (e.flat - 1) / 4,
                (k, g) => new { /*floor = ++floor3,*/ flatAll = g.Select(r => r.flat), elem = g.Select(r => r.e), flat = g.Select(r => r.e.flat), debt = g.Select(r => r.e.debt) }).Select((e, i) => new { floor = i + 1, flatAll = e.flatAll, elem = e.elem, flat = e.flat, debt = e.debt });


            Console.WriteLine("res3");

            foreach (var q in res313)
            {
                Console.Write("Floor - " + q.floor + ", ");
                for (int i = 0; i < q.elem.Count(); i++)
                {
                    if (q.elem.ElementAt(i) != null && q.elem.ElementAt(i).flat != 0 && q.elem.ElementAt(i).debt != ((float)0))
                    {
                        Console.WriteLine("");
                        Console.Write("__________flat - " + q.elem.ElementAt(i).flat + ", debt - " + q.elem.ElementAt(i).debt + ", ");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine(new string('_', 50));


            //////////////////////////////////////////////////

            var res4 = res.Where(e => e.flat > 108 && e.flat <= 144);

            var res44 = Enumerable.Range(109, 36);

            var res412 = res44.GroupJoin(res4, r => r, e => e.flat, (r, e) => e.DefaultIfEmpty().Select(t => new { flat = r, e = t })).SelectMany(e => e);

            int floor4 = 0;

            var res413 = res412.GroupBy(e => (e.flat - 1) / 4,
                (k, g) => new { /*floor = ++floor4,*/ flatAll = g.Select(r => r.flat), elem = g.Select(r => r.e), flat = g.Select(r => r.e.flat), debt = g.Select(r => r.e.debt) }).Select((e, i) => new { floor = i + 1, flatAll = e.flatAll, elem = e.elem, flat = e.flat, debt = e.debt });

            Console.WriteLine("res4");

            foreach (var q in res413)
            {
                Console.Write("Floor - " + q.floor + ", ");
                for (int i = 0; i < q.elem.Count(); i++)
                {
                    if (q.elem.ElementAt(i) != null && q.elem.ElementAt(i).flat != 0 && q.elem.ElementAt(i).debt != 0f)
                    {
                        Console.WriteLine("");
                        Console.Write("__________flat - " + q.elem.ElementAt(i).flat + ", debt - " + q.elem.ElementAt(i).debt + ", ");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine(new string('_', 50));

            //////////////////////////////////////////////////

            Console.WriteLine("");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");

            var res5 = res113.GroupJoin(res213, q => q.floor, w => w.floor, (a1, a2) => new { floor = a1.floor, debt1 = a1.debt, debt2 = a2.Select(t => t.debt) });
            //var res5 = res113.Join(res213, q => q.floor, w => w.floor, (a1, s2) => new { floor = a1.floor, debt1 = a1.debt.DefaultIfEmpty().Concat(s2.debt.DefaultIfEmpty()), /*q.elem.Select(r => r.debt)*/  })/*.SelectMany(e => e.debt1, (q,w) => q.floor + " " + w)*/;
            //var res6 = res113.Join(res213, q => q.floor, w => w.floor,
            //    (q, w) => new {floor = w.floor/*, debt = a1.debt.DefaultIfEmpty()*/ /*.Concat(a2.Select(t => t.debt))*/}).Select(e => e.floor)/*SelectMany(e => e.debt, (ee, d) => (ee.floor != 0 ? ee.floor : 0) + " " + (d != 0f ? d : 0f))*/;

            //foreach (var q in res113)
            //{
            //    Console.WriteLine(q.floor);
            //}

            //Console.WriteLine(new string('-', 50));
            //Console.WriteLine("");
            //foreach (var q in res213)
            //{
            //    Console.WriteLine(q.floor);
            //}
            //Console.WriteLine(new string('-', 50));
            //Console.WriteLine("");

            //bool y = res6 != null;
            //int qq = res6.Count();
            //bool rr = res6.Count() > 0;
            
            

            if (res5 != null && res5.Count() > 0)
            {
                
                foreach (var q in res5)
                {
                    if (q != null)
                    {
                        Console.WriteLine(q/*.floor*/);
                    }

                    //foreach (var w in q.debt1)
                    //{
                    //    Console.WriteLine(w);
                    //}


                    //if (q.debt1 != null && q.debt1.Count() > 0)
                    //{
                    //    for (int i = 0; i < q.debt1.Count(); i++)
                    //    {
                    //        if (q.debt1.ElementAt(i) != null)
                    //        {
                    //            Console.WriteLine(q.debt1.ElementAt(i));
                    //        }

                    //    }
                    //}

                }
            }
            



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
