using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    internal class MainViewMeth
    {
        public static async Task MainView(int month, int year, int day, int listScroll_1, int listScroll_2)
        {
            //Skriver ut kalendern.
            int calendarLeft = 1;
            int calendarTop = 16;
            await Window.DrawWindowFull(calendarLeft, calendarTop, 114, 28);
            Console.SetCursorPosition(calendarLeft, calendarTop);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KALENDER ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("----------  År: " + year + "  Månad: " + month + "  ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[Z]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = 0;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[X]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = 0;
            Console.Write("  ---------------  ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[A]");
            Console.BackgroundColor = 0;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("[S]");
            Console.BackgroundColor = 0;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("[D]");
            Console.BackgroundColor = 0;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("[W]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = 0;
            Console.Write("  ----------------------------  ");
            Console.SetCursorPosition(calendarLeft, calendarTop + 1);
            Console.WriteLine("Måndag          Tisdag          Onsdag          Torsdag         Fredag          Lördag          Söndag    \n");
            await CalendarMeths.CalendarValuesView(calendarLeft, calendarTop + 3, month, year, day);
            //Skriver ut dagrutan.
            int dayViewLeft = 117;
            int dayViewTop = 16;
            await Window.DrawWindowNoLeftWall(dayViewLeft, dayViewTop, 45, 28);
            Console.SetCursorPosition(dayViewLeft, dayViewTop);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("DAG");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ---- Datum:    ------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(dayViewLeft + 16, dayViewTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(day);
            Console.ForegroundColor = ConsoleColor.White;
            await CalendarMeths.DayDetails(month, year, day, dayViewLeft, dayViewTop);
            //Skriver ut Bokningsbara rum-rutan.
            int roomListLeft = 117;
            int roomListTop = 1;
            int roomListTopStart = roomListTop;
            await Window.DrawWindowNoLeftWall(roomListLeft, roomListTop, 45, 13);
            Console.SetCursorPosition(roomListLeft, roomListTop);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[H]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = 0;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[Y]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = 0;
            Console.Write(" ---");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  BOKNINGSBARA RUM  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("----------  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(roomListLeft, roomListTop + 1);
            Console.WriteLine("RumId  RumNr  Platser  Whiteboard  Projector");
            using (var db = new BokningsAppenContext())
            {
                int listCount1 = 0;
                Console.SetCursorPosition(roomListLeft + 4, roomListTop);
                Console.WriteLine(listScroll_1);
                foreach (var room in db.Rooms)          
                {
                    listCount1++;
                    if (listCount1 >= listScroll_1 && listCount1 <= listScroll_1 + 8)
                    {
                        Console.SetCursorPosition(roomListLeft + 2, (roomListTopStart + 4) - listScroll_1);
                        Console.Write(room.Id);
                        Console.SetCursorPosition(roomListLeft + 7, (roomListTopStart + 4) - listScroll_1);
                        Console.Write(room.RoomNr);
                        Console.SetCursorPosition(roomListLeft + 17, (roomListTopStart + 4) - listScroll_1);
                        Console.WriteLine(room.SeatsQuantity);
                        Console.SetCursorPosition(roomListLeft + 26, (roomListTopStart + 4) - listScroll_1);
                        Console.WriteLine(room.Whiteboard == true ? "JA" : "NEJ");
                        Console.SetCursorPosition(roomListLeft + 38, (roomListTopStart + 4) - listScroll_1);
                        Console.WriteLine(room.Projector == true ? "JA" : "NEJ"); 
                    }
                    roomListTopStart++;
                }
                //Skriver ut alla bokningar-rutan.
                int resvListLeft = 67;
                int resvListTop = 1;
                int resvListTopStart = resvListTop;
                await Window.DrawWindowNoLeftWall(resvListLeft, resvListTop, 48, 13);
                Console.SetCursorPosition(resvListLeft, resvListTop);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[G]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = 0;
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[T]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = 0;
                Console.Write(" ------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  BOKNINGAR  ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("-----------------  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(resvListLeft, resvListTop + 1);
                Console.WriteLine(" BokId  Rum   Namn                      Avdel");
                using (var db2 = new BokningsAppenContext())
                {
                    int listCount2 = 0;
                    Console.SetCursorPosition(resvListLeft + 4, resvListTop);
                    Console.WriteLine(listScroll_2);
                    foreach (var res in db.Reservations)                       
                    {
                        listCount2++;
                        if (listCount2 >= listScroll_2 && listCount2 <= listScroll_2 + 8)
                        {
                            var roomNr = (from r in db2.Rooms
                                            where r.Id == res.RoomId
                                            select r.RoomNr).SingleOrDefault();
                            Console.SetCursorPosition(resvListLeft + 2, (resvListTopStart + 4) - listScroll_2);
                            Console.WriteLine(res.Id);
                            Console.SetCursorPosition(resvListLeft + 8, (resvListTopStart + 4) - listScroll_2);
                            Console.WriteLine(roomNr);
                            Console.SetCursorPosition(resvListLeft + 14, (resvListTopStart + 4) - listScroll_2);
                            if (res.LiableFirName.Length > 11) { Console.WriteLine(res.LiableFirName.Substring(0, 11)); }
                            else { Console.WriteLine(res.LiableFirName); }
                            Console.SetCursorPosition(resvListLeft + 26, (resvListTopStart + 4) - listScroll_2);
                            if (res.LiableSecName.Length > 13) { Console.WriteLine(res.LiableSecName.Substring(0, 13)); }
                            else { Console.WriteLine(res.LiableSecName); }
                            Console.SetCursorPosition(resvListLeft + 40, (resvListTopStart + 4) - listScroll_2);
                            if (res.Department.Length > 5) { Console.WriteLine(res.Department.Substring(0, 5)); }
                            else { Console.WriteLine(res.Department); }   
                        }
                        resvListTopStart++;
                    }
                }
                //Skriver ut ramen till meny-rutan.
                int editFieldLeft = 1;
                int editFieldTop = 1;
                Window.DrawWindowFull(editFieldLeft, editFieldTop, 64, 13);
            }
        }
    }
}
