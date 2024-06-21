using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
using System.Windows.Threading;
using vtuber2d.speechRecog;
using vtuber2d.storing_Pictures;

namespace vtuber2d.Screens
{
    /// <summary>
    /// Interaction logic for SetupScreen.xaml
    /// </summary>
    public partial class SetupScreen : UserControl
    {
        //public ObservableCollection<string> InputDevices { get; set; } = new ObservableCollection<string>();

        public SetupScreen()
        {
            InitializeComponent();
           
        }

        private void notTalkingbtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("not takling clicked");


            // _picturesInstance.setimageN();
            Pictures.Instance.setimageN();
            notTalkingImage.Source = new BitmapImage(new Uri(Pictures.Instance.getimageN()));
        }

        private void Talkingbtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("talking btn clicked");


            //_picturesInstance.setImageT();
            Pictures.Instance.setImageT();
            // Add debug prints to check if talkingPicture is being set
            //Debug.WriteLine($"talkingPicture: {_picturesInstance.talkingPicture}");
            //Debug.WriteLine($"getImageT result: {_picturesInstance.getImageT()}");
            TalkingImage.Source = new BitmapImage(new Uri(Pictures.Instance.getImageT()));
        }




       
    }
}
