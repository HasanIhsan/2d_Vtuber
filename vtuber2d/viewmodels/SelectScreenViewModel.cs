using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.navigation;
using vtuber2d.RelayCommands;

namespace vtuber2d.viewmodels
{
    public class SelectScreenViewModel : ViewModelBase
    {
        private RelayCommand? _navigateToPNGSetupScreen;

        public RelayCommand NavigateToPNGMainScreenCOmmand
        {
            get
            {
                return _navigateToPNGSetupScreen ?? (_navigateToPNGSetupScreen = new RelayCommand(NavigationHandler.GetNavigationAction("setup_Screen")));
            }
        }
    }
}
