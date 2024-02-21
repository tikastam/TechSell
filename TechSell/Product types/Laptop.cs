using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechSell
{
    public class Laptop : IallTech, IComputer,IManuf
    {
        public string Mark { get; set; } 
        public string Model { get; set; } 
        public double price { get; set; }
        public string proc { get; set; } 
        public int ram { get; set; } 
        public int hdsize { get; set; }
        private string grnoint { get; set; }
        private string sctype { get; set; } 
        private double scsize { get; set; } 
        private int lightness { get; set; } 
        private string graphint { get; set; }
        private double weight { get; set; }

        private bool grtrue = true;

        private static readonly string emp = string.Empty;

        public string graph { 
            get{
                return grnoint;
            
            } 
            set { 
                if(value.ToLower().Contains(MultiEnums.gcardcomplap.nvidia.ToString()) || value.ToLower().Contains(MultiEnums.gcardcomplap.radeon.ToString()))
                {
                    grnoint = value;
                }
                else
                {
                    grnoint = emp;
                }
            }
        }

        public string Graphint
        {
            get { return graphint; }

            set
            {
                if(value.ToLower().Contains(MultiEnums.gcardintegr.intrad.ToString()) || value.ToLower().Contains(MultiEnums.gcardintegr.intel.ToString()))
                {
                    graphint = value;
                }
                else
                {
                    graphint = emp;
                }
            }
        }

        private List<Supplier> su = new List<Supplier>();


        public Laptop(string mark,string model,string processor,string sctype,double scsize,int ram,int hdsize,string graph,string gint,int light,double weight,double price)
        {
            this.Mark = mark;
            this.Model = model;
            this.proc = processor;
            this.sctype = sctype;
            this.scsize = scsize;
            this.ram = ram;
            this.hdsize = hdsize;
            this.graph = graph;
            this.Graphint = gint;
            this.lightness = light;
            this.weight = weight;
            this.price = price;
        }


        

        private void GamingorBusiness()
        {
            if (!Reuse.gameplay(graph, emp) || ram <= 8)
            {
                Console.WriteLine("Suitable for business and daily use for private purpose\n");
            }
            else if (!Reuse.gameplay(graph, emp) || ram < 16 && ram>=8)
            {
                Console.WriteLine("Suitable for business, daily use for private purpose and playing certain games\n");
            }
            else
            {
                Console.WriteLine("Suitable for Gaming as well as any other purpose\n");
            }
        }

        private void ScrandPort()
        {
            string hv = emp;
            if(weight< 1.7)
            {
                hv = "Very easily portable";
            }
            else if(weight>1.7 && weight <= 2.5)
            {
                hv = "Easily potable";
            }
            else
            {
                hv = "Portable";
            }
            Console.WriteLine("Screen: " + sctype + " " + scsize + " inch " + "\nLightness: " + lightness + " nits\n");
            Console.WriteLine($"{hv} with a weight of {weight} kg");
        }

        


        //Main Logic

        public void Description()
        {
            if (!Reuse.gameplay(graph, emp) && !Reuse.gameplay(Graphint, emp))
            {
                grtrue = false;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Laptop without graphic card can't be used check your input!");
            }
            else
            {
                grtrue = true;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(Mark + " " + Model + " " + sctype + scsize);
                sb.AppendLine("Processor - " + proc);
                sb.AppendLine("Memory: Ram - " + ram +"GB HardDisk - " + Reuse.HardSize(hdsize) + " SSD");
                sb.AppendLine("Graphic: "+ graph + " " + Graphint);

                Console.Write(sb.ToString());
                ScrandPort();

                GamingorBusiness();
            }
        }

        public void Selling(string NameSup, double Purchase)
        {
            double total = Purchase + Purchase / 20;

            var s = new Supplier(Reuse.GiveName(NameSup), total);

            double ear = total + total / 5;

            if (price > ear)
            {
                su.Add(s);
            }

        }
        public void FBest()
        {
            if (grtrue)
            {
                try
                {
                    var best = su.OrderBy(d => d.purchprice).First();

                    Console.WriteLine($"\nThe supplier that has the best offer is {Reuse.GiveName(best.name)} ");
                    Console.WriteLine($"Shipping together with product costs {best.purchprice}$ and you can earn {price - best.purchprice}$ for one laptop");
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("\nAt this moment no profitable suppliers have been found ,the selling price is too low or no added suppliers check input", ex);
                }
                if (su.Count > 1)
                {
                    ChkAll();
                }
            }
            else
            {
                Console.WriteLine(string.Empty);
            }
            

        }

        private void ChkAll()
        {
            string ans = emp;
            Console.WriteLine("\nDo you want to check out all the good deals from suppliers? Press Y for Yes or N for No");

            do
            {
                ans = Console.ReadLine();
                if(ans.ToUpper() != "Y" && ans.ToUpper() != "N")
                {
                    Console.WriteLine("Not valid input press Y for Yes or N for No");
                }
            } 
            while (ans.ToUpper() != "Y" && ans.ToUpper() != "N");

            

            if(ans.ToUpper() == "Y")
            {
                for(int i = 0; i < su.Count; i++)
                {
                    Console.WriteLine($"\n{su[i].name} - costs with shipping are {su[i].purchprice} you will earn {price - su[i].purchprice}");
                }
            }
            else if(ans.ToUpper() == "N")
            {
                Console.WriteLine("\nOK. Just check are your prices correct");
            }
                    


        }

        
    }
            
}








    

