using System;

namespace SegmentTree
{
    public class DataReader
    {
        public static int ReadInt()
        {
            while (true)
            {
                string text = Console.ReadLine();
                int number;
                if (Int32.TryParse(text, out number))
                {
                    return number;
                }
                else
                {
                   Console.WriteLine("Invalid input. Try again");
                }
            }
        }
        
        public static int[] ReadIntArray(int length)
        {
            while (true)
            {
                string text = Console.ReadLine();
                string[] inputArray = text.Split(' ');
                int[] result = new int[length];

                if (inputArray.Length != length)
                {
                    Console.WriteLine("Invalid input. Try again");
                    continue;
                }

                bool isCorrectParsed = true;
                
                for (int index = 0; index < length; index++)
                {
                    if (!Int32.TryParse(inputArray[index], out result[index]))
                    {
                        isCorrectParsed = false;
                    }
                }

                if (isCorrectParsed)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
        }
    }
}