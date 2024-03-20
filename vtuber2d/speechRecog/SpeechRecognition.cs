using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using vtuber2d.Screens;
using vtuber2d.storing_Pictures;

namespace vtuber2d.speechRecog
{
    public class SpeechRecognition
    {
        public ObservableCollection<string> InputDevices { get; set; } = new ObservableCollection<string>();
        public static SpeechRecognitionEngine speechRecognitionEngine;


        private MainScreen mainWindow;
        private Label audioLabel;
        private Image vtuberImage;


      
        private OpenFileDialog _openFileDialog;

        public SpeechRecognition(MainScreen mainWindow, Label audioLabel, Image vtuberImage)
        {
            this.mainWindow = mainWindow;
            this.audioLabel = audioLabel;
            this.vtuberImage = vtuberImage;
           
        }

        //loads the input devices for the speech recogination
        public ObservableCollection<string> LoadInputDevices()
        {
            var devices = SpeechRecognitionEngine.InstalledRecognizers();

            foreach (var device in devices)
            {
                InputDevices.Add(device.Description);
            }

            return InputDevices;
        }


      

      

        //initialiing the speech recnogigin engine
        public void InitializeSpeechRecognition()
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

           //Debug.WriteLine(pictures.Instance.notTalkingPicture);
           //Debug.WriteLine(pictures.Instance.talkingPicture);

            mainWindow.Dispatcher.Invoke(() => {
                // Adjust the threshold value as needed based on your audio input
                if (e.AudioLevel > 0.5)
                {
                    // Audio detected, show the label
                    audioLabel.Visibility = Visibility.Visible;

                    Debug.WriteLine(pictures.Instance.getImageT());
                   
                      //  Debug.WriteLine($"not null {_picturesInstance.talkingPicture}");
                       vtuberImage.Source = new BitmapImage(new Uri(pictures.Instance.getImageT()));
                    
                }
                else
                {
                    // No audio, hide the label
                    audioLabel.Visibility = Visibility.Hidden;

                    
                      //  Debug.WriteLine($"not null {_picturesInstance.notTalkingPicture}");
                        vtuberImage.Source = new BitmapImage(new Uri(pictures.Instance.getimageN()));
                    
                }
            });
        }

     
        private void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // This method is called when speech is recognized
            Debug.WriteLine($"Speech Recognized: {e.Result.Text}");
        }


        public void select_speechDevice(bool isListening, string selectedDeviceName)
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

           
            isListening = true;
        }

    }
}
