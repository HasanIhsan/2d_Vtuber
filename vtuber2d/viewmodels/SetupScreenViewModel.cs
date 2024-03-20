using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.navigation;
using vtuber2d.RelayCommands;

namespace vtuber2d.viewmodels
{
    public class SetupScreenViewModel : ViewModelBase
    {
        private RelayCommand? _navigateToMainScreenCOmmand;

        public RelayCommand NavigateToMainScreenCOmmand
        {
            get
            {
                return _navigateToMainScreenCOmmand ?? (_navigateToMainScreenCOmmand = new RelayCommand(NavigationHandler.GetNavigationAction("main_Screen")));
            }
        }
    }
}
