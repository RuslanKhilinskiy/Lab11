using System;

namespace DistanceCount
{
    public class Distance
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        public Distance()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public Distance(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public static Distance operator +(Distance a, Distance b)
        {
            int totalInches = a.Feet * 12 + (int)a.Inches + b.Feet * 12 + (int)b.Inches;
            return new Distance(totalInches / 12, totalInches % 12);
        }

        public static Distance operator -(Distance a, Distance b)
        {
            int totalInches = a.Feet * 12 + (int)a.Inches - (b.Feet * 12 + (int)b.Inches);
            return new Distance(totalInches / 12, totalInches % 12);
        }

        public override string ToString()
        {
            return $"{Feet}'-{Inches}\"";
        }

        public static bool operator ==(Distance a, Distance b)
        {
            return a.Feet == b.Feet && a.Inches == b.Inches;
        }

        public static bool operator !=(Distance a, Distance b)
        {
            return !(a == b);
        }

        public static bool operator >(Distance a, Distance b)
        {
            int totalInchesA = a.Feet * 12 + (int)a.Inches;
            int totalInchesB = b.Feet * 12 + (int)b.Inches;
            return totalInchesA > totalInchesB;
        }

        public static bool operator <(Distance a, Distance b)
        {
            int totalInchesA = a.Feet * 12 + (int)a.Inches;
            int totalInchesB = b.Feet * 12 + (int)b.Inches;
            return totalInchesA < totalInchesB;
        }

        public static bool operator >=(Distance a, Distance b)
        {
            return a > b || a == b;
        }

        public static bool operator <=(Distance a, Distance b)
        {
            return a < b || a == b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first feet value: ");
            int feet1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the first inches value: ");
            double inches1 = double.Parse(Console.ReadLine());

            Distance distance1 = new Distance(feet1, inches1);

            Console.WriteLine("Please enter the second feet value: ");
            int feet2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second inches value: ");
            double inches2 = double.Parse(Console.ReadLine());

            Distance distance2 = new Distance(feet2, inches2);

            Distance sumDistance = distance1 + distance2;
            Distance diffDistance = distance1 - distance2;

            Console.WriteLine($"Distance sum is: {sumDistance}");
            Console.WriteLine($"Distance difference is: {diffDistance}");

            if (distance1 > distance2)
                Console.WriteLine($"{distance1} is greater than {distance2}");
            else if (distance1 < distance2)
                Console.WriteLine($"{distance1} is less than {distance2}");
            else
                Console.WriteLine($"{distance1} is equal to {distance2}");

            Console.ReadLine();
        }
    }
}
