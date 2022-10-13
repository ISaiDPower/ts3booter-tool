using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ts3booter.Layers
{
    internal class Layer7
    {
        private static string SetMethod(MainAPI.Ts3Booter ts3Booter)
        {
            string[] methods = ts3Booter.GetMethods(7);
        set_method: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer7 Set Method");
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
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to use this method? (" + methods[option] + ")", "Confirm Method", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return methods[option];
                }
                else
                {
                    goto set_method;
                }
            }
        }
        private static void SetParameters(Layers.Attacks.Layer7Attack attack, MainAPI.Ts3Booter ts)
        {
            string host = "";
            string method = "";
            int port = 0;
            int time = 0;
        set_parameters: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer7 Parameters");
            Other.Menus.showMessage("Current configuration");
            Other.Menus.showMessage("Url: " + Properties.Settings.Default.l7h);
            Other.Menus.showMessage("Port: " + Properties.Settings.Default.l7p);
            Other.Menus.showMessage("Time: " + Properties.Settings.Default.l7t);
            Other.Menus.showMessage("Method: " + Properties.Settings.Default.l7m);
            Console.WriteLine();
            Other.Menus.createItem(0, "Url");
            Other.Menus.createItem(1, "Port");
            Other.Menus.createItem(2, "Time");
            Other.Menus.createItem(3, "Method");
            Other.Menus.createItem(4, "Go back");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Url");
                    host = Other.Menus.showInput("Url");
                    if (host != null || host != "")
                    {
                        Properties.Settings.Default.l7h = host;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad0:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Url");
                    host = Other.Menus.showInput("Url");
                    if (host != null || host != "")
                    {
                        Properties.Settings.Default.l7h = host;
                    }
                    goto set_parameters;
                case ConsoleKey.D1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    if (port != 0)
                    {
                        Properties.Settings.Default.l7p = port;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad1:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Port");
                    port = Int32.Parse(Other.Menus.showInput("Port"));
                    if (port != 0)
                    {
                        Properties.Settings.Default.l7p = port;
                    }
                    goto set_parameters;
                case ConsoleKey.D2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    if (time != 0)
                    {
                        Properties.Settings.Default.l7t = time;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad2:
                    Other.Menus.showTitle();
                    Other.Menus.setTitle("Layer7 Time");
                    time = Int32.Parse(Other.Menus.showInput("Time"));
                    if (time != 0)
                    {
                        Properties.Settings.Default.l7t = time;
                    }
                    goto set_parameters;
                case ConsoleKey.D3:
                    method = SetMethod(ts);
                    if (method != null || method != "")
                    {
                        Properties.Settings.Default.l7m = method;
                    }
                    goto set_parameters;
                case ConsoleKey.NumPad3:
                    method = SetMethod(ts);
                    if (method != null || method != "")
                    {
                        Properties.Settings.Default.l7m = method;
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
            Attacks.Layer7Attack layer7 = new Attacks.Layer7Attack(booter);
        layer7mm: Other.Menus.showTitle();
            Other.Menus.setTitle("Layer7 Menu");
            Other.Menus.createItem(0, "Set parameters");
            Other.Menus.createItem(1, "Go back");
            if (layer7.CheckParameters() == true)
            {
                Other.Menus.createItem(2, "Start attack");
            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    SetParameters(layer7, booter);
                    layer7.Url = Properties.Settings.Default.l7h;
                    layer7.Port = Properties.Settings.Default.l7p;
                    layer7.Time = Properties.Settings.Default.l7t;
                    layer7.Method = Properties.Settings.Default.l7m;
                    goto layer7mm;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.NumPad0:
                    SetParameters(layer7, booter);
                    layer7.Url = Properties.Settings.Default.l7h;
                    layer7.Port = Properties.Settings.Default.l7p;
                    layer7.Time = Properties.Settings.Default.l7t;
                    layer7.Method = Properties.Settings.Default.l7m;
                    goto layer7mm;
                case ConsoleKey.NumPad1:
                    break;
                case ConsoleKey.D2:
                    if (layer7.CheckParameters() == true)
                    {
                        layer7.StartAttack();
                        goto layer7mm;
                    }
                    else
                    {
                        goto layer7mm;
                    }
                case ConsoleKey.NumPad2:
                    if (layer7.CheckParameters() == true)
                    {
                        layer7.StartAttack();
                        goto layer7mm;
                    }
                    else
                    {
                        goto layer7mm;
                    }
                default:
                    goto layer7mm;
            }
        }
    }
}
