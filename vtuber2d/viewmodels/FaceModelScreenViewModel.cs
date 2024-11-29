using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.navigation;
using vtuber2d.RelayCommands;

namespace vtuber2d.viewmodels
{
    public class FaceModelScreenViewModel : ViewModelBase
    {
        private RelayCommand? _navigateToSelectScreenCommand;
        public RelayCommand NavigateToSelectScreenCommand
        {
            get
            {
                return _navigateToSelectScreenCommand ?? (_navigateToSelectScreenCommand = new RelayCommand(NavigationHandler.GetNavigationAction("select_Screen")));
            }
        }
    }
}
