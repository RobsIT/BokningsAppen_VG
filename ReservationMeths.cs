using BokningsAppen_VG.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    internal class ReservationMeths
    {
        public static void AddReservation()
        {
            int addResvLeft = 24;
            int addResvTop = 2;
            Console.SetCursorPosition(addResvLeft, addResvTop);
            Console.WriteLine("Lägg till bokning");
            Console.SetCursorPosition(addResvLeft, addResvTop + 1);
            Console.Write("År: ");
            int.TryParse(Console.ReadLine(), out int resvYear);
            Console.SetCursorPosition(addResvLeft + 9, addResvTop + 1);
            Console.Write("Månad: ");
            int.TryParse(Console.ReadLine(), out int resvMonth);
            Console.SetCursorPosition(addResvLeft + 19, addResvTop + 1);
            Console.Write("Dag: ");
            int.TryParse(Console.ReadLine(), out int resvDay);
            using (var db = new BokningsAppenContext())
            {
                int resvRoomNr = 0;
                bool wrong1 = true;
                bool loop1 = true;
                do
                {
                    Console.SetCursorPosition(addResvLeft, addResvTop + 2);
                    Console.Write("Ange Rum Nr: ");
                    int.TryParse(Console.ReadLine(), out resvRoomNr);
                    foreach (var ro in db.Rooms) 
                    {
                        if (ro.RoomNr == resvRoomNr) 
                        {
                            loop1 = false;
                            wrong1 = false;
                            break;
                        }
                    }
                    if (wrong1)
                    {
                        Console.SetCursorPosition(addResvLeft, addResvTop + 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rummet finns ej!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey(true);
                        Console.SetCursorPosition(addResvLeft, addResvTop + 3);
                        Console.Write("                  ");
                        Console.SetCursorPosition(addResvLeft, addResvTop + 2);
                        Console.Write("                  "); 
                    }
                } while (loop1);
                int resvRoomId = (from r in db.Rooms
                              where r.RoomNr == resvRoomNr
                              select r.Id).SingleOrDefault();

                Console.SetCursorPosition(addResvLeft, addResvTop + 3);
                Console.Write("Tidpunkt(Heltimma) ");
                int resvTimeStart = 0;
                int resvTimeEnd = 1;
                bool wrong2 = false;
                bool loop2 = false;
                do
                {
                    wrong2 = false;
                    loop2 = false;
                    Console.SetCursorPosition(addResvLeft, addResvTop + 4);
                    Console.Write("Ange start timme 0-23: ");
                    int.TryParse(Console.ReadLine(), out resvTimeStart);
                    Console.SetCursorPosition(addResvLeft, addResvTop + 5);
                    Console.Write("Ange slut timme 1-24: ");
                    int.TryParse(Console.ReadLine(), out resvTimeEnd);
                    foreach (var cal in db.Reservations)
                    {
                        if (cal.ResvDay == resvDay && cal.ResvMonth == resvMonth && cal.ResvYear == resvYear && cal.RoomId != resvRoomNr)
                        {
                            if (resvTimeStart >= cal.ResvTimeStart && resvTimeEnd <= cal.ResvTimeEnd || resvTimeStart <= cal.ResvTimeStart && resvTimeEnd >= cal.ResvTimeEnd || resvTimeStart <= cal.ResvTimeStart && resvTimeEnd > cal.ResvTimeStart || resvTimeStart < cal.ResvTimeEnd && resvTimeEnd > cal.ResvTimeEnd)
                            {
                                    wrong2 = true;
                                    loop2 = true;
                                    break;  
                            }
                        }
                    }
                    if(wrong2)
                    {
                        Console.SetCursorPosition(addResvLeft, addResvTop + 4);
                        Console.WriteLine("                             ");
                        Console.SetCursorPosition(addResvLeft, addResvTop + 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Upptagen! Välj en annan tid..");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey(true);
                        Console.SetCursorPosition(addResvLeft, addResvTop + 5);
                        Console.WriteLine("                             ");
                        
                    }
                    else { loop2 = false; }
                } while (loop2);
                Console.SetCursorPosition(addResvLeft, addResvTop + 6);
                Console.Write("Vem är ansvarig ");
                Console.SetCursorPosition(addResvLeft, addResvTop + 7);
                Console.Write("Skriv förnamn: ");
                string LiableFirName = Console.ReadLine();
                Console.SetCursorPosition(addResvLeft, addResvTop + 8);
                Console.Write("Skriv efternamn: ");
                string LiableSecName = Console.ReadLine();
                Console.SetCursorPosition(addResvLeft, addResvTop + 9);
                Console.Write("Vilken avdelning: ");
                string department = Console.ReadLine();
                var addReservation = new Reservation
                {
                    ResvYear = resvYear,
                    ResvMonth = resvMonth,
                    ResvDay = resvDay,
                    ResvTimeStart = resvTimeStart,
                    ResvTimeEnd = resvTimeEnd,
                    LiableFirName = LiableFirName,
                    LiableSecName = LiableSecName,
                    Department = department,
                    RoomId = resvRoomId
                };

                db.Add(addReservation);
                db.SaveChanges();
            }
        }
        public static void EditReservation(int month, int year, int day, int listScroll_1, int listScroll_2)
        {
            using (var db = new BokningsAppenContext())
            {
                bool exit = false;
                bool wrong = false;
                bool loop = false;
                do
                {
                    wrong = false;
                    loop = false;
                    MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                    int addResvLeft = 24;
                    int addResvTop = 1;
                    int menySelectionsLeft = 1;
                    int menySelectionsTop = 2;
                    bool loop3 = true;
                
                    Console.SetCursorPosition(addResvLeft, addResvTop);
                    Console.Write("Ange boknings-ID: ");
                    int.TryParse(Console.ReadLine(), out int resvEditId);
                    Console.SetCursorPosition(1, 1);
                    Console.Write("Välj i menyn");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop);
                    Console.WriteLine("[1]Ändra År");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 1);
                    Console.WriteLine("[2]Ändra Månad");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 2);
                    Console.WriteLine("[3]Ändra Dag");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 3);
                    Console.WriteLine("[4]Ändra Rum Id");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 5);
                    Console.WriteLine("[5]Ändra tid");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 6);
                    Console.WriteLine("[6]Ändra förnamn");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 7);
                    Console.WriteLine("[7]Ändra efternamn");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 8);
                    Console.WriteLine("[8]Ändra avdelning");
                    Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 10);
                    Console.WriteLine("[B]Backa");
                    //Hämtar alla egenskaper för jämförelse.
                    var resvId = (from p in db.Reservations
                                    where p.Id == resvEditId
                                    select p.Id).SingleOrDefault();
                    var resvYear = (from p in db.Reservations
                                    where p.Id == resvEditId
                                    select p.ResvYear).SingleOrDefault();
                    var resvMonth = (from p in db.Reservations
                                        where p.Id == resvEditId
                                        select p.ResvMonth).SingleOrDefault();
                    var resvDay = (from p in db.Reservations
                                    where p.Id == resvEditId
                                    select p.ResvDay).SingleOrDefault();
                    var resvRoomId = (from p in db.Reservations
                                        where p.Id == resvEditId
                                        select p.RoomId).SingleOrDefault();
                    var resvTimeStart = (from p in db.Reservations
                                            where p.Id == resvEditId
                                            select p.ResvTimeStart).SingleOrDefault();
                    var resvTimeEnd = (from p in db.Reservations
                                        where p.Id == resvEditId
                                        select p.ResvTimeEnd).SingleOrDefault();
                        
                    //Välj vilket värde som ska ändras.
                    ConsoleKeyInfo key2 = Console.ReadKey(true);
                    switch (key2.KeyChar)
                    {
                        case '1':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 1);
                            Console.Write("Ändra År: ");
                            int.TryParse(Console.ReadLine(), out int newResvYear);
                            var resvYear2 = (from p in db.Reservations
                                             where p.Id == resvEditId
                                             select p).SingleOrDefault();
                            resvYear2.ResvYear = newResvYear;
                            resvYear = newResvYear;
                            break;
                        case '2':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 1);
                            Console.Write("Ändra Månad: ");
                            int.TryParse(Console.ReadLine(), out int newResvMonth);
                            var resvMonth2 = (from p in db.Reservations
                                              where p.Id == resvEditId
                                              select p).SingleOrDefault();
                            resvMonth2.ResvMonth = newResvMonth;
                            resvMonth = newResvMonth;
                            break;
                        case '3':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 2);
                            Console.Write("Ändra Dag: ");
                            int.TryParse(Console.ReadLine(), out int newResvDay);
                            var resvDay2 = (from p in db.Reservations
                                            where p.Id == resvEditId
                                            select p).SingleOrDefault();
                            resvDay2.ResvDay = newResvDay;
                            resvDay = newResvDay;
                            break;
                        case '4':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 3);
                            Console.Write("Ändra Rum Id: ");
                            int.TryParse(Console.ReadLine(), out int newResvRoomId);
                            var resvRoomId2 = (from p in db.Reservations
                                               where p.Id == resvEditId
                                               select p).SingleOrDefault();
                            resvRoomId2.RoomId = newResvRoomId;
                            resvRoomId = newResvRoomId;
                            break;
                        case '5':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 4);
                            Console.Write("Ändra starttimme 0-23: ");
                            int.TryParse(Console.ReadLine(), out int newResvTimeStart);
                            var resvTimeStart2 = (from p in db.Reservations
                                                  where p.Id == resvEditId
                                                  select p).SingleOrDefault();
                            resvTimeStart2.ResvTimeStart = newResvTimeStart;
                            resvTimeStart = newResvTimeStart;
                            Console.SetCursorPosition(addResvLeft, addResvTop + 5);
                            Console.Write("Ändra sluttimme 1-24: ");
                            int.TryParse(Console.ReadLine(), out int newResvTimeEnd);
                            var resvTimeEnd2 = (from p in db.Reservations
                                                where p.Id == resvEditId
                                                select p).SingleOrDefault();
                            resvTimeEnd2.ResvTimeEnd = newResvTimeEnd;
                            resvTimeEnd = newResvTimeEnd;
                            break;
                        case '6':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 6);
                            Console.Write("Ändra förnamn: ");
                            string newResvFname = Console.ReadLine();
                            var post7 = (from p in db.Reservations
                                            where p.Id == resvEditId
                                            select p).SingleOrDefault();
                            post7.LiableFirName = newResvFname;
                            break;
                        case '7':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 7);
                            Console.Write("Ändra efternamn: ");
                            string newResvEname = Console.ReadLine();
                            var post8 = (from p in db.Reservations
                                            where p.Id == resvEditId
                                            select p).SingleOrDefault();
                            post8.LiableSecName = newResvEname;
                            break;
                        case '8':
                            Console.SetCursorPosition(addResvLeft, addResvTop + 8);
                            Console.Write("Ändra avdelning: ");
                            string newResvDepart = Console.ReadLine();
                            var post9 = (from p in db.Reservations
                                            where p.Id == resvEditId
                                            select p).SingleOrDefault();
                            post9.Department = newResvDepart;
                            break;
                        case 'b':
                        case 'B':
                            exit = true;
                            
                            break;
                        default:
                            Console.SetCursorPosition(addResvLeft, addResvTop + 9);
                            Console.WriteLine("Fel.. Prova igen!");
                            Console.ReadKey();
                            break;
                    }
                    //Jämför ändring mot befintliga bokningar.
                    foreach (var cal in db.Reservations)
                    {
                        if (cal.ResvDay == resvDay && cal.ResvMonth == resvMonth && cal.ResvYear == resvYear && cal.RoomId == resvRoomId && cal.Id != resvId)
                        {
                            if (resvTimeStart >= cal.ResvTimeStart && resvTimeEnd <= cal.ResvTimeEnd || resvTimeStart <= cal.ResvTimeStart && resvTimeEnd >= cal.ResvTimeEnd || resvTimeStart <= cal.ResvTimeStart && resvTimeEnd > cal.ResvTimeStart || resvTimeStart < cal.ResvTimeEnd && resvTimeEnd > cal.ResvTimeEnd)
                            {
                                wrong = true;
                                loop = true;
                                break;
                            }
                        }
                    }
                    if(exit) { break; }
                    if (wrong)
                    {
                        TimeOccupiedMessage();
                        loop = true;
                    }
                    else 
                    { 
                        loop = false; 
                        db.SaveChanges(); 
                    }

                    Console.Clear();
                } while (loop);
                
            }
        }

        public static void TimeOccupiedMessage()
        {
            int addResvLeft = 24;
            int addResvTop = 1;
            Console.SetCursorPosition(addResvLeft, addResvTop + 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Upptagen! Välj en annan tid..");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(addResvLeft, addResvTop + 5);
            Console.WriteLine("                             ");
            Console.ReadKey(true);
            Console.SetCursorPosition(addResvLeft, addResvTop + 4);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(addResvLeft, addResvTop + 5);
            Console.WriteLine("                             ");
        }
        public static void DeleteReservation()
        {
            int delResvLeft = 24;
            int delResvTop = 2;
            Console.SetCursorPosition(delResvLeft, delResvTop);
            Console.WriteLine("Ta bort bokning");
            Console.SetCursorPosition(delResvLeft, delResvTop + 1);
            Console.Write("Ange boknings-ID: ");
            int.TryParse(Console.ReadLine(), out int postIdNr);
            using (var db = new BokningsAppenContext())
            {
                var resvPost = db.Reservations;

                var removePost = (from r in db.Reservations
                                  where r.Id == postIdNr
                                  select r).SingleOrDefault();
                if (removePost != null)
                {
                    resvPost.Remove(removePost);
                    db.SaveChanges();
                }
            }
        }
    }
}


