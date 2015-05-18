using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Core;
using Data;
using Data.APIRequests;
using Data.EveIDs;

namespace EveExcelMineralUpdater.ViewModels
{
    public class QuickLookRequestViewModel : IViewModel
    {
        private ObservableCollection<MarketOrder> _quickLookItems;
        private ICollection<String> _comboBoxItemTypes;
        private ICollection<String> _comboBoxItems;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public QuickLookRequestViewModel()
        {
            QuickLookItems = new ObservableCollection<MarketOrder>();
            InitItemTypeComboBox();
            InitItemComboBox();
            
            
            // We initiate the request from prices
            QuickLookRequest quickLookRequest = (QuickLookRequest)ApiRequestFactory.CreateApiRequest(ApiRequestFactory.ApiRequestType.QuickLook);
            quickLookRequest.UseSystem = EveLocationIDs.RENS_SYSTEM_ID;
            quickLookRequest.TypeID = EveOreIDs.SCORDITE_ORE_ID;

            ApiHttpRequestBuilder requestBuilder = new ApiHttpRequestBuilder(quickLookRequest);

            if (requestBuilder.ExecuteRequest())
            {
                EveItem item = new EveItem();
                item.ItemID = quickLookRequest.TypeID;
                item.ItemName = "Scordite";
                item.ItemType = EveItem.ItemTypes.Ore;
                Uri uri = new Uri("/EveExcelMineralUpdater;component/Images/thumb_icon-mineral-protoss.png", UriKind.Relative);
                item.Icon = new BitmapImage(uri);
                
                QuickLookResponseParser rawResponseParser = new QuickLookResponseParser(requestBuilder.Response, item);

                // We parse the answer and order it
                rawResponseParser.Parse();
                IOrderedEnumerable<MarketOrder> priceOrderedMarketOrders = rawResponseParser.ParsedMarketOrders.
                    OrderByDescending(marketOrder => marketOrder.Price).ThenByDescending(marketOrder => marketOrder.VolumeRemaining);

                foreach (MarketOrder marketOrder in priceOrderedMarketOrders)
                {
                    QuickLookItems.Add(marketOrder);
                }
            }
            else
            {
                Console.Out.WriteLine("Error in getting request's response from the API web server.");
            }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertName = "")
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertName));
            }
        }

        private void InitItemTypeComboBox()
        {
            
        }

        private void InitItemComboBox()
        {
            
        }

        public ObservableCollection<MarketOrder> QuickLookItems
        {
            get { return _quickLookItems; }
            set
            {
                if (_quickLookItems != value)
                {
                    _quickLookItems = value;
                    RaisePropertyChanged(); // TODO: need this?
                }
            }
        }

        public ICollection<String> ComboBoxItemTypes { get; private set; }

        public ICollection<String> ComboBoxItems { get; private set; }
    }
}
