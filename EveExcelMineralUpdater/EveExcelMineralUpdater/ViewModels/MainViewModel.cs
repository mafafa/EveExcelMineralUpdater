using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Helper;

namespace EveExcelMineralUpdater.ViewModels
{
    public class MainViewModel : IViewModel
    {
        private IViewModel _currentViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            
        }
        
        protected void RaisePropertyChanged([CallerMemberName]string propertName = "")
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertName));
            }
        }

        private void ChangeToQuickLook(object param)
        {
            FlowManager.Instance.ChangePage(FlowManager.Pages.QuickLook);
        }

        public IViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand ChangeToQuickLookCommand
        {
            get { return new RelayCommand(ChangeToQuickLook); }
        }
    }
}
