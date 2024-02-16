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
using vtuber2d.storing_Pictures;

namespace vtuber2d.speechRecog
{
    public class SpeechRecognition
    {
        public ObservableCollection<string> InputDevices { get; set; } = new ObservableCollection<string>();
        public static SpeechRecognitionEngine speechRecognitionEngine;


        private MainWindow mainWindow;
        private Label audioLabel;
        private Image notTalkingImage;


        private pictures _picturesInstance;
        private OpenFileDialog _openFileDialog;

        public SpeechRecognition(MainWindow mainWindow, Label audioLabel, Image notTalkingImage, pictures pictureInstance)
        {
            this.mainWindow = mainWindow;
            this.audioLabel = audioLabel;
            this.notTalkingImage = notTalkingImage;
            this._picturesInstance = pictureInstance;
        }

        //loads the input devices for the speech recogination
        public ObservableCollection<string> LoadInputDevices()
        {
            var devices = System.Speech.Recognition.SpeechRecognitionEngine.InstalledRecognizers();

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

            Debug.WriteLine(_picturesInstance.notTalkingPicture);
            Debug.WriteLine(_picturesInstance.talkingPicture);

            mainWindow.Dispatcher.Invoke(() => {
                // Adjust the threshold value as needed based on your audio input
                if (e.AudioLevel > 0.5)
                {
                    // Audio detected, show the label
                    audioLabel.Visibility = Visibility.Visible;

                    Debug.WriteLine(_picturesInstance.getImageT());
                   
                      //  Debug.WriteLine($"not null {_picturesInstance.talkingPicture}");
                       notTalkingImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(_picturesInstance.getImageT()));
                    
                }
                else
                {
                    // No audio, hide the label
                    audioLabel.Visibility = Visibility.Hidden;

                    
                      //  Debug.WriteLine($"not null {_picturesInstance.notTalkingPicture}");
                        notTalkingImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(_picturesInstance.getimageN()));
                    
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
