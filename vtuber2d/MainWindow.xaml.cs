using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
using System.Windows;
using System.Windows.Threading;
using vtuber2d.speechRecog;
using vtuber2d.storing_Pictures;


namespace vtuber2d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechRecognitionEngine speechRecognitionEngine;
        private bool isListening = false;
        private OpenFileDialog _openFileDialog;
        private pictures _picturesInstance = new pictures();
        private SpeechRecognition _speechReco;
      
        //public ObservableCollection<string> InputDevices { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            _speechReco = new SpeechRecognition(this, audioLabel, notTalkingImage, _picturesInstance);
            // LoadInputDevices();
            inputDevicesComboBox.ItemsSource = _speechReco.LoadInputDevices(); //does putting this here make it slower?
                                                                               
            _speechReco.InitializeSpeechRecognition(); // InitializeSpeechRecognition();
        }

        private void notTalkingbtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("not takling clicked");


            _picturesInstance.setimageN();
            notTalkingImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(_picturesInstance.notTalkingPicture));
        }

        private void Talkingbtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("talking btn clicked");


            _picturesInstance.setImageT();
            // Add debug prints to check if talkingPicture is being set
            //Debug.WriteLine($"talkingPicture: {_picturesInstance.talkingPicture}");
            //Debug.WriteLine($"getImageT result: {_picturesInstance.getImageT()}");
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