using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models2
{
    public class User : UserBase
    {
        private List<string> negativeWords;
        public User()
        {
           negativeWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
        }
        
        public override int CountNegativeWords(string content)
        {
            WordCounter wc = new WordCounter();
            return wc.Count(content, negativeWords);
        }
        
        
    }
}
