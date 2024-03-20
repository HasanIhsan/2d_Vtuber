using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.viewmodels;

namespace vtuber2d.navigation
{
    public class NavigationHandler
    {
        private MainWindowViewModel _mainViewModel;


        public NavigationHandler(MainWindowViewModel? mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void Navigate(string ScreenName)
        {
            switch(ScreenName)
            {
                case "setup_Screen":
                    _mainViewModel.CurrentViewModel = new SetupScreenViewModel();
                    break;
                case "main_Screen":
                    _mainViewModel.CurrentViewModel = new MainScreenViewModel();
                    break;
            }
        }



        /*
            //putting all navigation in one file so its simpler to add and change things in the furture
            //aside from addin the new viewmodel, and updating the swtich in the mainviewmodel 
            //you can simple add a new path in this switch case and invoke it from the viewmodel classes:
            //ex: return _navigateToBCommand ?? (_navigateToBCommand = new RelayCommand(Navigate.GetNavigationAction("B")));
         */
        public static Action GetNavigationAction(string navto)
        {
            Debug.WriteLine(navto);
            switch(navto)
            {
                case "setup_Screen":
                    return () => NavigaionService.NavigateTo("setup_Screen");
                case "main_Screen":
                    return () => NavigaionService.NavigateTo("main_Screen");
                default:
                    return () => { };
            }
        }
    }
}
