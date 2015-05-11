using System.Windows;
using EveExcelMineralUpdater.ViewModels;

namespace EveExcelMineralUpdater.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView<MainViewModel>
    {
        private MainViewModel _mainViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel { get; set; }
    }
}