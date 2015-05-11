using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveExcelMineralUpdater.ViewModels;
using EveExcelMineralUpdater.Views;

namespace EveExcelMineralUpdater
{
    public class FlowManager
    {
        private static FlowManager _instance;

        private MainWindow _mainWindow;

        private FlowManager()
        {

        }

        public void ChangePage(Pages page)
        {
            IViewModel newViewModel = null; // TODO: Remove null when every page viewmodel implemented
            
            switch (page)
            {
                case Pages.MarketStat:
                    break;
                case Pages.QuickLook:
                    newViewModel = new QuickLookRequestViewModel();
                    break;
                case Pages.History:
                    break;
                case Pages.Route:
                    break;
                case Pages.Settings:
                    break;
            }

            AppWindow.ViewModel.CurrentViewModel = newViewModel;
        }

        public static FlowManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlowManager();
                }

                return _instance;
            }
        }

        public MainWindow AppWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        public enum Pages
        {
            MarketStat,
            QuickLook,
            History,
            Route,
            Settings
        }
    }
}
