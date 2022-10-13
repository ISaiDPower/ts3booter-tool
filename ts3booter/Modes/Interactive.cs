using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ts3booter.Modes
{
    public class Interactive
    {
        string user = "";

        public void About()
        {
            Other.Menus.showTitle();
            Other.Menus.setTitle("About");
            Other.Menus.showMessage("This tool is used to communicate with ts3booter.net without the use of an API since the plans can be a little pricy");
            Other.Menus.showMessage("This tool was made only for personal skills (I am trying to see how good I make programs)");
            Other.Menus.showMessage("Instagram: @isaid.photos", ConsoleColor.Magenta);
            Other.Menus.showMessage("Discord: JPN#6969", ConsoleColor.Blue);
            Other.Menus.showMessage("Website: isaidpower.dev");
            Other.Menus.showMessage("Made in Romania!", ConsoleColor.Red);
            Console.WriteLine("\n");
            Other.Menus.showMessage("Press ANY key to return to the main menu");
            Console.ReadKey();
        }

        public void Home(MainAPI.Ts3Booter booter)
        {
retry_select_menu: Other.Menus.showTitle();
            Other.Menus.setTitle("Main Menu");
            Other.Menus.showMessage("Sponsored by MineHost.ro - cheap web and Minecraft hosting", ConsoleColor.Yellow); Console.WriteLine();
            string windows_user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.Write("Hello, "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(user); Console.ResetColor();
            Console.WriteLine("!");
            Console.WriteLine();
            Other.Menus.createItem(0, "Layer4 Attack");
            Other.Menus.createItem(1, "Layer7 Attack");
            Other.Menus.createItem(2, "Open ts3booter.net");
            Other.Menus.createItem(3, "About");
            Other.Menus.createItem(4, "Logout");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    Layers.Layer4.Start(booter); goto retry_select_menu;
                case ConsoleKey.D1:
                  //  Layer7(booter); goto retry_select_menu;
                case ConsoleKey.NumPad0:
                    Layers.Layer4.Start(booter); goto retry_select_menu;
                case ConsoleKey.NumPad1:
                   // Layer7(booter); goto retry_select_menu;
                case ConsoleKey.D2:
                    System.Diagnostics.Process.Start("https://ts3booter.net"); goto retry_select_menu;
                case ConsoleKey.NumPad2:
                    System.Diagnostics.Process.Start("https://ts3booter.net");
                    goto retry_select_menu;
                case ConsoleKey.D3:
                    About();
                    goto retry_select_menu;
                case ConsoleKey.NumPad3:
                    About();
                    goto retry_select_menu;
                case ConsoleKey.D4:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad4:
                    Environment.Exit(0);
                    break;
                default:
                    goto retry_select_menu;
            }
        }
        public void InteractiveMain1()
        {
            Other.Menus.setTitle("Login");
        retry: Other.Menus.showTitle();
            string windows_user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.Write("Hello, "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(windows_user); Console.ResetColor();
            Console.WriteLine("!"); Console.WriteLine("Please login!");
            string username = Other.Menus.showInput("Username");
            string password = Other.Menus.showInput("Password");

            MainAPI.Ts3Booter booter = new MainAPI.Ts3Booter(username, password);
            if (booter.Login() == false)
            {
                Other.Menus.showMessage("Login failed, press ANY key to try again!", ConsoleColor.Red);
                Console.ReadKey();
                goto retry;
            } else {
                Other.Menus.showMessage("Login successful, press ANY key to continue!", ConsoleColor.Green);
                user = username;
                Console.ReadKey();
                Home(booter);
            }
        }
    }
}
