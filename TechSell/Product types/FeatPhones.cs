using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public sealed class FeatPhones : Ipho, IallTech,IManuf
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public double price { get; set; }
        public float MainCamera { get; set; }
        public float ScSize { get; set; }
        public int Ram { get; set; }
        public int InternalMem { get; set; }

        private bool avail;

        private List<Supplier> sp = new List<Supplier>();

        private string yornot;


        public FeatPhones(string mark,string model,double price,float mcam,float scsize,int ram,int intmem,string yn)
        {
            this.Mark = mark;
            this.Model = model;
            this.price = price;
            this.MainCamera = mcam;
            this.ScSize = scsize;
            this.Ram = ram;
            this.InternalMem = intmem;
            this.yornot = yn;
            

            Advertise();

        }
        

        public void Advertise()
        {
            if(MainCamera == 0)
            {
                Console.WriteLine("Nice and durable phone for simple communication using buttons");
            }
            else if (MainCamera>0 && MainCamera < 0.3)
            {
                Console.WriteLine($"Nice and durable phone for simple communication using buttons with basic camera of {MainCamera} mpix");
            }
            
            else if (MainCamera >= 0.3f && MainCamera<5f)
            {
                Console.WriteLine($"{Mark} {Model} with Screen Size of {ScSize} inch and Camera {MainCamera} mpix you can enjoy in simplicity and lightness of usability");
                Console.WriteLine("With " +InternalMem + "MB internal memory and " + Ram + " MB ram you will have a good one feature phone");
            }
            else
            {
                Console.WriteLine($"{Mark} {Model} with Screen Size of {ScSize} inch and Camera of {MainCamera} mpix you can enjoy in simplicity,solid photos and lightness of usability");
                Console.WriteLine("With " + InternalMem + "MB internal memory and " + Ram + " MB ram you will have a good one feature phone");
            }
            
        }

        public void Selling(string NameSup, double Purchase)
        {
            Console.WriteLine("");

            if(yornot.ToLower() == "yes")
            {
                avail = true;
            }
            else
            {
                avail = false;
            }
            
            if (!avail)
            {
                Console.WriteLine("Outlet model");
            }
            else
            {
                if (price < Purchase)
                {
                    Console.WriteLine($"Not profitable !!! You will lose {Purchase - price} $ if you are supplied from {Reuse.GiveName(NameSup)} for {Mark} {Model}");
                }
                else
                {
                    Console.WriteLine($"From {Reuse.GiveName(NameSup)} you will earn {price - Purchase} $ for {Mark} {Model}");
                }
            }

            Supplier s = new Supplier(Reuse.GiveName(NameSup), Purchase);
            
            sp.Add(s);

            
        }

        public void Minvalue()
        {
            Console.WriteLine("");
            if (!avail)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("There are no Suppliers");
            }
            else
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Cyan;

                    var sup = sp.OrderBy(x => x.purchprice).First();

                    if (sup.purchprice > price)
                    {
                        Console.WriteLine($"You don't have enought good supplier for {Mark} {Model}");
                    }
                    else
                    {
                        Console.WriteLine($"{sup.name} gives the best offer for {Mark} {Model} in this moment \n");
                    }
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("No suppliers added", ex);
                }
            }

            

            
            
            }
            

            
        }
        

        
        




    }
    

