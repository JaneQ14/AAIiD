using System;
using System.Collections.Generic;

namespace AAIiD
{
    internal class CW_11
    {
        internal static void Start()
        {
            var p1 = (x: 1.0, y: 1.0);
            var p2 = (x: 5.0, y: 5.0);

            Console.WriteLine("A) Punkt środkowy:");
            var srodek = PunktSrodkowy(p1, p2);
            Console.WriteLine($"Punkt środkowy wektora: ({srodek.x}, {srodek.y})");

            Console.WriteLine("\nB) Kąt nachylenia:");
            double kat = KatNachylenia(p1, p2);
            Console.WriteLine($"Kąt nachylenia wektora: {kat} stopni");

            Console.WriteLine("\nC) Minimalna liczba linii przechodzących przez punkty względem (0,0):");
            var punkty = new List<(int x, int y)>
            {
                (0, 0), (2, 2), (4, 4), (1, 2)
            };
            int ileLinii = MinimalneLiczbyLinii(punkty);
            Console.WriteLine($"Liczba różnych linii: {ileLinii}");

            Console.WriteLine("\nD) Pole trójkąta:");
            var a = (0.0, 0.0);
            var b = (4.0, 0.0);
            var c = (2.0, 3.0);
            double pole = PoleTrojkata(a, b, c);
            Console.WriteLine($"Pole trójkąta: {pole}");

            Console.WriteLine("\nE) Relacja linii z okręgiem:");
            var srodekOkregu = (x: 3.0, y: 2.0);
            double r = 2.0;
            string relacja = RelacjaLiniaOkrag(p1, p2, srodekOkregu, r);
            Console.WriteLine($"Relacja: linia {relacja} okrąg");
        }

        static (double x, double y) PunktSrodkowy((double x, double y) p1, (double x, double y) p2)
        {
            return ((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
        }

        static double KatNachylenia((double x, double y) p1, (double x, double y) p2)
        {
            return Math.Atan2(p2.y - p1.y, p2.x - p1.x) * (180 / Math.PI);
        }

        static int MinimalneLiczbyLinii(List<(int x, int y)> punkty)
        {
            var slopes = new HashSet<string>();
            var (x0, y0) = punkty[0];

            for (int i = 1; i < punkty.Count; i++)
            {
                int dx = punkty[i].x - x0;
                int dy = punkty[i].y - y0;

                string nachylenie = dx == 0 ? "inf" : (dy / (double)dx).ToString("F6");
                slopes.Add(nachylenie);
            }

            return slopes.Count;
        }

        static double PoleTrojkata((double x, double y) a, (double x, double y) b, (double x, double y) c)
        {
            return Math.Abs(a.x * (b.y - c.y) + b.x * (c.y - a.y) + c.x * (a.y - b.y)) / 2;
        }

        static string RelacjaLiniaOkrag(
            (double x, double y) p1,
            (double x, double y) p2,
            (double x, double y) srodek,
            double r)
        {
            double A = p2.y - p1.y;
            double B = p1.x - p2.x;
            double C = p2.x * p1.y - p1.x * p2.y;

            double odleglosc = Math.Abs(A * srodek.x + B * srodek.y + C) / Math.Sqrt(A * A + B * B);

            if (odleglosc < r)
                return "przechodzi przez";
            else if (Math.Abs(odleglosc - r) < 1e-6)
                return "styka się z";
            else
                return "nie przecina";
        }
    }
}
