using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal class LogaritmikusKereso : GepiJatekos, IOkosTippelo
    {
        public override int KovetkezoTipp()
        {
            int center = (alsoHatar + felsoHatar) / 2;
            return center;
        }

        public void Kisebb()
        {
            felsoHatar = (KovetkezoTipp())-1;
        }

        public void Nagyobb()
        {
            alsoHatar = (KovetkezoTipp())+1;
        }
    }
}
