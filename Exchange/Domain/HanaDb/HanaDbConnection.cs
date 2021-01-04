using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.DbConnection
{
   public sealed class HanaDbConnection
    {

       static Company  company;
        private HanaDbConnection()
        {
            company = new Company();
            company.Server = "bmsb1lsrv:30015";
            company.SLDServer = "10.138.56.43:40000";
            company.DbUserName = "B1DBU";
            company.DbPassword = "Adm1nbon";
            company.UserName = "mngr";
            company.Password = "1234";
            company.CompanyDB = "B1100_PRD";
            company.DbServerType = BoDataServerTypes.dst_HANADB;
            company.language = BoSuppLangs.ln_English;
            company.Connect();
        }

        public static Company DbConnection()
        {
            if(company==null)
            {
                HanaDbConnection DbConnection = new HanaDbConnection();
            }
            return company;
        }
    }
}
