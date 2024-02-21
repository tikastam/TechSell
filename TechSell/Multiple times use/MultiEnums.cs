using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public static class MultiEnums
    {
        public enum Ch
        {
            USBA,
            USBB,
            USBC,
            MicroUSB,
            Lightning
        }

        public enum OS
        {
            ANDROID,
            IOS
        }
        public enum gcardcomplap
        {
            nvidia,
            radeon,
            integrated
        }

        public enum gcardintegr
        {
            intrad,
            intel
        }
    }
}
