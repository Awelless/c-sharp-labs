using System;
using System.Globalization;

namespace Months.data
{
    public class DataReader
    {
        public static CultureInfo ReadCulture()
        {
            while (true)
            {
                Console.WriteLine("Enter culture: ");
                
                string data = Console.ReadLine();

                try
                {
                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(data);

                    if (cultureInfo.IsNeutralCulture || cultureInfo.Equals(CultureInfo.InvariantCulture))
                    {
                        throw new CultureNotFoundException();
                    } 
                    
                    return cultureInfo;
                }
                catch (CultureNotFoundException)
                {
                    Console.WriteLine("Invalid culture format. Try again");
                }
            }
        }
    }
}