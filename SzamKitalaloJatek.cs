using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Orai_Feladat_Interface
{
    public static class RandomSzam
    {
        public static Random r = new Random();
    }

    class SzamKitalaloJatek : IOkosTippelo
    {
        const int MAX_VERSENYZO = 5;

        ITippelo[] versenyzok = new ITippelo[MAX_VERSENYZO];
        int VersenyzoN = 0;
        int felsoHatar, alsoHatar;
        int cel;

        public SzamKitalaloJatek(int felsoHatar, int alsoHatar)
        {
            this.felsoHatar = felsoHatar;
            this.alsoHatar = alsoHatar;
        }

        public void VersenyzoFelvetele(ITippelo uj)
        {
            versenyzok[VersenyzoN] = uj;
            VersenyzoN++;
        }

        public void VersenyIndul()
        {
            cel = RandomSzam.r.Next(alsoHatar, felsoHatar + 1);

            for (int i = 0; i < VersenyzoN; i++)
            {
                versenyzok[i].JatekIndul(alsoHatar, felsoHatar);
            }
        }

        public bool MindenkiTippel()
        {
            int nyertesek = 0;
            //Console.WriteLine("\n\nMindenki Tippel!\nKitalálandó szám: " + cel);
            bool nyerte = false;
            for (int i = 0; i < VersenyzoN; i++)
            {
                int tipp = versenyzok[i].KovetkezoTipp();
                //Console.WriteLine("   " + versenyzok[i] + "  " + tipp);
                if (tipp == cel)
                {
                    versenyzok[i].Nyert();
                    nyerte = true;
                }
                else
                {
                    if (versenyzok[i] is IOkosTippelo)
                    {
                        if (tipp < cel)
                        {
                            (versenyzok[i] as IOkosTippelo).Nagyobb();
                            Nagyobb();
                        }
                        else
                        {
                            (versenyzok[i] as IOkosTippelo).Kisebb();
                            Kisebb();
                        }
                    }
                }
                if (nyertesek > 0)
                {
                    if (!(versenyzok[i] is EmberiJatekos))
                    {
                        for (int j = 0; j < VersenyzoN; j++)
                        {
                            if (versenyzok[j] is EmberiJatekos)
                            {
                                versenyzok[j].Veszitett();
                            }
                        }
                    }
                    return true;
                }
            }
            return nyerte;
        }

        public virtual void Jatek()
        {
            VersenyIndul();
            do
            {

            } while (MindenkiTippel() != true);
        }

        public void Kisebb()
        {
        }

        public void Nagyobb()
        {
        }

        public void JatekIndul(int alsoHatar, int felsoHatar)
        {
            //throw new NotImplementedException();
        }

        public int KovetkezoTipp()
        {
            throw new NotImplementedException();
        }

        public void Nyert()
        {
        }

        public void Veszitett()
        {
        }

        public virtual void Statisztika(int korokSzama)
        {
            int szamlalo = 0;
            for (int i = 0; i < korokSzama; i++)
            {
                Jatek();
            }
            for (int i = 0; i < VersenyzoN; i++)
            {
                if (versenyzok[i] is IStatisztikatSzolgaltat)
                {
                    szamlalo++;
                    int nyertkorok = (versenyzok[i] as IStatisztikatSzolgaltat).HanyszorNyert;
                    Console.WriteLine(szamlalo + ". jatekos (" + versenyzok[i] + "),   NY: " + nyertkorok + "   V: " + (korokSzama - nyertkorok));
                }
            }
        }
    }
}
