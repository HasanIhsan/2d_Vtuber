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
                        // Check audio data here
                        float maxVolume = 0;

                        // Analyze audio data to get the maximum volume
                        for (int i = 0; i < args.BytesRecorded; i += 2)
                        {
                            short sample = BitConverter.ToInt16(args.Buffer, i);
                            float sample32 = sample / 32768f;
                            if (Math.Abs(sample32) > maxVolume)
                            {
                                maxVolume = Math.Abs(sample32);
                            }
                        }

                        // Set the label visibility based on the audio level
                        lblSoundStatus.Visibility = (maxVolume > 0.1) ? Visibility.Visible : Visibility.Hidden;
                    };

                    capture.StartRecording();
                }
            }
        }
    }
}