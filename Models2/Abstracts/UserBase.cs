using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models2
{
    public abstract class UserBase
    {
        

        public abstract int CountNegativeWords(string content);

        public virtual  string GetScannedText(string content) {
            return string.Format("Scanned the text:{0}", content);
        }
        public virtual  string GetNegativeWordsText(int cntNegativeWords)
        {
            return string.Format("Total Number of negative words:{0}", cntNegativeWords);
        }
        
        public virtual void DisplayOutput(string content, int cntBadWords) {
            Console.WriteLine(GetScannedText(content));
            Console.WriteLine(GetNegativeWordsText(cntBadWords));
            
        }

        
    }
}
