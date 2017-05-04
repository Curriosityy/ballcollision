using diagram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouBuf
{
    public partial class Form1 : Form
    {
        private ArrayList kulki = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            /*for (int i = 0; i < 2; i++)
            {
                kulki.Add(new Kulka(200, 200, r.Next(20), r.Next(-20, 21), r.Next(-20, 21), Color.Black, Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))));
            }*/
            kulki.Add(new Kulka(100, 100, 20, 3, 3, Color.Beige, Color.Black));
            kulki.Add(new Kulka(300, 300, 20, -3, -3, Color.Purple, Color.Red));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mojPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Diagram d = new Diagram(0,0,mojPanel1.Width,mojPanel1.Height,0,0,20,20,g);
            d.siatka(0, 0, -10, 10, -10, 10, 1, 1, Color.AliceBlue);
            d.uklad_xy(0, 0, -10, 10, -10, 10, 1, 1, 11, Color.Red);
            foreach (Kulka k in kulki)
            {
                k.rysuj(g);
            }
        }

        private void mojPanel1_Resize(object sender, EventArgs e)
        {
            mojPanel1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int size=kulki.Count;

            foreach (Kulka k in kulki)
            {
                foreach (Kulka k2 in kulki)
                {
                    k.colide(k2);
                }
                k.sciana(mojPanel1.Width, mojPanel1.Height);
                k.rusz();
            }
            mojPanel1.Invalidate();
        }
    }
}
