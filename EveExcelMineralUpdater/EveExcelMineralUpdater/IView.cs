using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EveExcelMineralUpdater
{
    public interface IView<TViewModel> where TViewModel : IViewModel
    {
        TViewModel ViewModel { get; set; }
    }
}
