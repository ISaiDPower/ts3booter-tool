using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ts3booter.Layers
{
    internal class Layer4
    {

        private static void SetParameters(Layers.Attacks.Layer4Attack attack, MainAPI.Ts3Booter ts)
        {
            string host, method;
            int port, time;
set_parameters: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer4 Parameters");
            Other.Menus.createItem(0, "Host");
            Other.Menus.createItem(1, "Port");
            Other.Menus.createItem(2, "Time");
            Other.Menus.createItem(3, "Method");
            Other.Menus.createItem(4, "Go back");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Host");
                    host = Other.Menus.showInput("Host");
                    goto set_parameters;
                case ConsoleKey.NumPad0:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Host");
                    host = Other.Menus.showInput("Host");
                    goto set_parameters;
                case ConsoleKey.D1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    goto set_parameters;
                case ConsoleKey.NumPad1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    goto set_parameters;
                case ConsoleKey.D2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    goto set_parameters;
                case ConsoleKey.NumPad2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    goto set_parameters;

            }

        }
        public static void Start(MainAPI.Ts3Booter booter)
        {
        layer4mm: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer4 Menu");
            Other.Menus.createItem(0, "Set parameters");
            Other.Menus.createItem(1, "Go back");
            Attacks.Layer4Attack layer4 = new Attacks.Layer4Attack(booter);
            if (layer4.CheckParameters() == true)
            {
                Other.Menus.createItem(2, "Start attack");
            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    SetParameters(layer4, booter);
                    goto layer4mm;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.NumPad0:
                    SetParameters(layer4, booter);
                    goto layer4mm;
                case ConsoleKey.NumPad1:
                    break;
                case ConsoleKey.D2:
                    if (layer4.CheckParameters() == true)
                    {
                        layer4.StartAttack();
                        goto layer4mm;
                    } else
                    {
                        goto layer4mm;
                    }
                case ConsoleKey.NumPad2:
                    if (layer4.CheckParameters() == true)
                    {
                        layer4.StartAttack();
                        goto layer4mm;
                    } else
                    {
                        goto layer4mm;
                    }
                default:
                    goto layer4mm;
            }
        }
        public static void GetMethods(MainAPI.Ts3Booter booter)
        {

        }
    }
}
