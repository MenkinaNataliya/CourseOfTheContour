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

        private Triangle(double a, double b , double c, double angleA , double angleB , double angleC)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;
            this.AngleA = angleA;
            this.AngleB = angleB;
            this.AngleC = angleC;
        }

        public static Triangle ThreeSides(double a, double b, double c)
        {

            if ((a > 0 || b > 0 || c > 0)&&
                Math.Abs(a) > Math.Abs(b - c) && a < b + c &&
                Math.Abs(b) > Math.Abs(a - c) && b < a + c &&
                Math.Abs(c) > Math.Abs(b - a) && c < b + a
                )
            {

                var angleA = CalculationForTheCosineOfTheAngle(b, c, a);
                var angleB = CalculationForTheCosineOfTheAngle(a, c, b);
                var angleC = 180 - angleB - angleA;
                return new Triangle(a, b, c, angleA, angleB, angleC);
            }
            else
            {
                throw new ArgumentException("Triangle does not exist", "side");
            }

        }

        public static Triangle TwoSidesAndAngle(double a, double b, double angleC)
        {
            if (a <= 0 ||b <= 0 || angleC <= 0) throw new ArgumentException("Triangle does not exist", "side or angle");
            else
            {
                var c = Math.Sqrt(b * b + a * a - 2 * b * a * Math.Cos(angleC * Math.PI / 180));
                var angleA = CalculationForTheCosineOfTheAngle(b, c, a);
                var angleB = 180 - angleA - angleC;
                return new Triangle(a, b, c, angleA, angleB, angleC);
            }
        }

        public static Triangle SideAndTwoAngles(double a, double angleB, double angleC)
        {
            if(a<=0 || angleB<=0 || angleC<=0) throw new ArgumentException("Triangle does not exist", "side or angle");
            else
            {
                var angleA = 180 - angleB - angleC;
                var b = CalculationOnThePartOfTheLawOfSines(a, angleB, angleA);
                var c = CalculationOnThePartOfTheLawOfSines(a, angleC, angleA);
                return new Triangle(a, b, c, angleA, angleB, angleC);
            }
            
        }

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

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
