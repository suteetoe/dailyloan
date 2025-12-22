using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Migration.data
{
    internal interface IDBMigrate
    {
        void Start();
    }
}
