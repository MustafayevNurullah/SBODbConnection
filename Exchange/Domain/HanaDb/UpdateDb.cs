using Exchange.DbConnection;
using Exchange.Models;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Domain.HanaDb
{
    class UpdateDb
    {
        readonly Company DbConnection;
        SAPbobsCOM.SBObob bo;
        public UpdateDb()
        {
            DbConnection = HanaDbConnection.DbConnection();
            bo=(SBObob)DbConnection.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
        }

    public  void UpdateCurrency(ValCurs Currency)
        {
            foreach (var item in Currency.ValType[1].Valute)
            {
                switch (item.Code)
                {
                    case "USD":
                        bo.SetCurrencyRate("USD", DateTime.Now, Convert.ToDouble(item.Value), true);
                        break;
                    case "DKK":
                        bo.SetCurrencyRate("DKK", DateTime.Now, Convert.ToDouble(item.Value), true);
                        break;
                    case "EUR":
                        bo.SetCurrencyRate("EUR", DateTime.Now, Convert.ToDouble(item.Value), true);
                        break;
                    case "GPB":
                        bo.SetCurrencyRate("GPB", DateTime.Now, Convert.ToDouble(item.Value), true);
                        break;
                    case "SEK":
                        bo.SetCurrencyRate("SEK", DateTime.Now, Convert.ToDouble(item.Value), true);
                        break;
                }
            }
        }
    }
}
