using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public interface Ipho
    {
        float MainCamera { get; set; }
        float ScSize { get; set; }
        int Ram { get; set; }
        int InternalMem { get; set; }
        void Advertise();
    }
}
