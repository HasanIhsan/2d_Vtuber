using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.navigation;
using vtuber2d.RelayCommands;

namespace vtuber2d.viewmodels
{
    public class MainScreenViewModel: ViewModelBase
    {
        private RelayCommand? _navigateToSetupCOmmand;

        public RelayCommand NavigateToSetupCOmmand
        {
            get
            {
                return _navigateToSetupCOmmand ?? (_navigateToSetupCOmmand = new RelayCommand(NavigationHandler.GetNavigationAction("setup_Screen")));
            }
        }
    }
}
