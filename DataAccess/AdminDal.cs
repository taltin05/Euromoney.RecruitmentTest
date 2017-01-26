using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AdminDal : IAdminDal
    {
        public List<string> GetNegativeWords()
        {
            // This is where we would connect to DB and return logic
            // Ignore the DB logic for this example
            return null;
        }
    }
}
