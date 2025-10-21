using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
       
        private const string NAME_FILE = "../xml/data-config.xml";

        public static int productId
        {
            get
            {

                XElement xml = XElement.Load(NAME_FILE);
                int nextId = (int)xml.Element("NextProductId");
                xml.Element("NextProductId").SetValue((nextId + 1).ToString());
                xml.Save(NAME_FILE);
                return nextId;
            }
        }
        public static int saleId
        {
            get
            {
                XElement xml = XElement.Load(NAME_FILE);
                int nextId = (int)xml.Element("NextSaleId");
                xml.Element("NextSaleId").SetValue((nextId + 1).ToString());
                xml.Save(NAME_FILE);
                return nextId;
            }
        }


    }
}
