using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG
{
    public class Window
    {
        public static async Task DrawWindowFull(int left , int top, int width, int height)
        {
            try
            {
                Console.SetCursorPosition(left - 1, top - 1);
                Console.Write('┌');
                for (int i = 0; i < width; i++)
                {
                    Console.Write('─');
                }
                Console.WriteLine('┐');
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(left - 1, top + i);
                    Console.WriteLine('│');
                }
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(left + width, top + i);
                    Console.WriteLine('│');
                }
                Console.SetCursorPosition(left - 1, top + height);
                Console.Write('└');
                for (int i = 0; i < width; i++)
                {
                    Console.Write('─');
                }
                Console.WriteLine('┘');
            }
            catch (Exception)
            {
                Console.SetCursorPosition(0, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Du behöver zooma ut Consolen. Ctrl + scrolla ut. Tryck sedan Restart.");
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
        }
        public static async Task DrawWindowNoLeftWall(int left , int top, int width, int height)
        {
            try
            {
                Console.SetCursorPosition(left - 1, top - 1);
                for (int i = 0; i <= width; i++)
                {
                    Console.Write('─');
                }
                Console.WriteLine('┐');
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(left + width, top + i);
                    Console.WriteLine('│');
                }
                Console.SetCursorPosition(left - 1, top + height);
                for (int i = 0; i <= width; i++)
                {
                    Console.Write('─');
                }
                Console.WriteLine('┘');
            }
            catch (Exception)
            {
                Console.SetCursorPosition(0, 10);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Du behöver zooma ut Consolen. Ctrl + scrolla ut. Tryck sedan Restart.");
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
        }
    }
}
