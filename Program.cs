using Microsoft.Identity.Client;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace BokningsAppen_VG
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int year = 2024;
            int month = 1;
            int day = 1;
            int listScroll_1 = 1;
            int listScroll_2 = 1;
            while (true)
            {
                int menySelectionsLeft = 1;
                int menySelectionsTop = 2;
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("SELECT MODE");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop);
                Console.WriteLine("[1]Admin-läge");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 1);
                Console.WriteLine("[2]Drift-läge");
                Console.SetCursorPosition(menySelectionsLeft, menySelectionsTop + 2);
                Console.WriteLine("[E]Avsluta");
             
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        await MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        OperationSwitches.AdminMenu(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case '2':
                        Console.Clear();
                        await MainViewMeth.MainView(month, year, day, listScroll_1, listScroll_2);
                        OperationSwitches.OperatingMenu(month, year, day, listScroll_1, listScroll_2);
                        break;
                    case 'e':
                    case 'E':
                        Environment.Exit(0);
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