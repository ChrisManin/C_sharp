using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetFractionDemo
{
    class Fraction
    {
        #region Proprietes
        private Int32 _numerateur;
        public Int32 numerateur //On doit créer l'équivalent en public de la propriété privée. Cette variante publique sert de conteneur pour les getters et setters
        {
            set
            {
                _numerateur = value;

                if (estEntier != null)
                {
                    if (denominateur != 0 && (numerateur % denominateur) == 0)
                    {
                        estEntier(this, new EventArgs());
                    }
                }


            }
            get { return _numerateur; }
        }
        /*Parallèle avec JAVA
         * 
         * private int numerateur;
         * public void setNumerateur(int value) {numerateur = value;}
         * public int getNumerateur() {return numerateur;}
         * 
         * Raccourci pour la saisie :
         * 
         * prop <tab><tab>
         * 
         * Syntaxe simplifiée (avec les accesseurs standards) :
         * 
         * public int denominateur {get; set;}
         * 
         * */
        private Int32 _denominateur;
        public Int32 denominateur
        {
            get
            {
                return _denominateur;
            }

            set
            {
                _denominateur = value;

                if (estEntier != null)
                {
                    if ((numerateur % denominateur) == 0)
                    {
                        estEntier(this, new EventArgs());
                    }
                }
            }
        }

        /*Attention ! utilisation de ces propriétés :
         * 
         * Fraction f = new fraction();
         * f.numerateur = 5;            //Pour activer le setter
         * Int32 n = f.numerateur;      //Pour activer le getter
         * 
         * */

            /// <summary>
            /// Propriété en lecture seule : pas de setter
            /// </summary>
        public Double valeur
        {
            get { return (Double)numerateur / (Double)denominateur; }
        }

        public String nom { get; set; }

        private static Int32 no = 0;

        public event EventHandler estEntier;

        #endregion

        #region Constructeurs et destructeur
        public Fraction(int numerateur, int denominateur)
        {
            this.numerateur = numerateur;
            this.denominateur = denominateur;
            no++;
            nom = "Fraction" + no.ToString();
        }

        public Fraction() : this(0, 0) //Appel de l'autre constructeur
        {
        }

        ~Fraction()     // Ceci est le destructeur
        {
        }
        #endregion

        #region Methodes
        public String toText()
        {
            String fraction = numerateur + "/" + denominateur;
            return fraction;
        }

        public void inverser()
        {
            Int32 conv;
            conv = numerateur;
            numerateur = denominateur;
            denominateur = conv;
            String fractionInv = numerateur + "/" + denominateur;
        }

        public void simplifier()
        {
            Int32 p = pgcd();
            numerateur = numerateur / p;
            denominateur = denominateur / p;
        }

        public Int32 pgcd()
        {
            Int32 a = numerateur;
            Int32 b = denominateur;
            while (true)
            {
                Int32 r = a % b;
                if (r == 0)
                {
                    break;
                }
                a = b;
                b = r;
            }
            return b;
        }

        public static Fraction parse(String s)
        {
            String[] valeurs = s.Split('/');
            Int32 n = Int32.Parse(valeurs[0]);
            Int32 d = Int32.Parse(valeurs[1]);
            Fraction f = new Fraction(n, d);
            return f;
        }
        #endregion

        #region Surcharge d'Opérateurs
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Int32 sommeNum = (f1.numerateur * f2.denominateur) + (f1.denominateur * f2.numerateur);
            Int32 sommeDenom = f1.denominateur * f2.denominateur;

            Fraction result = new Fraction(sommeNum, sommeDenom);
            result.simplifier();
            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Int32 sommeNum = (f1.numerateur * f2.denominateur) - (f1.denominateur * f2.numerateur);
            Int32 sommeDenom = f1.denominateur * f2.denominateur;

            Fraction result = new Fraction(sommeNum, sommeDenom);
            result.simplifier();
            return result;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Int32 sommeNum = f1.numerateur * f2.numerateur;
            Int32 sommeDenom = f1.denominateur * f2.denominateur;

            Fraction result = new Fraction(sommeNum, sommeDenom);
            result.simplifier();
            return result;
        }

        public static Fraction operator *(Fraction f1, Int32 n)
        {
            Int32 sommeNum = f1.numerateur * n;

            Fraction result = new Fraction(sommeNum, f1.denominateur);
            result.simplifier();
            return result;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Int32 sommeNum = f1.numerateur * f2.denominateur;
            Int32 sommeDenom = f1.denominateur * f2.numerateur;

            Fraction result = new Fraction(sommeNum, sommeDenom);
            result.simplifier();
            return result;
        }

        public static Fraction operator /(Fraction f1, Int32 n)
        {
            Int32 sommeDenom = f1.denominateur * n;

            Fraction result = new Fraction(f1.numerateur, sommeDenom);
            result.simplifier();
            return result;
        }

        // Un objet ne se duplique pas. Il faut donc créer de nouveaux objets pour ne pas modifier ceux de départ.
        public static Boolean operator ==(Fraction f1, Fraction f2)
        {
            Fraction f1bis = new Fraction(f1.numerateur, f1.denominateur);
            Fraction f2bis = new Fraction(f2.numerateur, f2.denominateur);
            f1bis.simplifier();
            f2bis.simplifier();
            return (f1bis.numerateur == f2bis.numerateur && f1bis.denominateur == f2bis.denominateur);
        }

        public static Boolean operator !=(Fraction f1, Fraction f2)
        {
            Fraction f1bis = new Fraction(f1.numerateur, f1.denominateur);
            Fraction f2bis = new Fraction(f2.numerateur, f2.denominateur);
            f1bis.simplifier();
            f2bis.simplifier();
            return (f1bis.numerateur != f2bis.numerateur || f1bis.denominateur != f2bis.denominateur);
        }
        #endregion
    }

}

