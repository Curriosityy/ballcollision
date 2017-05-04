using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace skala
{
    class Skala
    {
       private double A, B, C, D;			//skaling z real na ekr
       // Konstruktor skalowania powierzchniowego.
       // (xe0, ye0) - lewy górny róg obszaru ekranowego,
       // eszer, ewys - szerokość i wysokość obszaru ekranowego
       // (xr0, yr0) - środek obszaru rzeczywistego,
       // rszer, rwys - szerokość i wysokość obszaru rzeczywistego
       public Skala(int xe0, int ye0, int eszer, int ewys, double xr0, double yr0, double rszer, double rwys)
       {
            A = (double) eszer / rszer;	//z przestrzeni na ekran
            B = (double) xe0 - A * (xr0 - rszer / 2.0);
            C = -(double)ewys  / rwys;
            D = (double) ye0 - C * (yr0 + rwys / 2.0);
       }
       // Wyliczenie współrzędnej ekranowej xe punktu,
       // gdy znana jest jego współrzędna rzeczywista x.
       public int daj_ekr_x( double x)
       {
           return (int)(A * x + B);
       }
       // Wyliczenie współrzędnej ekranowej ye punktu,
       // gdy znana jest jego współrzędna rzeczywista y.
       public int daj_ekr_y(double y)
       {
           return (int)(C * y + D);
       }
    }
}
