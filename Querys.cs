using BokningsAppen_VG.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    internal class Querys
    {
        public static void LinqQuerys(int month, int year, int day, int listScroll_1, int listScroll_2) 
        {
            MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
            int menySelectionsLeft = 1;
            int menySelectionsTop = 1;

            Console.SetCursorPosition(menySelectionsLeft + 20, menySelectionsTop );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Queries");
            Console.ForegroundColor = ConsoleColor.White;
            using (var db = new BokningsAppenContext()) 
            {
                //Antal dagar med bokningar  
                var totResv_1 = from r in db.Reservations
                                    group r by r.ResvDay;
                int count1 = 0;
                foreach (var post in totResv_1)
                {
                    count1++;
                }
                Console.SetCursorPosition(menySelectionsLeft + 20, menySelectionsTop + 1);
                Console.WriteLine("*Antal dagar med bokningar: " + count1);

                //Totalt antal bokningar
                var allResv = db.Reservations;
                var totReservations = allResv.Count();
                Console.SetCursorPosition(menySelectionsLeft + 20, menySelectionsTop + 2);
                Console.WriteLine("*Totalt antal bokningar: " + totReservations);

                //Populäraste rummet
                var mostPopRoom = db.Reservations
                    .GroupBy(p => p.RoomId)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();
                int roomNr = (from r in db.Rooms
                                  where r.Id == mostPopRoom
                                  select r.RoomNr).SingleOrDefault();
                Console.SetCursorPosition(menySelectionsLeft + 20, menySelectionsTop + 3);
                Console.WriteLine("*Populäraste rummet: " + roomNr);

                //Antal bokningar per månad
                var resvPerMonth  = db.Reservations
                    .GroupBy(e => new { e.ResvYear, e.ResvMonth })
                    .OrderBy(g => g.Key.ResvYear)
                    .ThenBy(g => g.Key.ResvMonth)
                    .ThenBy(g => g.Count())
                    .Select(g => new
                    {
                        Year = g.Key.ResvYear,
                        Month = g.Key.ResvMonth,
                        TotalResv = g.Count()         
                    });
                Console.SetCursorPosition(menySelectionsLeft + 20, menySelectionsTop + 5);
                Console.WriteLine("*Antal bokningar per månad: ");
                int count2 = 6;
                foreach (var res in resvPerMonth)
                {
                    Console.SetCursorPosition(menySelectionsLeft + 22, menySelectionsTop + count2);
                    Console.WriteLine("År: " + res.Year + " Mån: " + res.Month + " Antal: " + res.TotalResv);
                    count2++;
                }
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
