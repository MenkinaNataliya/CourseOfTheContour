using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle1
{
    public class Triangle
    {

        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double angleA { get; set; }
        public double angleB { get; set; }
        public double angleC { get; set; }

        public Triangle(double a, double b=0, double c=0, double angleA=0, double angleB=0, double angleC=0) {

            if (a <= 0 || b < 0 || c < 0 || angleA < 0 || angleB < 0 || angleC < 0  ) goto DoesNot;
            else {
                this.a = a;
                if (b == 0 && c == 0 && angleA == 0)
                {//признак по 2 углам и стороне между ними
                    this.angleB = angleB;
                    this.angleC = angleC;
                    this.angleA = 180 - this.angleB - this.angleC;
                    this.b = SineTheorem(this.a, this.angleB, this.angleA);
                    this.c = SineTheorem(this.a, this.angleC, this.angleA);
                }
                else
                {
                    this.b = b;
                    if (c == 0 && angleA == 0 && angleB == 0)//признак по 2 сторонам и углу
                    {
                        this.angleC = angleC;
                        this.c = Math.Sqrt(b * b + a * a - 2 * b * a * Math.Cos(angleC * Math.PI / 180));
                        this.angleA = CosineTheorem(this.b, this.c, this.a) ;
                        this.angleB = 180 - this.angleA - this.angleC;
                    }
                    else
                       if (angleA == 0 && angleB == 0 && angleC == 0)//признак по 3 сторонам
                        {
                            if (Math.Abs(a) > Math.Abs(b - c) && a < b + c &&
                                Math.Abs(b) > Math.Abs(a - c) && b < a + c &&
                                Math.Abs(c) > Math.Abs(b - a) && c < b + a)
                            {
                                this.c = c;
                                this.angleA = CosineTheorem(this.b, this.c, this.a);
                                this.angleB = CosineTheorem(this.a, this.c, this.b);
                                this.angleC = 180 - this.angleB - this.angleA;
                            }
                            else goto DoesNot;

                        }
                }
                return;      
            }

            DoesNot:
            this.a = 0;
            this.b = 0;
            this.c = 0;
            this.angleA = 0;
            this.angleB = 0;
            this.angleB = 0;
        }

        static void Main(string[] args)
        {}

        public double Heron()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public double CosineTheorem(double a, double b, double c) {
            return Math.Acos((a * a + b * b - c *c) / (2 * a * b)) * 180 / Math.PI ;
        }

        public double SineTheorem(double a, double angleA, double angleC)
        {
            return a * (Math.Sin(angleA * Math.PI / 180) / Math.Sin(angleC * Math.PI / 180));
        }
    }
}
