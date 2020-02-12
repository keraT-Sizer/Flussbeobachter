using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flußbeobachter
{
    class Fluß
    {
        public string Name { get; set; } 
        public int Wasserstand { get; set; }
        public Stadt StadtBeobachter_1 = new Stadt();
        public Stadt StadtBeobachter_2 = new Stadt();
        public Schiffe SchiffeBeobachter_1 = new Schiffe();
        public Schiffe SchiffeBeobachter_2 = new Schiffe();
        public Klärwerke KlärwerkeBeobachter = new Klärwerke {  Name="Strauß 1"};

        public event EventHandler<EventArgs> AnhaltEvent;
        public event EventHandler<EventArgs> WasserschutzEvent;
        public event EventHandler<EventArgs> EinleitungStopEvent;
        public event EventHandler<EventArgs> EinleitungSteigEvent;
        private Random zfg = new Random();

        public void WasserFluß(int j)
        {
            for (int i = 0; i < j; i++)
            {

                this.Wasserstand = zfg.Next(100, 10001);
                //Wasserstand = 9300; 
                Console.WriteLine();
                Console.WriteLine("Die Aktuelle Wasserzustand ist: {0}  ", Wasserstand); Console.WriteLine();
                Thread.Sleep(2000);

                if (Wasserstand > 3000 &&  Wasserstand < 8000)
                {
                    Console.WriteLine("Alles ist normal kein Sorge....");
                }

                if (Wasserstand >= 8000)
                {
                    Console.WriteLine("Es ist gefährlich !! - Diese Vorsorge sind genommen: ");
                    Console.WriteLine("==============================");
                    AnhaltEvent(this, new EventArgs());
                    EinleitungStopEvent(this, new EventArgs());
                    
                    if (Wasserstand >= 8200)
                        
                        WasserschutzEvent(this, new EventArgs());
                    Console.WriteLine("==============================");
                }
                if (Wasserstand <= 3000)
                {
                     Console.WriteLine("Es ist gefährlich !! - Diese Vorsorge sind genommen: ");
                    Console.WriteLine("==============================");
                    EinleitungSteigEvent(this, new EventArgs());

                    if (Wasserstand <= 250)
                        AnhaltEvent(this, new EventArgs());
                    Console.WriteLine("==============================");
                }
                
            }
                 
        }
        
    }
    class Schiffe 
    {
        public string Name { get; set; }
        public void Anhalten(object o, EventArgs e)
        {
            if (o != null)
                Console.WriteLine ("{0} sind eingehalten...",Name);
        }
    }
    class Stadt 
    {
        public string Name { get; set; }
        public void Wasserschutzwand(object o, EventArgs e)
        {
            if (o!=null)
                Console.WriteLine("{0} Wasserschutzwand An..", Name);
        }
    } 
    class Klärwerke 
    {
        public string Name { get; set; }
        public void Einleintung1(object o, EventArgs e)
        {
            if (o != null)
                Console.WriteLine("{0} Einleitung gestoppt..", Name);
        }
        public void Einleintung2(object o, EventArgs e)
        {
            if (o != null)
                Console.WriteLine("{0} Einleitung steigt..", Name);
        }
    }
}
