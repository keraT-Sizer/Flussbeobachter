using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flußbeobachter
{
    class Program
    {
        static void Main(string[] args)
        {
            Fluß Rhein = new Fluß() { Name= "Rhein", StadtBeobachter_1 ={ Name = "Düsseldorf" }, StadtBeobachter_2 =  { Name = "Köln" },
            SchiffeBeobachter_1= { Name="Rheingold"},SchiffeBeobachter_2= { Name="Lorelei"}};

            Fluß Donau = new Fluß() { Name= "Donau", StadtBeobachter_1= {  Name="Ulm"}, 
                SchiffeBeobachter_2 =  { Name = "Franz" }, SchiffeBeobachter_1 = {  Name="Xaver"} };

            string e = "j";
            
            do
            {
                Console.Write("Welsche Fluß wollen sie beobachten Rhein='r' oder Donau='d': "); e = Console.ReadLine();
                
                switch (e)
                {
                    case "r":
                        Console.Write("wie Viel Beobachten wollen sie machen: "); int anzahl = Convert.ToInt16(Console.ReadLine());
                        Eventfunction(Rhein,anzahl);
                        break;

                    case "d":
                        Console.Write("wie Viel Beobachten wollen sie machen: "); int anzahl2 = Convert.ToInt16(Console.ReadLine());
                        Eventfunction(Donau,anzahl2);
                        break;

                    default:
                        Console.WriteLine("Falsch angabe.");
                        break;
                }
                Console.Write("Wollen sie noch mal Beobachten: "); e = Console.ReadLine();
            } while (e=="j" );
            
            void Eventfunction(Fluß F,int anzahl)
            {
                F.AnhaltEvent += F.SchiffeBeobachter_1.Anhalten;
                F.AnhaltEvent += F.SchiffeBeobachter_2.Anhalten;
                F.WasserschutzEvent += F.StadtBeobachter_1.Wasserschutzwand;
                F.EinleitungStopEvent += F.KlärwerkeBeobachter.Einleintung1;
                F.EinleitungSteigEvent += F.KlärwerkeBeobachter.Einleintung2;
                if (F==Rhein)
                    F.WasserschutzEvent += F.StadtBeobachter_2.Wasserschutzwand;
               

                F.WasserFluß(anzahl);
                
            }
           

            
        }
    }
    
}
