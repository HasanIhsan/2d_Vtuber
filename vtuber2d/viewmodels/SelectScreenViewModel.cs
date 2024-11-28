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
        private RelayCommand? _navigateToFaceModelScreen;

        public RelayCommand NavigateToPNGMainScreenCOmmand
        {
            get
            {
                return _navigateToPNGSetupScreen ?? (_navigateToPNGSetupScreen = new RelayCommand(NavigationHandler.GetNavigationAction("setup_Screen")));
            }
        }

        public RelayCommand NavigateTofaceModelScreenCommand
        {
            get 
            {
                return _navigateToFaceModelScreen ?? (_navigateToFaceModelScreen = new RelayCommand(NavigationHandler.GetNavigationAction("face_Screen")));
            }
        }
    }
}
