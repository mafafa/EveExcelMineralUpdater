using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Constants
    {
        public const String EVECENTRAL_API_BASE_URL = @"http://api.eve-central.com/api";
        public const String QUICKLOOK_HTTP_QUERY_URL = @"/quicklook?";

        public const String CFG_ROOT_XML_NODE_NAME = "settings";
        public const String CFG_EXCEL_FILEPATH_XML_NODE_NAME = "excelFilePath";
        public const String CFG_EXCEL_PRICE_COLUMN_XML_NODE_NAME = "excelPriceColumn";
        public const String CFG_EXCEL_PRICE_ROW_START_XML_NODE_NAME = "excelPriceRowStart";
        public const String CFG_EXCEL_PRICE_ROW_END_XML_NODE_NAME = "excelPriceRowEnd";

        public const String API_RESPONSE_BUY_ORDER_NODE_XPATH = "evec_api/quicklook/buy_orders/order";
        public const String API_RESPONSE_PRICE_FILTER = @"price";
        public const String API_RESPONSE_VOL_REMAINING_FILTER = @"vol_remain";
    }
}
