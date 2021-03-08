using System;
using System.Globalization;

namespace Months.data
{
    public class DataWriter
    {
        public static void PrintMonths(CultureInfo cultureInfo)
        {
            Console.WriteLine("Months names in " + cultureInfo.ToString() + ":");
            
            for (int monthIndex = 1; monthIndex <= 12; ++monthIndex)
            {
                DateTime dateTime = new DateTime(2000, monthIndex, 1);
                
                Console.WriteLine(dateTime.ToString("MMMM", cultureInfo));
            }
        }
    }
}