using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
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
using vtuber2d.speechRecog;
using vtuber2d.storing_Pictures;

namespace vtuber2d.Screens
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        
       
        private bool isListening = false;


        private SpeechRecognition _speechReco;
        public MainScreen()
        {

            InitializeComponent();

            //set inital image;
            vtuber.Source = new BitmapImage(new Uri(pictures.Instance.getimageN()));

            _speechReco = new SpeechRecognition(this, audioLabel, vtuber);
            // LoadInputDevices();
            inputDevicesComboBox.ItemsSource = _speechReco.LoadInputDevices(); //does putting this here make it slower?

            _speechReco.InitializeSpeechRecognition(); // InitializeSpeechRecognition();
        }


        private void SelectInputDevice_Click(object sender, RoutedEventArgs e)
        {
            string selectedDeviceName = inputDevicesComboBox.SelectedItem as string;


            if (!string.IsNullOrEmpty(selectedDeviceName))
            {

                _speechReco.select_speechDevice(isListening, selectedDeviceName);
                MessageBox.Show($"Selected Input Device: {selectedDeviceName}");
            }
            else
            {
                MessageBox.Show("Please select an input device.");
            }
        }
    }
}
