using System.Globalization;
using Months.data;

namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = DataReader.ReadCulture();

            DataWriter.PrintMonths(cultureInfo);
        }
    }
}