using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data
{
    public class Paginator
    {
        int page;
        int size;

        public Paginator(int page, int size)
        {
            this.page = page;
            this.size = size;
        }

        public string GetPaginationQuery()
        {
            int limit = size;
            int offset = (page - 1) * size;

            string pageFilterQuery = string.Format(" LIMIT {0} OFFSET {1} ", limit, offset);
            return pageFilterQuery;
        }
    }
}
