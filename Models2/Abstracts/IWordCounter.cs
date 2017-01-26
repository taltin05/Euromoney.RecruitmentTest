using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models2
{
    public interface IWordCounter
    {
        int Count(string content, List<string> words);
    }
}
