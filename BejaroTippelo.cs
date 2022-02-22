using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal class BejaroTippelo : GepiJatekos
    {
        protected int aktualis;

        public override void JatekIndul(int alsoHatar, int felsoHatar)
        {
            base.JatekIndul(alsoHatar,felsoHatar);
            aktualis = alsoHatar;
        }

        public override int KovetkezoTipp()
        {
            return aktualis++;
        }
    }
}
