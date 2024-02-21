using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public interface IComputer
    {
        string proc { get; set; }
        string graph { get; set; }
        int ram { get; set; }
        int hdsize { get; set; }
        void Description();

    }
}
