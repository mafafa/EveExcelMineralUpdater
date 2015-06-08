using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Core;
using Core.DataLayer;
using Data;
using Data.APIRequests;
using Data.EveIDs;

namespace EveExcelMineralUpdater.ViewModels
{
    public class QuickLookRequestViewModel : IViewModel
    {
        private ObservableCollection<MarketOrder> _quickLookItems;
        
        private EveItem.ItemTypes _selectedComboBoxItemType;
        
        private ICollection<EveItem> _comboBoxItems;
        private EveItem _selectedComboBoxItem;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public QuickLookRequestViewModel()
        {
            QuickLookItems = new ObservableCollection<MarketOrder>();
            
            SelectedComboBoxItemType = ComboBoxItemTypes.ElementAt(0);

            InitItemComboBox();
            SelectedComboBoxItem = ComboBoxItems.ElementAt(0);


            // We initiate the request from prices
            /*QuickLookRequest quickLookRequest = (QuickLookRequest)ApiRequestFactory.CreateApiRequest(ApiRequestFactory.ApiRequestType.QuickLook);
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
            }*/
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertName = "")
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertName));
            }
        }

        private void InitItemComboBox()
        {
            IDataLayerAccessor dataLayerAccessor = new XmlDataLayerAccessor();
            dataLayerAccessor.LoadDataLayer();
            
            ComboBoxItems = dataLayerAccessor.GetItems(SelectedComboBoxItemType);
            SelectedComboBoxItem = ComboBoxItems.ElementAt(0);
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

        public IEnumerable<EveItem.ItemTypes> ComboBoxItemTypes 
        {
            get
            {
                return Enum.GetValues(typeof(EveItem.ItemTypes)).Cast<EveItem.ItemTypes>();
            }
        }

        public EveItem.ItemTypes SelectedComboBoxItemType
        {
            get { return _selectedComboBoxItemType; }
            set
            {
                if (_selectedComboBoxItemType != value)
                {
                    _selectedComboBoxItemType = value;
                    InitItemComboBox();
                    RaisePropertyChanged();
                }
            }
        }

        public ICollection<EveItem> ComboBoxItems
        {
            get { return _comboBoxItems; }
            private set
            {
                if (_comboBoxItems != value)
                {
                    _comboBoxItems = value;
                    RaisePropertyChanged();
                }
            }
        }

        public EveItem SelectedComboBoxItem
        {
            get { return _selectedComboBoxItem; }
            set
            {
                if (_selectedComboBoxItem != value)
                {
                    _selectedComboBoxItem = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
