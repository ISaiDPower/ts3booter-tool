using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ts3booter
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Other.Menus.setTitle("Ts3booter.net");
            Other.Menus.showTitle();
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments detected, switching to interactive mode.");
                System.Threading.Thread.Sleep(1000);
                Modes.Interactive interactive = new Modes.Interactive();
                interactive.InteractiveMain1();
            }
        }
    }
}
