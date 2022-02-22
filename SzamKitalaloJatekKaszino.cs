using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    class SzamKitalaloJatekKaszino : SzamKitalaloJatek, IStatisztikatSzolgaltat
    {
        int kaszinoNyert, kaszinoVeszitett;
        int korokSzama;

        public SzamKitalaloJatekKaszino(int felsoHatar, int alsoHatar, int korokSzama) : base(felsoHatar, alsoHatar)
        {
            this.korokSzama = korokSzama;
        }

        public int HanyszorNyert
        {
            get
            {
                return kaszinoNyert;
            }
        }

        public int HanyszorVesztett
        {
            get
            {
                return kaszinoVeszitett;
            }
        }

        public override void Jatek()
        {
            VersenyIndul();
            int szamlalo = 0;
            do
            {
                szamlalo++;
            } while (!MindenkiTippel() && korokSzama != szamlalo);
            if (szamlalo == korokSzama)
            {
                kaszinoNyert++;
            }
            else
            {
                kaszinoVeszitett++;
            }
        }

        public override void Statisztika(int korokSzama)
        {
            base.Statisztika(korokSzama);
            Console.WriteLine($"Kaszino, NY: {kaszinoNyert} V:{kaszinoVeszitett}");
        }
    }
}
