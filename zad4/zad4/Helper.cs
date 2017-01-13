using System;

namespace zad4
{
    public static class Helper
    {
        public static double Hypotenuse(double a, double b)

        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}