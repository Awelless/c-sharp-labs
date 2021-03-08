using System.Text.RegularExpressions;

namespace WordReverse
{
    public class WordParser
    {
        private static string SEPARATOR = " +";
        
        public static string[] Parse(string line)
        {
            return Regex.Split(line, SEPARATOR);
        }
    }
}