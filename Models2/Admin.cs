using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Models2
{
    public class Admin : UserBase
    {
        private IAdminDal _adminDal;
        private List<string> negativeWords;
        
        public Admin(IAdminDal adminDal)
        {
            _adminDal = adminDal;            
        }
        
        public override int CountNegativeWords(string content)
        {             
            WordCounter wc = new WordCounter();
            negativeWords = _adminDal.GetNegativeWords();
            return wc.Count(content, negativeWords);
        }

        
    }
}
