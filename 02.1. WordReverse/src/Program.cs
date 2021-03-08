using System;
using WordReverse.data;

namespace WordReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = DataReader.Read();

            string[] words = WordParser.Parse(data);
            Array.Reverse(words);
            
            DataWriter.PrintWords(words);
        }
    }
}