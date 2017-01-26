using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models2
{
    public class WordCounter : IWordCounter
    {
        public int Count(string content, List<string> words) {
            int result = 0;
            List<string> checkedWords = new List<string>();
            words.ForEach(nw =>
            {
                if (content.ToLower().Contains(nw.ToLower()) && !checkedWords.Contains(nw.ToLower()))
                {
                    //to prevent double counting, we need to keep track of words that are already checked
                    checkedWords.Add(nw.ToLower());
                    result++;
                }
            });
            return result;
        }
    }
}
