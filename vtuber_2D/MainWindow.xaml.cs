using NAudio.Wave;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vtuber_2D.manager;

namespace vtuber_2D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AudioDeviceManager audioManger = new AudioDeviceManager();
            cmbMicrophones.ItemsSource = audioManger.GetAudioDevices();
        }


        private void cmbMicrophones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("selection changed");
            string selectedDevice = cmbMicrophones.SelectedItem as string;

            if (selectedDevice != null)
            {
                // Check if the selected microphone is picking up sound
                // You can use NAudio or other libraries to implement this functionality
                // For example, you can use NAudio's WasapiLoopbackCapture to capture audio
                // and check if the audio level is above a certain threshold.
                // Refer to NAudio documentation for more details.
                // Here's a simplified example using NAudio's WasapiLoopbackCapture:
                Debug.WriteLine("not null");
                using (var capture = new WasapiLoopbackCapture())
                {
                    capture.DataAvailable += (s, args) =>
                    {
                        // Check audio data here and update UI accordingly
                        // For example, you can update a label or change the color of a button
                        // based on the audio level.
                        Debug.WriteLine("has audio");
                    };

                    capture.StartRecording();
                }
            }
        }
    }
}