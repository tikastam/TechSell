using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSell
{
    public class PC : IallTech, IComputer
    {
        public double price { get; set; }
        public string proc { get; set; }
        public int ram { get; set; }
        public int hdsize { get; set; }
        private double _weight { get; set; }
        protected string Caseormark { get; set; }
        protected string Caseormodel { get; set; }
        private string gcard { get;set; }

        private double total;

        public string graph { 
            get {
                return gcard;
            } 
            set {

             if(value.ToLower().Contains(MultiEnums.gcardcomplap.nvidia.ToString()) || value.ToLower().Contains(MultiEnums.gcardcomplap.radeon.ToString()))
                {
                    gcard = value;
                }
                else
                {
                    gcard = MultiEnums.gcardcomplap.integrated.ToString();
                }
            
            }
        }


        private List<Supplier> sup = new List<Supplier>();

        private double Delivery(double pc,double we)
        {
            double cal = 3 * (pc / 1000) + we * (pc / 250);

            return cal;
            
        }

        public PC(string csmark,string csmodel,int ram,int hdsize,string gcard,string processor,double weight,double price)
        {
            this.Caseormark = csmark;
            this.Caseormodel = csmodel;
            this.ram = ram;
            this.hdsize = hdsize;
            this.graph = gcard;
            this.proc = processor;
            this._weight = weight;
            this.price = price;
            
        }

        private void Specifications()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Case - " + Caseormark + " " + Caseormodel);
            sb.AppendLine("Processor - " + proc);
            sb.AppendLine("Hard Disk Size - " + Reuse.HardSize(hdsize) + " SSD");
            sb.AppendLine("RAM - " + ram + "GB");
            sb.AppendLine("Graphic card - " + graph);

            Console.WriteLine(sb.ToString());
        }






        //Main Logic
        public void Description()
        {
            Specifications();

            if (!Reuse.gameplay(graph, MultiEnums.gcardcomplap.integrated.ToString()) || ram < 16)
            {
                Console.WriteLine("Not suitable for demanding games \n");
            }
            if(hdsize < 128)
            {
                Console.WriteLine("Accompanying programs can also be installed with using Windows 10 \n");
            }
            

        }

        public void Selling(string NameSup, double Purchase)
        {
            total = Purchase + Delivery(Purchase,_weight);

            if(price< total)
            {
                Console.WriteLine($"You will be in red if you order from {Reuse.GiveName(NameSup)} and sell at that price \n");
            }
            else if(price>total && price < total + price / 5)
            {
                Console.WriteLine($"Try to negotiate with {Reuse.GiveName(NameSup)} or raise the selling price");
                Console.WriteLine($"Or you risk {total} $ for the profit of {price - total} $\n");
                
            }
            else
            {
                Console.WriteLine($"If you are purchashing from {Reuse.GiveName(NameSup)} computer you will earn {price - total} $ with {total} costs");
                Console.WriteLine("Not a bad chance if you're put the proper sale price \n");
            }

            var s = new Supplier(Reuse.GiveName(NameSup), Purchase);
            sup.Add(s);
            
        }

        public void Best()
        {
            try
            {
                var best = sup.OrderBy(a => a.purchprice).First();

                if (best.purchprice > price)
                {
                    Console.WriteLine($"No good suppliers for {Caseormark} {Caseormodel} {proc}/{ram}/{hdsize}/{graph} \n");
                }
                else
                {
                    Console.WriteLine($"Best offer for {Caseormark} {Caseormodel} {proc}/{ram}/{hdsize}/{graph} have {best.name} \n");
                }
            }
            catch(SystemException ex)
            {
                Console.WriteLine("\nAt this moment no profitable suppliers,the selling price is too low or no added suppliers", ex);
            }
            


        }

        
    }
}
