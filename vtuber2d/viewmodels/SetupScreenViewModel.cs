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
        private RelayCommand? _navigateToMainScreenCOmmand, _navigateToSelectScreenCommand;

        public RelayCommand NavigateToMainScreenCOmmand
        {
            get
            {
                return _navigateToMainScreenCOmmand ?? (_navigateToMainScreenCOmmand = new RelayCommand(NavigationHandler.GetNavigationAction("main_Screen")));
            }
        }

        /// <summary>
        /// CS0548:  indicates that the property NavigateToSelectScreenCommand does not have any accessor (i.e., a getter or setter)
        /// sometimes this error will popup when adding commands
        /// </summary>
        public RelayCommand NavigateToSelectScreenCommand
        {
            get
            {
                return _navigateToSelectScreenCommand ?? (_navigateToSelectScreenCommand = new RelayCommand(NavigationHandler.GetNavigationAction("select_Screen")));
            }
        }
    }
}
