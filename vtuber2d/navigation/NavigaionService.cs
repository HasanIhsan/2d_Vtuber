using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtuber2d.navigation
{
    public static class NavigaionService
    {
        public static Action<string>? _navigate;

        public static void NavigateTo(string ScreenName)
        {
            _navigate?.Invoke(ScreenName);
        }
    }
}
