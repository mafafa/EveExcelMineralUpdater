using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EveExcelMineralUpdater.ViewModels;

namespace EveExcelMineralUpdater.Views
{
    /// <summary>
    /// Interaction logic for QuickLookRequestView.xaml
    /// </summary>
    public partial class QuickLookRequestView : UserControl, IView<QuickLookRequestViewModel>
    {
        private QuickLookRequestViewModel _viewModel;
        
        public QuickLookRequestView()
        {
            InitializeComponent();
        }

        public QuickLookRequestViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }
    }
}
