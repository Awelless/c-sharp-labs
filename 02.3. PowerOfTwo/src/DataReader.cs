using System;

namespace PowerOfTwo
{
    public class DataReader
    {
        public static ulong ReadUlong()
        {
            while (true)
            {
                string data = Console.ReadLine();

                ulong number;
                if (UInt64.TryParse(data, out number) && number > 0)
                {
                    return number;
                }
                
                Console.WriteLine("Invalid number. Try again");
            }
        }
    }
}