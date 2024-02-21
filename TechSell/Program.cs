using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    class Program
    {
        static void Main(string[] args)
        {

            Laptop IdeaPad5Pro = new Laptop("Lenovo", "IdeaPad5 Pro", "Intel i7-12700H", "IPS", 16, 16, 512, "Nvidia RTX 3060", "Intel Iris Xe"
                , 350, 1.55, 1500);

            IdeaPad5Pro.Description();

            IdeaPad5Pro.Selling("Kimtec", 1300);
            IdeaPad5Pro.Selling("Ewe", 1400);
            IdeaPad5Pro.Selling("Spektar", 1100);
            IdeaPad5Pro.Selling("Comtrade", 1150);
            IdeaPad5Pro.Selling("KlikKlak", 1125);


            IdeaPad5Pro.FBest();


            Console.ReadLine();
        }
    }
}
