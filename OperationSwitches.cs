namespace BokningsAppen_VG
{
    internal class OperationSwitches
    {
        public static async Task AdminMenu(int month, int year, int day, int listScroll_1, int listScroll_2)
        {
            bool loop = true;
            while (loop)
            {
                await MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);

                int menySelectionsLeft = 1;
                int menySelectionsTop = 2;

                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;   
                Console.WriteLine("ADMIN-MODE");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop);
                Console.WriteLine("[1]Lägg till bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 1);
                Console.WriteLine("[2]Ändra i bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 2);
                Console.WriteLine("[3]Ta bort bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 4);
                Console.WriteLine("[4]Lägg till rum");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 5);
                Console.WriteLine("[5]Ändra i rum");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 6);
                Console.WriteLine("[6]Ta bort rum");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 8);
                Console.WriteLine("[7]Querys");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 10);
                Console.WriteLine("[B]Backa");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.AddReservation();
                        break;
                    case '2':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.EditReservation(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case '3':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.DeleteReservation();
                        break;
                    case '4':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        RoomMeth.AddRoom();
                        break;
                    case '5':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        RoomMeth.EditRoom(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case '6':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        RoomMeth.DeleteRoom();
                        break;
                    case '7':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        Querys.LinqQuerys(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case 'b':
                    case 'B':
                        loop = false;
                        break;
                    case 't':
                    case 'T':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_2 > 1) { listScroll_2--; }
                        }
                        break;
                    case 'g':
                    case 'G':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_2 < db.Reservations.Count()) { listScroll_2++; }
                        }
                        break;
                    case 'y':
                    case 'Y':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_1 > 1) { listScroll_1--; }
                        }
                        break;
                    case 'h':
                    case 'H':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_1 < db.Rooms.Count()) { listScroll_1++; }
                        }
                        break;
                    case 'x':
                    case 'X':
                        if (month < 12) { month++; }
                        else if (month == 12) { month = 1; year++; }
                        break;
                    case 'z':
                    case 'Z':
                        if (month > 1) { month--; }
                        else if (month == 1) { month = 12; year--; }
                        break;
                    case 'd':
                    case 'D':
                        if (day == 31) { day = 29; }
                        else if (day == 7 || day == 14 || day == 21 || day == 28) { day = day - 6; }
                        else if (day < 31) { day++; }
                        break;
                    case 'a':
                    case 'A':
                        if (day == 1 || day == 8 || day == 15 || day == 22) { day = day + 6; }
                        else if (day == 29) { day = 31; }
                        else if (day > 1) { day--; }
                        break;
                    case 's':
                    case 'S':
                        if (day <= 24) { day = day + 7; }
                        else if (day >= 29 && day <= 31) { day = day - 28; }
                        else if (day >= 25 && day <= 28) { day = day - 21; }
                        break;
                    case 'w':
                    case 'W':
                        if (day >= 1 && day <= 3) { day = day + 28; }
                        else if (day >= 4 && day <= 7) { day = day + 21; }
                        else if (day >= 8) { day = day - 7; }
                        break;
                    default:
                        Console.SetCursorPosition(menySelectionsLeft + 30, menySelectionsTop);
                        Console.WriteLine("Fel.. Prova igen!");
                        Console.ReadKey(true);
                        break;
                }
                Console.Clear();
            }
        }
        public static async Task OperatingMenu(int month, int year, int day, int listScroll_1, int listScroll_2)
        {
            bool loop = true;
            while (loop)
            {
                MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);

                int menySelectionsLeft = 1;
                int menySelectionsTop = 2;
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BOKA TID");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop);
                Console.WriteLine("[1]Lägg till bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 1);
                Console.WriteLine("[2]Ändra i bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 2);
                Console.WriteLine("[3]Ta bort bokning");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 10);
                Console.WriteLine("[B]Backa");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.AddReservation();
                        break;
                    case '2':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.EditReservation(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case '3':
                        Console.Clear();
                        MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        ReservationMeths.DeleteReservation();
                        break;
                    case 'b':
                    case 'B':
                        loop = false;
                        break;
                    case 't':
                    case 'T':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_2 > 1) { listScroll_2--; }
                        }
                        break;
                    case 'g':
                    case 'G':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_2 < db.Reservations.Count()) { listScroll_2++; }
                        }
                        break;
                    case 'y':
                    case 'Y':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_1 > 1) { listScroll_1--; }
                        }
                        break;
                    case 'h':
                    case 'H':
                        using (var db = new BokningsAppenContext())
                        {
                            if (listScroll_1 < db.Rooms.Count()) { listScroll_1++; }
                        }
                        break;
                    case 'x':
                    case 'X':
                        if (month < 12) { month++; }
                        else if (month == 12) { month = 1; year++; }
                        break;
                    case 'z':
                    case 'Z':
                        if (month > 1) { month--; }
                        else if (month == 1) { month = 12; year--; }
                        break;
                    case 'd':
                    case 'D':
                        if (day == 31) { day = 29; }
                        else if (day == 7 || day == 14 || day == 21 || day == 28) { day = day - 6; }
                        else if (day < 31) { day++; }
                        break;
                    case 'a':
                    case 'A':
                        if (day == 1 || day == 8 || day == 15 || day == 22) { day = day + 6; }
                        else if (day == 29) { day = 31; }
                        else if (day > 1) { day--; }
                        break;
                    case 's':
                    case 'S':
                        if (day <= 24) { day = day + 7; }
                        else if (day >= 29 && day <= 31) { day = day - 28; }
                        else if (day >= 25 && day <= 28) { day = day - 21; }
                        break;
                    case 'w':
                    case 'W':
                        if (day >= 1 && day <= 3) { day = day + 28; }
                        else if (day >= 4 && day <= 7) { day = day + 21; }
                        else if (day >= 8) { day = day - 7; }
                        break;
                    default:
                        Console.SetCursorPosition(menySelectionsLeft + 30, menySelectionsTop);
                        Console.WriteLine("Fel.. Prova igen!");
                        Console.ReadKey(true);
                        break;
                }
                Console.Clear();
            }
        }
    }
}
