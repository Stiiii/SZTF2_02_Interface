using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal class VeletlenTippelo : GepiJatekos
    {
        public override int KovetkezoTipp()
        {
            return RandomSzam.r.Next(alsoHatar, felsoHatar + 1);
        }
    }
}
