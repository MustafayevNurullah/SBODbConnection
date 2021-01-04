using Exchange.DbConnection;
using Exchange.Domain.HanaDb;
using Exchange.Models;
using SAPbobsCOM;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exchange
{
    public  class GetValute
    {
       private  ValCurs Currency;
        private UpdateDb UpdateDb;
      public  GetValute()
        {
            UpdateDb = new UpdateDb();
        }
        public  void GetCurrency()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.cbar.az/currencies/03.12.2020.xml");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream =response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                    using (TextReader reader1 = new StringReader(reader.ReadToEnd()))
                    {
                        Currency = (ValCurs)serializer.Deserialize(reader1);
                        UpdateDb.UpdateCurrency(Currency);
                    }
                }
            }
        }
    }
}
