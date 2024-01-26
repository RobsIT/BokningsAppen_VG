using BokningsAppen_VG.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    internal class CalendarMeths
    {
        public static async Task DayDetails(int month, int year, int day, int dayViewLeft, int dayViewTop)
        {
            Console.SetCursorPosition(dayViewLeft, dayViewTop + 1);
            Console.WriteLine("Namn                     Avdel   Rum  Tid");
            using (var db = new BokningsAppenContext())
            {
                int rowCount = 3;
                foreach (var cal in db.Reservations)
                {
                    if (day == cal.ResvDay && cal.ResvMonth == month && cal.ResvYear == year)
                    {
                        using (var db2 = new BokningsAppenContext())
                        {
                            var roomNr = (from r in db2.Rooms
                                          where r.Id == cal.RoomId
                                          select r.RoomNr).SingleOrDefault();
                            Console.SetCursorPosition(dayViewLeft, dayViewTop + rowCount);
                            if(cal.LiableFirName.Length > 11 ) { Console.WriteLine(cal.LiableFirName.Substring(0,11)); }
                            else { Console.WriteLine(cal.LiableFirName);  }
                            Console.SetCursorPosition(dayViewLeft + 12, dayViewTop + rowCount);
                            if (cal.LiableSecName.Length > 11) { Console.WriteLine(cal.LiableSecName.Substring(0,11)); }
                            else { Console.WriteLine(cal.LiableSecName); }
                            Console.SetCursorPosition(dayViewLeft + 25, dayViewTop + rowCount);
                            if (cal.Department.Length > 5) { Console.WriteLine(cal.Department.Substring(0, 5)); }
                            else { Console.WriteLine(cal.Department); }
                            Console.SetCursorPosition(dayViewLeft + 33, dayViewTop + rowCount);
                            Console.WriteLine(roomNr);
                            Console.SetCursorPosition(dayViewLeft + 38, dayViewTop + rowCount);
                            Console.WriteLine(cal.ResvTimeStart + "-" + cal.ResvTimeEnd);
                        }
                        rowCount++;
                    }
                }
            }
        } 
        public static async Task CalendarDayValues(int month, int year, int dayCount, int day, int calendarLeft, int calendarTop)
        {
            using (var db = new BokningsAppenContext())
            {
                if (dayCount == day) 
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black; 
                }
                Console.Write(dayCount);
                Console.BackgroundColor = 0;
                if (dayCount == day)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen; 
                } 
                foreach (var cal in db.Reservations)
                {
                    if (dayCount == cal.ResvDay && cal.ResvMonth == month && cal.ResvYear == year)
                    {
                        string firNameLetter = cal.LiableFirName;
                        string secNameLetter = cal.LiableSecName;
                        using (var db2 = new BokningsAppenContext())
                        {
                            var roomNr = (from r in db2.Rooms
                                          where r.Id == cal.RoomId
                                          select r.RoomNr).SingleOrDefault();
                            Console.SetCursorPosition(calendarLeft + 3, calendarTop);
                            if(firNameLetter != "")
                            {
                                Console.Write(firNameLetter.Substring(0, 1));
                            }
                            if (secNameLetter != "")
                            {
                                Console.Write(secNameLetter.Substring(0, 1));
                            }   
                            Console.WriteLine(" " + roomNr + " " + cal.ResvTimeStart + "-" + cal.ResvTimeEnd);
                        }
                        calendarTop++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static async Task CalendarValuesView(int calendarLeft, int calendarTop, int month, int year, int day)
        {
            
            int dayCount = 1;
            Console.SetCursorPosition(calendarLeft, calendarTop);
            CalendarDayValues( month, year, dayCount, day, calendarLeft, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 16, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 16, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 32, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 32, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 48, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 48, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 64, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 64, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 80, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 80, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 96, calendarTop);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 96, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 96, calendarTop);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 16, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 16, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 32, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 32, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 48, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 48, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 64, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 64, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 80, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 80, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 96, calendarTop + 5);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 96, calendarTop + 5);
            dayCount++;
            Console.SetCursorPosition(calendarLeft, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 16, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 16, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 32, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 32, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 48, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 48, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 64, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 64, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 80, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 80, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 96, calendarTop + 10);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 96, calendarTop + 10);
            dayCount++;
            Console.SetCursorPosition(calendarLeft, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 16, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 16, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 32, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 32, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 48, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 48, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 64, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 64, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 80, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 64, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 96, calendarTop + 15);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 96, calendarTop + 15);
            dayCount++;
            Console.SetCursorPosition(calendarLeft, calendarTop + 20);
            CalendarDayValues(month, year, dayCount, day, calendarLeft, calendarTop + 20);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 16, calendarTop + 20);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 16, calendarTop + 20);
            dayCount++;
            Console.SetCursorPosition(calendarLeft + 32, calendarTop + 20);
            CalendarDayValues(month, year, dayCount, day, calendarLeft + 32, calendarTop + 20);
        }
    }
}
