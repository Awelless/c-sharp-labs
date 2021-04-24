using System;
using System.Collections.Generic;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = Fraction.Of(2, 5);
            Fraction fraction2 = Fraction.Parse("9/6", FractionFormat.Standart);
            Fraction fraction3 = Fraction.Parse("-2(4/10)", FractionFormat.Mixed);
            Fraction fraction4 = Fraction.Parse("-7", FractionFormat.IntegerValue);
            Fraction fraction5 = Fraction.Parse("6.25", FractionFormat.DoubleValue);

            List<Fraction> fractions = new List<Fraction>();
            fractions.Add(fraction1);
            fractions.Add(fraction2);
            fractions.Add(fraction3);
            fractions.Add(fraction4);
            fractions.Add(fraction5);
            
            Console.WriteLine("Fractions:");
            foreach (Fraction fraction in fractions)
            {
                Console.WriteLine(fraction.ToString());
            }
            
            Console.WriteLine("Different formats:");
            Console.WriteLine("{0:S}", fraction3);
            Console.WriteLine("{0:M}", fraction3);
            Console.WriteLine("{0:I}", fraction3);
            Console.WriteLine("{0:D}", fraction3);
            
            Console.WriteLine("Comparation and sum:");
            Console.WriteLine(fraction1.CompareTo(fraction2));
            Console.WriteLine((fraction1 + fraction2).ToString());
        }
    }
}