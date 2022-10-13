using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ts3booter.Layers
{
    internal class Layer4
    {
        private static string SetMethod(MainAPI.Ts3Booter ts3Booter)
        {
            string[] methods = ts3Booter.GetMethods();
set_method: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer4 Set Method");
            int i = 0;
            foreach (string method in methods)
            {
                Other.Menus.createItem(i, method);
                i++;
            }
            Console.WriteLine();
            int option = Int32.Parse(Other.Menus.showInput("No. of method"));
            if (option > i)
            {
                Other.Menus.showMessage("Invalid method number, press ANY key to try again");
                Console.ReadKey();
                goto set_method;
            } else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to use this method? (" + methods[option] + ")", "Confirm Method", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return methods[option];
                } else
                {
                    goto set_method;
                }
            }
        }
        private static void SetParameters(Layers.Attacks.Layer4Attack attack, MainAPI.Ts3Booter ts)
        {
            string host = "";
            string method = "";
            int port = 0;
            int time = 0;
set_parameters: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer4 Parameters");
            Other.Menus.showMessage("Current configuration");
            Other.Menus.showMessage("Host: " + Properties.Settings.Default.l4h);
            Other.Menus.showMessage("Port: " + Properties.Settings.Default.l4p);
            Other.Menus.showMessage("Time: " + Properties.Settings.Default.l4t);
            Other.Menus.showMessage("Method: " + Properties.Settings.Default.l4m);
            Console.WriteLine();
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
                    if (host != null || host != "")
                    {
                        Properties.Settings.Default.l4h = host;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad0:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Host");
                    host = Other.Menus.showInput("Host");
                    if (host != null || host != "")
                    {
                        Properties.Settings.Default.l4h = host;
                    }
                    goto set_parameters;
                case ConsoleKey.D1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    if (port != 0)
                    {
                        Properties.Settings.Default.l4p = port;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    if (port != 0)
                    {
                        Properties.Settings.Default.l4p = port;
                    }
                    goto set_parameters;
                case ConsoleKey.D2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    if (time != 0)
                    {
                        Properties.Settings.Default.l4t = time;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer4 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    if (time != 0)
                    {
                        Properties.Settings.Default.l4t = time;
                    }
                    goto set_parameters;
                case ConsoleKey.D3:
                    method = SetMethod(ts);
                    if (method != null || method != "")
                    {
                        Properties.Settings.Default.l4m = method;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad3:
                    method = SetMethod(ts);
                    if (method != null || method != "")
                    {
                        Properties.Settings.Default.l4m = method;
                    }
                    goto set_parameters;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.NumPad4:
                    break;
                default:
                    goto set_parameters;
            }

        }
        public static void Start(MainAPI.Ts3Booter booter)
        {
            Attacks.Layer4Attack layer4 = new Attacks.Layer4Attack(booter);
        layer4mm: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer4 Menu");
            Other.Menus.createItem(0, "Set parameters");
            Other.Menus.createItem(1, "Go back");
            if (layer4.CheckParameters() == true)
            {
                Other.Menus.createItem(2, "Start attack");
            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    SetParameters(layer4, booter);
                    layer4.Host = Properties.Settings.Default.l4h;
                    layer4.Port = Properties.Settings.Default.l4p;
                    layer4.Time = Properties.Settings.Default.l4t;
                    layer4.Method = Properties.Settings.Default.l4m;
                    goto layer4mm;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.NumPad0:
                    SetParameters(layer4, booter);
                    layer4.Host = Properties.Settings.Default.l4h;
                    layer4.Port = Properties.Settings.Default.l4p;
                    layer4.Time = Properties.Settings.Default.l4t;
                    layer4.Method = Properties.Settings.Default.l4m;
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
    }
}
