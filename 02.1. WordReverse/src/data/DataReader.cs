using System;

namespace WordReverse.data
{
    public class DataReader
    {
        public static string Read()
        {
            Console.WriteLine("Enter line:");
            return Console.ReadLine();
        }
    }
}