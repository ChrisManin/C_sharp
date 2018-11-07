using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetFractionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void test (Object sender, EventArgs e)
        {
            MessageBox.Show("La fraction est un entier");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Fraction f1 = new Fraction();
            Fraction f2 = new Fraction();
            
            f1.estEntier += test;
            f2.estEntier += test;
            f1.numerateur = 7;
            f1.denominateur = 18;
            f2.numerateur = 10;
            f2.denominateur = 5;


            if(f1 == f2)
            {
                MessageBox.Show(f1.toText() + "est égal à" + f2.toText());
            }
            else
            {
                MessageBox.Show(f1.toText() + " est différent de " + f2.toText());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fraction f = new Fraction();
            f.denominateur = 27;
            f.numerateur = 9;
            f.inverser();
            MessageBox.Show(f.toText());
            f.simplifier();
            MessageBox.Show(f.toText());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Centieme cent = new Centieme(1, 2);
            MessageBox.Show(cent.toText());
            MessageBox.Show(cent.toString());
        }
    }
}
