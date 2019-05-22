using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace api
{
 
    
    public class Pytanie
    {
       
      
        public string Numer_Pytania { get; set; }

        //POLSKI
       
        public string TrescPL { get; set; }
        
        public string OdpApl { get; set; }
       
        public string OdpBpl { get; set; }
       
        public string OdpCpl { get; set; }

        public string Media { get; set; }

        public string LiczbaPunktow { get; set; }

        public string PoprawnaOdp { get; set; }



    }
    class PasekLadowania
    {
        int stan=0;
        int max;
        int prog;
        int dlugosc;
        int przekroczone = 0;

        public PasekLadowania(int max,int dlugosc)
        {
            this.dlugosc = dlugosc;
            this.max = max;
            prog = max / dlugosc;
        }

        public void Wyswietl()
        {
            Aktualizuj();
            string pasek = "[";
            for(int a=0;a<dlugosc;a++)
            {
                if (a < przekroczone) pasek += "#";
                else pasek += " ";
            }
            pasek += "]";

            string liczby="";
            int b;
            if (((dlugosc / 2) - 6) >= 0)
                b = (dlugosc / 2) - 6;
            else
                b = 0;
            for (int a=0;a<b;a++)
            {
                liczby += " ";
            }
            liczby = stan.ToString() + "/" + max.ToString();

            Console.WriteLine(pasek);
            Console.WriteLine(liczby);
            
            
        }
        public void Aktualizuj()
        {
            stan++;
            if(stan>=prog)
            {
                przekroczone++;
                stan = 0;
            }

        }
    }

    

}
