using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public interface IallTech
    {
        double price { get; set; }
        void Selling(string NameSup, double Purchase);
    }
}
