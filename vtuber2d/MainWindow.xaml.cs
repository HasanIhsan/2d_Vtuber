using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
using System.Windows;
using System.Windows.Threading;


namespace vtuber2d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechRecognitionEngine speechRecognitionEngine;
        private bool isListening = false;

        public ObservableCollection<string> InputDevices { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            LoadInputDevices();
            InitializeSpeechRecognition();
        }

        private void LoadInputDevices()
        {
            var devices = System.Speech.Recognition.SpeechRecognitionEngine.InstalledRecognizers();

            foreach (var device in devices)
            {
                InputDevices.Add(device.Description);
            }

            inputDevicesComboBox.ItemsSource = InputDevices;
        }

        private void InitializeSpeechRecognition()
        {
            speechRecognitionEngine = new SpeechRecognitionEngine();
            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            speechRecognitionEngine.AudioLevelUpdated += SpeechRecognitionEngine_AudioLevelUpdated;

            // Add any additional grammar or configuration as needed
            var grammar = new DictationGrammar();
            speechRecognitionEngine.LoadGrammar(grammar);
        }
        private void SpeechRecognitionEngine_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            // Adjust the threshold value as needed based on your audio input
            if (e.AudioLevel > 0.1)
            {
                // Audio detected, show the label
                Dispatcher.Invoke(() => { audioLabel.Visibility = Visibility.Visible; });
            }
            else
            {
                // No audio, hide the label
                Dispatcher.Invoke(() => { audioLabel.Visibility = Visibility.Hidden; });
            }
        }


        //this migt be used for something for later
        private void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // This method is called when speech is recognized
            Debug.WriteLine ($"Speech Recognized: {e.Result.Text}");
        }

        private void SelectInputDevice_Click(object sender, RoutedEventArgs e)
        {
            string selectedDeviceName = inputDevicesComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedDeviceName))
            {
                // Stop listening to the previous device, if any
                if (isListening)
                {
                    speechRecognitionEngine.RecognizeAsyncCancel();
                    isListening = false;
                }

                // Set up the new speech recognition engine for the selected device
                speechRecognitionEngine.SetInputToDefaultAudioDevice();
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

                MessageBox.Show($"Selected Input Device: {selectedDeviceName}");
                isListening = true;
            }
            else
            {
                MessageBox.Show("Please select an input device.");
            }
        }
    }
}