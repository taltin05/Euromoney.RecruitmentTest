using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Models2
{
    public class Curator : UserBase
    {
        private IAdminDal _adminDal;
        private List<string> negativeWords;
        public bool ShouldFilterText { get; set; }

        public Curator(IAdminDal adminDal) 
        {
            _adminDal = adminDal;
        }

        public override int CountNegativeWords(string content)
        {
            WordCounter wc = new WordCounter();
            negativeWords = _adminDal.GetNegativeWords();
            return wc.Count(content, negativeWords);
        }

        public string FormatContent(string content)
        {
            return ShouldFilterText ? FilterText(content) : content;
        }

        public override void DisplayOutput(string content, int cntBadWords)
        {
            base.DisplayOutput(FormatContent(content), cntBadWords);
        }

        public string FilterText(string content)
        {
            negativeWords = _adminDal.GetNegativeWords();

            negativeWords.ForEach(nw =>
            {
                if (content.ToLower().Contains(nw.ToLower()))
                {
                    content = content.Replace(nw, nw.ToString().Filter());
                }
            });
            return content;
        }
    }
}
