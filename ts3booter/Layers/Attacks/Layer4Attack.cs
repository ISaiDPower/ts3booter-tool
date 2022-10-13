using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ts3booter.Layers.Attacks
{
    internal class Layer4Attack
    {
        MainAPI.Ts3Booter ts3;
        public string Host { get; set; }
        public int Port { get; set; }
        public int Time { get; set; }
        public string Method { get; set; }
        public bool Repeat { get; set; }
        public Layer4Attack(MainAPI.Ts3Booter booter)
        {
            ts3 = booter;
        }

        public bool CheckParameters()
        {
            if (Host == null || Host == "")
            {
                return false;
            } else if (Port == 0)
            {
                return false;
            } else if (Time == 0)
            {
                return false;
            } else if (Method == null || Method == "")
            {
                return false;
            }
            return true;
        }
        public void StartAttack()
        {

        }
    }
}
