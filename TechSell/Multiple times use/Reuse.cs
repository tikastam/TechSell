using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechSell
{
    public static class Reuse
    {
        

        public static bool gameplay(string card, string word)
        {
            if (card == word)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GiveName(string nam)
        {
            string s = char.ToUpper(nam[0]) + nam.Substring(1).ToLower();
            return s;
        }

        public static string HardSize(int hdsc)
        {
            string a = string.Empty;
            if (hdsc >= 1024)
            {
                a = hdsc / 1024 + "TB";
            }
            else
            {
                a = hdsc + "GB";
            }
            return a;
        }


    }
}
