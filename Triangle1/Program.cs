using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle1
{
    public class Triangle
    {

        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public double SideC { get; private set; }

        public double AngleA { get; private set; }

        public double AngleB { get; private set; }

        public double AngleC { get; private set; }

        private Triangle() {
        }

        public Triangle(double a, double b = 0, double c = 0, double angleA = 0, double angleB = 0, double angleC = 0)
        {
            if (a <= 0 || b < 0 || c < 0 || angleA < 0 || angleB < 0 || angleC < 0)
            {
                throw new ArgumentException("One of the parameters negative", "Sides or angles");
                //this.TriangleReset();
            }
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
                this.SideA = a;
                this.SideB = b;
                this.SideC = c;
                this.AngleA = CalculationForTheCosineOfTheAngle(this.SideB, this.SideC, this.SideA);
                this.AngleB = CalculationForTheCosineOfTheAngle(this.SideA, this.SideC, this.SideB);
                this.AngleC = 180 - this.AngleB - this.AngleA;

            }
            else
            {
                throw new ArgumentException("Triangle does not exist", "side");
               // this.TriangleReset();
            }

        }

        private void TwoSidesAndAngle(double a, double b, double angleC)
        {
            this.SideA = a;
            this.SideB = b;
            this.AngleC = angleC;
            this.SideC = Math.Sqrt(b * b + a * a - 2 * b * a * Math.Cos(angleC * Math.PI / 180));
            this.AngleA = CalculationForTheCosineOfTheAngle(this.SideB, this.SideC, this.SideA);
            this.AngleB = 180 - this.AngleA - AngleC;
           
        }

        private void SideAndTwoAngles(double a, double angleB, double angleC)
        {
            this.SideA = a;
            this.AngleB = angleB;
            this.AngleC = angleC;
            this.AngleA = 180 - this.AngleB - this.AngleC;
            this.SideB = CalculationOnThePartOfTheLawOfSines(this.SideA, this.AngleB, this.AngleA);
            this.SideC = CalculationOnThePartOfTheLawOfSines(this.SideA, this.AngleC, this.AngleA);
        }



        //private void TriangleReset()
        //{
        //    this.SideA = 0;
        //    this.SideB = 0;
        //    this.SideC = 0;
        //    this.AngleA = 0;
        //    this.AngleB = 0;
        //    this.AngleB = 0;
        //}

       
        public double CalculationAreaByHeron()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        private static double CalculationForTheCosineOfTheAngle(double a, double b, double c) {
            return Math.Acos((a * a + b * b - c *c) / (2 * a * b)) * 180 / Math.PI ;
        }

        private static double CalculationOnThePartOfTheLawOfSines(double a, double angleA, double angleC)
        {
            return a * (Math.Sin(angleA * Math.PI / 180) / Math.Sin(angleC * Math.PI / 180));
        }

        static void Main(string[] args)
        { }

    }
}
