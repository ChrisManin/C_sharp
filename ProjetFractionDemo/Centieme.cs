using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFractionDemo
{
    class Centieme : Fraction
    {
        public new Int32 denominateur { get; }

        public Centieme(int num, int denom) : base(num, denom)
        {
            this.numerateur = num*100/denom;
            base.denominateur = 100;
        }

        public Centieme()
        {
        }

        ~Centieme()
        {
        }

        public new String toText()
        {
            String fraction = " " + numerateur +"\n" + " ---" + "\n" + base.denominateur;
            return fraction;
        }

        public String toString()
        {
            return base.toText(); // Rappelle la méthode toText() de base (donc de la classe parent)
        }
    }
}
