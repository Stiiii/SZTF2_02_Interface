using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal class EmberiJatekos : IOkosTippelo
    {
        public void JatekIndul(int alsoHatar, int felsoHatar)
        {
            Console.WriteLine($"*Jatek indul az alábbi határok között: [" + alsoHatar+",3"+felsoHatar+"]");
        }

        public void Kisebb()
        {
            Console.WriteLine("*Az előző tippnél kisebb a keresett szám");
        }

        public int KovetkezoTipp()
        {
            Console.Write("*Add meg a következő tippet: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            int bekertszam = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            return bekertszam;
        }

        public void Nagyobb()
        {
            Console.WriteLine("*Az előző tippnél nagyobb a keresett szám");
        }

        public void Nyert()
        {
            Console.WriteLine("*Nyertél!");
        }

        public void Veszitett()
        {
            Console.WriteLine("*Veszítettél!");
        }
    }
}
