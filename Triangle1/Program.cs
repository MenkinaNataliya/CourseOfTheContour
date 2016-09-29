using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle1
{
    public class Triangle
    {

        private double a { get; set; }
        
        private double b { get; set; }
        
        private double c { get; set; }
       
        private double angleA { get; set; }
       
        private double angleB { get; set; }
        
        private double angleC { get; set; }

        public double getA() { return this.a; }
        public double getB() { return this.b; }
        public double getC() { return this.c; }
        public double getAngleA() { return this.angleA; }
        public double getAngleB() { return this.angleB; }
        public double getAngleC(){ return this.angleC;}
          
        private Triangle() {
        }

        public Triangle(double a, double b = 0, double c = 0, double angleA = 0, double angleB = 0, double angleC = 0)
        { 
            if (a <= 0 || b < 0 || c < 0 || angleA < 0 || angleB < 0 || angleC < 0) this.TriangleReset();
            else
            {
                
                if (b == 0 && c == 0 && angleA == 0)
                {//признак по 2 углам и стороне между ними
                    this.SideAndTwoAngles(a, angleB, angleC);
                }
                else
                {
                   
                    if (c == 0 && angleA == 0 && angleB == 0)//признак по 2 сторонам и углу
                    {
                        this.TwoSidesAndAngle(a, b, angleC);
                    }
                    else
                       if (angleA == 0 && angleB == 0 && angleC == 0)//признак по 3 сторонам
                    {
                        this.ThreeSides(a, b, c);
                    }
                }

            }
        }

        private void ThreeSides(double a, double b, double c)
        {
          
            if (Math.Abs(a) > Math.Abs(b - c) && a < b + c &&
                                Math.Abs(b) > Math.Abs(a - c) && b < a + c &&
                                Math.Abs(c) > Math.Abs(b - a) && c < b + a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.angleA = CalculationForTheCosineOfTheAngle(this.b, this.c, this.a);
                this.angleB = CalculationForTheCosineOfTheAngle(this.a, this.c, this.b);
                this.angleC = 180 - this.angleB - this.angleA;

            }
            else this.TriangleReset();
          
        }

        private void TwoSidesAndAngle(double a, double b, double angleC)
        {
            this.a = a;
            this.b = b;
            this.angleC = angleC;
            this.c = Math.Sqrt(b * b + a * a - 2 * b * a * Math.Cos(angleC * Math.PI / 180));
            this.angleA = CalculationForTheCosineOfTheAngle(this.b, this.c, this.a);
            this.angleB = 180 - this.angleA - angleC;
           
        }

        private void SideAndTwoAngles(double a, double angleB, double angleC)
        {
            this.a = a;
            this.angleB = angleB;
            this.angleC = angleC;
            this.angleA = 180 - this.angleB - this.angleC;
            this.b = PaymentOnThePartOfTheLawOfSines(this.a, this.angleB, this.angleA);
            this.c = PaymentOnThePartOfTheLawOfSines(this.a, this.angleC, this.angleA);
        }



        private void TriangleReset()
        {
            this.a = 0;
            this.b = 0;
            this.c = 0;
            this.angleA = 0;
            this.angleB = 0;
            this.angleB = 0;
        }

       
        public double PaymentAreaByHeron()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private static double CalculationForTheCosineOfTheAngle(double a, double b, double c) {
            return Math.Acos((a * a + b * b - c *c) / (2 * a * b)) * 180 / Math.PI ;
        }

        private static double PaymentOnThePartOfTheLawOfSines(double a, double angleA, double angleC)
        {
            return a * (Math.Sin(angleA * Math.PI / 180) / Math.Sin(angleC * Math.PI / 180));
        }

        static void Main(string[] args)
        { }

    }
}
