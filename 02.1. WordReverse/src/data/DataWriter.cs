using System;

namespace WordReverse.data
{
    public class DataWriter
    {
        public static void PrintWords(string[] words)
        {
            Console.WriteLine("Words in reverse order:");
            
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
}