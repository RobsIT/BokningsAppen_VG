using BokningsAppen_VG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    internal class RoomMeth
    {
        public static void AddRoom()
        {
            int addRoomLeft = 24;
            int addRoomTop = 2;
            Console.SetCursorPosition(addRoomLeft, addRoomTop);
            Console.WriteLine("Lägg till Rum\n");
            using (var db = new BokningsAppenContext())
            {
                int roomNr = 0;
                bool whiteboardAble = false;
                bool projectorAble = false;
                bool wrong1 = false;
                bool loop1 = false;
                do
                {
                    wrong1 = false;
                    loop1 = false;
                    Console.SetCursorPosition(addRoomLeft, addRoomTop + 1);
                    Console.Write("                        ");
                    Console.SetCursorPosition(addRoomLeft, addRoomTop + 1);
                    Console.Write("Ange Rumnummer: ");                      
                    int.TryParse(Console.ReadLine(), out roomNr);
                    foreach (var cal in db.Rooms)
                    {
                        if (roomNr == cal.RoomNr )
                        {
                            wrong1 = true;
                            loop1 = true;
                            break;
                        }
                    }
                    if (wrong1)
                    {
                        
                        Console.SetCursorPosition(addRoomLeft, addRoomTop + 4);
                        Console.WriteLine("                             ");
                        Console.SetCursorPosition(addRoomLeft, addRoomTop + 5);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rumnummret finns redan..");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey(true);
                        Console.SetCursorPosition(addRoomLeft, addRoomTop + 5);
                        Console.WriteLine("                             ");

                    }
                    else { loop1 = false; }

                } while (loop1);
                Console.SetCursorPosition(addRoomLeft, addRoomTop + 3);
                Console.Write("Antal platser: ");
                int.TryParse(Console.ReadLine(), out int seatsQuantity);
                bool loop2 = false;
                do
                {
                    Console.SetCursorPosition(addRoomLeft, addRoomTop + 5);
                    Console.Write("Finns det Whiteboard J/N: ");
                    string wB_Able = Console.ReadLine();
                    if (wB_Able == "j" || wB_Able == "J" ) { whiteboardAble = true; loop2 = false; }
                    else if (wB_Able == "n" || wB_Able == "N") { whiteboardAble = false; loop2 = false; }
                    else { loop2 = true; Console.WriteLine(" Fel! "); }
                } while (loop2);
                do
                {
                    Console.SetCursorPosition(addRoomLeft, addRoomTop + 7);
                    Console.Write("Finns det Projector J/N: ");
                    string pj_Able = Console.ReadLine();
                    if (pj_Able == "j" || pj_Able == "J") { projectorAble = true; loop2 = false; }
                    else if (pj_Able == "n" || pj_Able == "N") { projectorAble = false; loop2 = false; }
                    else { loop2 = true; Console.WriteLine(" Fel! "); } 
                } while (loop2);
                var addRoom = new Room
                {
                    RoomNr = roomNr,
                    SeatsQuantity = seatsQuantity,
                    Whiteboard = whiteboardAble,
                    Projector = projectorAble
                };
                db.Add(addRoom);
                db.SaveChanges();
            }
        }
        public static void EditRoom(int month, int year, int day, int listScroll_1, int listScroll_2)
        {
            bool loop = false;
            do
            {
                bool wrong1 = false;
                bool loop1 = false;
                MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                int changeRoomLeft = 28;
                int changeRoomTop = 1;
                int menySelectionsLeft = 1;
                int menySelectionsTop = 2;
                Console.SetCursorPosition(changeRoomLeft, changeRoomTop);
                Console.WriteLine("Ändra i Rum");
                Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 1);
                Console.Write("Ange Rums-ID: ");
                int.TryParse(Console.ReadLine(), out int roomId);
                Console.SetCursorPosition(1, 1);
                Console.Write("Välj i menyn");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop);
                Console.WriteLine("[1]Ändra rumnummer");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 1);
                Console.WriteLine("[2]Ändra antal platser");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 2);
                Console.WriteLine("[3]Ändra finns Whiteboard");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 3);
                Console.WriteLine("[4]Ändra finns projector");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 4);
                Console.WriteLine("[B]Backa");
                using (var db = new BokningsAppenContext())
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case '1':
                            int newRoomNr = 0;
                            do
                            {
                                wrong1 = false;
                                loop1 = false;
                                Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 2);
                                Console.Write("                        ");                         
                                Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 2);
                                Console.Write("Ändra rumnummer: ");                         
                                int.TryParse(Console.ReadLine(), out newRoomNr);
                                foreach (var cal in db.Rooms)
                                {
                                    if (newRoomNr == cal.RoomNr)
                                    {
                                        wrong1 = true;
                                        loop1 = true;
                                        break;
                                    }
                                }
                                
                                if (wrong1)
                                {
                                    Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 4);
                                    Console.WriteLine("                             ");
                                    Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 5);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Rumnummret finns redan..");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadKey(true);
                                    Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 5);
                                    Console.WriteLine("                             ");
                                }
                                else { loop1 = false; }
                            } while (loop1);
                            var post1 = (from c in db.Rooms
                                         where c.Id == roomId
                                         select c).SingleOrDefault();
                            if (post1 != null)
                            {
                                post1.RoomNr = newRoomNr;
                                db.SaveChanges();
                            }
                            break;
                        case '2':
                            Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 2);
                            Console.Write("Ändra antal platser: ");
                            int.TryParse(Console.ReadLine(), out int newRoomSeats);
                            var post2 = (from c in db.Rooms
                                         where c.Id == roomId
                                         select c).SingleOrDefault();
                            if (post2 != null)
                            {
                                post2.SeatsQuantity = newRoomSeats;
                                db.SaveChanges();
                            }
                            break;
                        case '3':
                            bool whiteboardAble = false;
                            bool loop2 = false;
                            do
                            {
                                Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 2);
                                Console.Write("Ändra Whiteboard J/N: ");
                                string wB_Able = Console.ReadLine();
                                if (wB_Able == "j" || wB_Able == "J") { whiteboardAble = true; loop2 = false; }
                                else if (wB_Able == "n" || wB_Able == "N") { whiteboardAble = false; loop2 = false; }
                                else { loop2 = true; Console.WriteLine(" Fel! "); }
                            } while (loop2);
                            var post3 = (from c in db.Rooms
                                         where c.Id == roomId
                                         select c).SingleOrDefault();
                            if (post3 != null)
                            {
                                post3.Whiteboard = whiteboardAble;
                                db.SaveChanges();
                            }
                            break;
                        case '4':
                            bool projectorAble = false;
                            bool loop3 = false;
                            do
                            {
                                Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 3);
                                Console.Write("Ändra Projector J/N: ");
                                string pj_Able = Console.ReadLine();
                                if (pj_Able == "j" || pj_Able == "J") { projectorAble = true; loop3 = false; }
                                else if (pj_Able == "n" || pj_Able == "N") { projectorAble = false; loop3 = false; }
                                else { loop2 = true; Console.WriteLine(" Fel! "); }
                            } while (loop3);
                            var post4 = (from c in db.Rooms
                                         where c.Id == roomId
                                         select c).SingleOrDefault();
                            if (post4 != null)
                            {
                                post4.Projector = projectorAble;
                                db.SaveChanges();
                            }
                            break;
                        case 'b':
                        case 'B':
                            loop = false;
                            break;
                        default:
                            Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 4);
                            Console.WriteLine("Fel.. Prova igen!");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                } 
            } while (loop);
        }    
        public static void DeleteRoom()
        {
            int changeRoomLeft = 28;
            int changeRoomTop = 1;
            Console.SetCursorPosition(changeRoomLeft, changeRoomTop);
            Console.WriteLine("Ta bort rum");
            Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 1);
            Console.Write("Ange rum-ID: ");
            int.TryParse(Console.ReadLine(), out int postId);
            using (var db = new BokningsAppenContext())
            {
                var roomPost = db.Rooms;
                var removePost = (from r in db.Rooms
                                    where r.Id == postId
                                    select r).SingleOrDefault();
                foreach (var post in db.Reservations)
                {
                    if (post.Id == removePost.Id)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 3);
                        Console.WriteLine("Det finns bokningar på rummet!");
                        Console.SetCursorPosition(changeRoomLeft, changeRoomTop + 4);
                        Console.WriteLine("Bokningarna måste tas bort först!");
                        Console.ForegroundColor = 0;
                        Console.ReadKey(true);
                        break;
                    }
                    else if (removePost.Id == postId)
                    {
                        roomPost.Remove(removePost);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
