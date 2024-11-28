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
        private RelayCommand? _navigateToFaceModelCommand;

        public RelayCommand NavigateToFaceModelCommand
        {
            get
            {
                return _navigateToFaceModelCommand ?? (_navigateToFaceModelCommand = new RelayCommand(NavigationHandler.GetNavigationAction("face_Screen")));
            }
        }
    }
}
