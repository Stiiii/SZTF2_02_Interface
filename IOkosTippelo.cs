using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    internal interface IOkosTippelo : ITippelo
    {
        void Kisebb();

        void Nagyobb();
    }
}
