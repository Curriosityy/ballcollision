using System;
using System.Drawing;                       //Graphics, Color
using System.Collections.Generic;
using System.Linq;
using System.Text;
using skala;


namespace diagram
{
    public enum TypPunktu : int { P_Kolo, P_Kwadrat, P_Krzyz };

    class Diagram : Skala
    {

        private Graphics g;
        private double xr0, yr0, rszer, rwys;
        public Diagram(int xe0, int ye0, int eszer, int ewys,
                double Axr0, double Ayr0, double Arszer, double Arwys, Graphics Ag) :base(xe0, ye0, eszer, ewys, Axr0, Ayr0, Arszer, Arwys)
        {
            g = Ag;
            xr0 = Axr0;
            yr0 = Ayr0;
            rszer = Arszer;
            rwys = Arwys;
        }

        public void siatka(double x0, double y0, double x1, double x2,
                double y1, double y2, double dx, double dy, Color k)
        {
            double x, y;
            int xe, ye, xemin, xemax, yemin, yemax;
            Pen pioro = new Pen(k);

            xemin = daj_ekr_x(x1);	//rogi siatki na ekranie
            xemax = daj_ekr_x(x2);
            yemin = daj_ekr_y(y1);
            yemax = daj_ekr_y(y2);

            for (x = x0; x >= x1; x -= dx)
            {
                xe = daj_ekr_x(x);
                g.DrawLine( pioro, xe, yemin, xe, yemax);
            }

            for (x = x0; x <= x2; x += dx)
            {
                xe = daj_ekr_x(x);
                g.DrawLine( pioro, xe, yemin, xe, yemax);
            }

            for (y = y0; y >= y1; y -= dy)
            {
                ye = daj_ekr_y(y);
                g.DrawLine(pioro, xemin, ye, xemax, ye);
            }

            for (y = y0; y <= y2; y += dy)
            {
                ye = daj_ekr_y(y);
                g.DrawLine( pioro, xemin, ye, xemax, ye);
            }
        }

        public void uklad_xy(double x0, double y0, double x1, double x2,
                double y1, double y2, double dx, double dy,
                int delta, Color k)
        {
            double x, y;
            int xe0, ye0, xe, ye, xemin, xemax, yemin, yemax;
            int d = delta / 2;

            Pen pioro = new Pen(k);

            xe0 = daj_ekr_x(x0);
            ye0 = daj_ekr_y(y0);

            xemin = daj_ekr_x(x1);
            xemax = daj_ekr_x(x2);
            yemin = daj_ekr_y(y1);
            yemax = daj_ekr_y(y2);

            g.DrawLine( pioro, xemin, ye0, xemax, ye0);
            for (x = x0; x >= x1; x -= dx)
            {
                xe = daj_ekr_x(x);
                g.DrawLine(pioro, xe, ye0 - d, xe, ye0 + d);
            }

            for (x = x0; x <= x2; x += dx)
            {
                xe = daj_ekr_x(x);
                g.DrawLine(pioro, xe, ye0 - d, xe, ye0 + d);
            }

            g.DrawLine(pioro, xe0, yemin, xe0, yemax);
            for (y = y0; y >= y1; y -= dy)
            {
                ye = daj_ekr_y(y);
                g.DrawLine(pioro, xe0 - d, ye, xe0 + d, ye);
            }

            for (y = y0; y <= y2; y += dy)
            {
                ye = daj_ekr_y(y);
                g.DrawLine(pioro, xe0 - d, ye, xe0 + d, ye);
            }
        }

        public void napis(double x, double y, string tekst, int gdziex, int gdziey)
        {
        }

        public void punkt(double x, double y, int delta, TypPunktu t, Color k)
        {
            int xe = daj_ekr_x(x), ye = daj_ekr_y(y);
            int d = delta / 2;
            Brush farba = new SolidBrush(k);
            Pen pioro = new Pen(k);

            switch (t)
            {
                case TypPunktu.P_Kolo:
                    g.FillEllipse(farba, xe - d, ye - d, 2*d, 2*d);
                    break;
                case TypPunktu.P_Kwadrat:
                    g.FillRectangle(farba, xe - d, ye - d, 2*d, 2*d);
                    break;
                case TypPunktu.P_Krzyz:
                    g.DrawLine(pioro, xe - d, ye, xe + d, ye);
                    g.DrawLine(pioro, xe, ye - d, xe, ye + d);
                    break;
            }
        }

    }
}
