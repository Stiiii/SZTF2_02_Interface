using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzamKitalaloJatek szkj = new SzamKitalaloJatek(50,10);
            VeletlenTippelo vt = new VeletlenTippelo();
            BejaroTippelo bt = new BejaroTippelo();
            LogaritmikusKereso lk = new LogaritmikusKereso();
            SzamKitalaloJatekKaszino szkjk = new SzamKitalaloJatekKaszino(100, 1, 6);
            EmberiJatekos ej = new EmberiJatekos();

            szkj.VersenyzoFelvetele(ej);
            szkjk.VersenyzoFelvetele(vt);
            szkjk.VersenyzoFelvetele(bt);
            szkjk.VersenyzoFelvetele(lk);

            


            szkj.Jatek();
            szkjk.Statisztika(1000);

        }
    }
}
