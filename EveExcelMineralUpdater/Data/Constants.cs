using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Constants
    {
        public const String EVECENTRAL_API_BASE_URL = @"http://api.eve-central.com/api/";
        public const String QUICKLOOK_HTML_QUERY_URL = @"http://api.eve-central.com/api/quicklook/";

        public const String ROOT_XML_NODE_NAME = "settings";
        public const String EXCEL_FILEPATH_XML_NODE_NAME = "excel file path";
        public const String EXCEL_PRICE_COLUMN_NAME_XML_NODE_NAME = "excel price column name";
    }
}
