using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models2
{
    public static class WordFilterer
    {
        public static string Filter(this string word)
        {
            string result = "";
            var hashes = new StringBuilder();
            for (int i = 0; i < (word.Length - 2); i++)
            {
                hashes.Append("#");
            }
            result = word.Replace(word.Substring(1, word.Length - 2), hashes.ToString());
            return result;
        } 
    }
}
