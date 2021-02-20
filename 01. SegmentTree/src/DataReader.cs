using System;

namespace SegmentTree
{
    public class DataReader
    {
        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        
        public static int[] ReadIntArray(int length)
        {
            string[] inputArray = Console.ReadLine().Split(' ');
            
            int[] result = new int[length];
            for (int index = 0; index < length; index++)
            {
                result[index] = Convert.ToInt32(inputArray[index]);
            }
            
            return result;
        }
    }
}