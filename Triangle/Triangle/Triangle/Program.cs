using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangles
    {
        double a { get; set; }
        double b { get; set; }
        double c { get; set; }

        public  Triangles(double a, double b, double c) {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Triangles(double a, int angle1, int angle2)
        {

            
            double ang1 = angle1 * Math.PI/ 180;
            double ang2 = angle2 * Math.PI / 180;
            double ang3 = (180 - angle1 - angle2) * Math.PI / 180;
            this.a = a;
            this.b = a * (Math.Sin(ang1) / Math.Sin(ang3));
            this.c = a * (Math.Sin(ang2 ) / Math.Sin(ang3));

        }

        public Triangles(double a, double b, int angle)
        {
            this.a = a;
            this.b = b;
            var t = Math.Cos(angle*180/Math.PI);
           
            this.c = Math.Sqrt(b * b + a *a  - 2 * b *a * Math.Cos(angle * Math.PI / 180));
        }

        public double Heron()
        {
            if (Math.Abs(a) > Math.Abs(b - c) && a < b + c &&
                Math.Abs(b) > Math.Abs(a - c) && b < a + c &&
                Math.Abs(c) > Math.Abs(b - a) && c < b + a)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else return 0;
            
        }
        static void Main(string[] args)
        {
        }
    }
}