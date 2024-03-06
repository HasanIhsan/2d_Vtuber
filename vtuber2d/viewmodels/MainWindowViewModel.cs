using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtuber2d.navigation;

namespace vtuber2d.viewmodels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? _currentviewModel;
        private NavigationHandler? _handler;

        public ViewModelBase CurrentViewModel
        {
            get => _currentviewModel;
            set
            {
                _currentviewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainWindowViewModel()
        {
            _handler = new NavigationHandler(this);

            NavigaionService._navigate += _handler.Navigate;

            //set intial
            _handler.Navigate("setup_Screen");
        }

    }
}
