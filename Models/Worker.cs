using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Worker
    {
        public Worker()
        {
        
        }

        public int CountNegativeWords(string content, List<string> negativeWords)
        {
            int result = 0;

            negativeWords.ForEach(nw =>
            {
                if (content.Contains(nw))
                {
                    result++;
                }
            });
            return result;
        }


    }
}
