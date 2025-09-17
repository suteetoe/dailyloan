using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Data.Repository
{
    public abstract class RepositoryBase<T>
    {
        protected BizFlowControl.DBConnection connecton;
        public RepositoryBase()
        {
            this.connecton = App.DBConnection;
        }

        public List<T> ListData(string query)
        {
            return new List<T>();
        }

      
   
      
    }
}
