using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai_Feladat_Interface
{
    abstract class GepiJatekos : ITippelo, IStatisztikatSzolgaltat
    {

        protected int alsoHatar, felsoHatar;
        protected int nyertDB, veszitettDB;

        public int HanyszorNyert
        {
            get
            {
                return nyertDB;
            }
             
        }

        public int HanyszorVesztett
        {
            get
            {
                return veszitettDB;
            }

        }

        public virtual void JatekIndul(int alsoHatar, int felsoHatar)
        {
            this.alsoHatar = alsoHatar;
            this.felsoHatar = felsoHatar;
        }

        public abstract int KovetkezoTipp();

        public void Nyert()
        {
            nyertDB++;
        }

        public void Veszitett()
        {
            veszitettDB++;
        }
    }
}
