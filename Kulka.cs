using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouBuf
{
    class Kulka
    {
        public int x;
        public int y;
        public int r;
        public int vx;
        public int vy;
        private Brush b;
        private Pen p;
        public int masa;
        
        public Kulka(int x0,int y0,int r,int vx,int vy,Color kl,Color kt)
        {
            x = x0;
            y = y0;
            this.r = r;
            this.vx = vx;
            this.vy = vy;
            p = new Pen(kl);
            b = new SolidBrush(kt);
        }
        public void rysuj(Graphics g)
        {
            g.FillEllipse(b, x - r, y - r, r * 2, r * 2);
            g.DrawEllipse(p, x - r, y - r, r * 2, r * 2);
        }
        public void rusz()
        {
            x += vx;
            y += vy;
        }
        public void sciana(int wid,int hei)
        {
            if (x<=r || x > wid-r)
            {
                vx= -vx;
            }
            if (y <= r || y> hei-r)
            {
                vy = -vy;
            }
        }
        public void colide(Kulka k)
        {
            if (Math.Sqrt(Math.Pow(this.x - k.x, 2) + Math.Pow(this.y - k.y, 2)) < this.r + k.r)
            {
                this.vx *= -1; 
                this.vy *= -1;
                k.vx *= -1;
                k.vy *= -1;
            }
        }
    }
}
