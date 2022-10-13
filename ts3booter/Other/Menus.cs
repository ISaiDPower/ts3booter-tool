using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ts3booter.Other
{
    internal class Menus
    {
        public static void setTitle(string value)
        {
            Console.Title = value + " | ts3booter.net | by JPN#6969 | isaidpower.dev <- my website";
        }
        public static void createItem(int index, string value)
        {
            Console.ResetColor();
            Console.Write("["); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(index); Console.ResetColor();
            Console.WriteLine("] " + value);
        }
        public static void showMessage(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ResetColor();
            Console.Write("["); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("!"); Console.ResetColor();
            Console.Write("] "); Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static string showInput(string prompt)
        {
            Console.ResetColor();
            Console.Write("["); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("?"); Console.ResetColor();
            Console.Write("] " + prompt + ": "); Console.ForegroundColor= ConsoleColor.Red;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }
        public static void showTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("███▀▀██▀▀███               ▀███▀▀▀██▄                   ██");
            Console.WriteLine("█▀   ██   ▀█                 ██    ██                   ██");
            Console.WriteLine("     ██     ▄██▀███ ██▀▀█▄   ██    ██ ▄██▀██▄  ▄██▀██▄██████  ▄▄█▀██▀███▄███");
            Console.WriteLine("     ██     ██   ▀▀███  ▀██  ██▀▀▀█▄▄██▀   ▀████▀   ▀██ ██   ▄█▀   ██ ██▀ ▀▀");
            Console.WriteLine("     ██     ▀█████▄     ▄██  ██    ▀███     ████     ██ ██   ██▀▀▀▀▀▀ ██");
            Console.WriteLine("     ██     █▄   ██   ▀▀██▄  ██    ▄███▄   ▄████▄   ▄██ ██   ██▄    ▄ ██");
            Console.WriteLine("   ▄████▄   ██████▀      ██▄████████  ▀█████▀  ▀█████▀  ▀████ ▀█████▀████▄");
            Console.WriteLine("   Tool by JPN     ███  ▄█▀");
            Console.WriteLine("                   █████▀\n\n"); Console.ResetColor();
        }
    }
}
