using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public sealed class SmartPhones : IallTech, Ipho,IManuf
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public double price { get; set; }
        public float MainCamera { get; set; }
        public float ScSize { get; set; }
        public int Ram { get; set; }
        public int InternalMem { get; set; }

        private int _lighting;

        private int _refreshrate;
        private int _SelfieCamera { get; set; }
        private string _OpSystem { get; set; }
        private string _Charging { get; set; }

        private const string an = "Another";

            public string Charge { get
            {
                return _Charging;
            }
            set
            {
                if(value == MultiEnums.Ch.USBA.ToString() || value == MultiEnums.Ch.USBB.ToString() || value == MultiEnums.Ch.USBC.ToString() || value == MultiEnums.Ch.MicroUSB.ToString() || value == MultiEnums.Ch.Lightning.ToString()){
                    _Charging = value;
                }
                else
                {
                    _Charging = an;
                }
            }
        }

        private List<Supplier> s = new List<Supplier>();

        public SmartPhones(string mark,string model,double price,float maincam,float scsz,int ram,int intmem,
            int ligh,int refr,int selfie,string ops,string ch)
        {
            this.Mark = mark;
            this.Model = model;
            this.price = price;
            this.MainCamera = maincam;
            this.ScSize = scsz;
            this.Ram = ram;
            this.InternalMem = intmem;
            this._lighting = ligh;
            this._refreshrate = refr;
            this._SelfieCamera = selfie;
            this._OpSystem = ops;
            this.Charge = ch.ToUpper();
        }


        private void ChargerUse()
        {
            switch (Charge)
            {
                case an:
                    Console.WriteLine("Don't use this charger for any other device");
                    break;
                default:
                    Console.WriteLine("Check the other devices input before using this phone charger");
                    break;
            }
        }

        
        private void CamUse()
        {
            switch (_SelfieCamera)
            {
                case  int a when a<=0:
                    Console.WriteLine("You dont have a selfie camera");
                    break;
                case int a when a < 5:
                    Console.WriteLine("You have a selfie camera of " + _SelfieCamera + " mpix");
                    break;
                case int a when (a > 5 && a < 32):
                    Console.WriteLine($"The {_SelfieCamera} mpix selfie camera will allow to take a nice photos");
                    break;
                case int a when (a > 32 && a <= 60):
                    Console.WriteLine($"The {_SelfieCamera} mpix selfie camera will allow to take a incredibly good photos");
                    break;
                default:
                    Console.WriteLine("Check your input for selfie camera. We couldn't find a phone with selfie camera more then 60 mpix.");
                    break;
            }

            switch (MainCamera)
            {
                case float a when a <= 0:
                    Console.WriteLine("You dont have a camera? Check your input.");
                    break;
                case float a when a < 12:
                    Console.WriteLine("You have a main camera of " + MainCamera + " mpix");
                    break;
                case float a when (a > 12 && a < 64):
                    Console.WriteLine($"The {MainCamera} mpix main camera will allow to take a nice photos");
                    break;
                case float a when (a > 64 && a <= 200):
                    Console.WriteLine($"The {MainCamera} mpix main camera will allow to take a incredibly good photos");
                    break;
                default:
                    Console.WriteLine("Check your input for main camera. We couldn't find a phone with selfie camera more then 200 mpix.");
                    break;
            }
        }

        

        private void Scrlig()
        {
            Console.WriteLine($"Screen - {ScSize}, lighting - {_lighting} nits, refresh rate {_refreshrate} Hz");
        }

        private void SysHard()
        {
            Console.WriteLine($"{Mark} {Model} with the operationg system {_OpSystem}, internal memory of {InternalMem}GB and ram memory {Ram}");
        }

        private bool Version()
        {
            int min,max;

            if (_OpSystem.ToUpper().Contains(MultiEnums.OS.ANDROID.ToString()))
            {
                min = 10; max = 14;
            }
            else if (_OpSystem.ToUpper().Contains(MultiEnums.OS.IOS.ToString()))
            {
                min = 14; max = 17;
            }
            else
            {
                return false;
            }
            
            string v = _OpSystem.Substring(_OpSystem.Length - 2);
            int ver = int.Parse(v);
            if(ver<min || ver > max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //Main Logic for this class
        public void Advertise()
        {
            SysHard();
            Scrlig();

        }

        public void Usability()
        {
            CamUse();
            ChargerUse();
        }

        public void Selling(string NameSup, double Purchase)
        {
            Console.WriteLine("");

            if (!Version())
            {
                Console.WriteLine("Outlet Model,not available operating system or invaid input - Check your input.");
            }
            else
            {
                if (price < Purchase + Purchase / 8)
                {
                    Console.WriteLine($"If you order {Mark} {Model} from {Reuse.GiveName(NameSup)} you don't earn to much or you can lose money.Try to negotiate for a lower purchase price");
                }
                else
                {
                    Console.WriteLine($"If you choose {Reuse.GiveName(NameSup)} for supply {Mark} {Model} you will earn {price - Purchase}$ on the price of {price}$");
                }
            }

                Supplier su = new Supplier(Reuse.GiveName(NameSup), Purchase);
                s.Add(su);
            }

        public void DuplicateSup()
        {
            Console.WriteLine("");
            var ord = s.OrderBy(x => x.name).ToList();
            var dup = new List<string>();
            
            for (int i = 0; i < ord.Count-1; i++)
            {
                
                    if (ord[i].name == ord[i + 1].name)
                    {
                        dup.Add(ord[i].name);
                    }
            }

            dup = dup.Distinct().ToList();
            if(ord.Count == 0)
            {
                Console.WriteLine("Add suppliers");
            }
            else
            {
                if (dup.Count == 0)
            {
                Console.WriteLine("Choose the best offer \n");
            }
            else if (dup.Count == 1)
            {
                foreach (var item in dup)
                {
                    Console.WriteLine(item + " is a duplicate check input \n");
                }
            }
            else
            {
                for (int i=0;i<dup.Count;i++)
                {
                    if (i == dup.Count - 1)
                    {
                        Console.Write(dup[i] + " ");
                    }
                    else
                    {
                        Console.Write(dup[i] + ", ");
                    }
                }
                Console.Write("are duplicates check input \n");
            }

            }

            

        }
            
        

        

         

        


    }
}
