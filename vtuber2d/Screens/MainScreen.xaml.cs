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
        private bool isDragging = false;
        private Point offset;


        private SpeechRecognition _speechReco;
        public MainScreen()
        {

            InitializeComponent();

            //set inital image;
            vtuber.Source = new BitmapImage(new Uri(Pictures.Instance.getimageN()));

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

        // Image_MouseDown: Sets a flag indicating that the image is being dragged and stores the offset between the mouse cursor and the top-left corner of the image.
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //set flag indicating image is being dragged
            isDragging = true;

            //store the current position of the mouse relative to the image
            offset = e.GetPosition(vtuber);
        }

        /*
         * Image_MouseMove: Updates the position of the image while it's being dragged.
         * The Margin property represents the distance between the element and its parent's edges. By adjusting the margins, we can move the image within its parent container.
         */
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                Debug.WriteLine("moving");

                //get the current position relative to the window
                Point currentPosition = e.GetPosition(this);

                //calculate the new position based on offset
                double newX = currentPosition.X - offset.X;
                double newY = currentPosition.Y - offset.Y;

                //update the position of the image
                vtuber.Margin = new Thickness(newX, newY, 0, 0);

                
            }
        }


        // Image_MouseUp: Resets the flag when the mouse button is released, indicating that the dragging operation has ended.
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //reset the flag
            isDragging = false;
            Debug.WriteLine("not dragging");
        }

        //Image_MouseWheel: handle the MouseWheel event of the image.
        /*
         *  determine the direction of the mouse wheel scroll (e.Delta > 0 indicates scrolling up, and e.Delta < 0 indicates scrolling down).
            calculate the new scale factor by adjusting the image width and height based on the delta value.
            limit the minimum scale factor to prevent the image from becoming too small.
            update the image size based on the new scale factor.
         */
        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //determine the direction of the mouse wheel scrool (up or down)
            double delta = e.Delta > 0 ? 0.1 : -0.1;

            //calculate the new scale factor
            double scaleX = vtuber.Width / 179 + delta;
            double scaleY = vtuber.Height / 153 + delta;


            //udpate the image size
            vtuber.Width = 179 * scaleX;
            vtuber.Height = 153 * scaleY;
        }

       

       //checkBox
       
        //checked:
        // change the backgroud to green
        //and hide all the other uncessary buttons
        private void GCheckBox_Checked (object sender, RoutedEventArgs e)
        {
            //GCheckBox.Content = "checked";
            mainScreenGrid.Background = Brushes.Green;
            SelectDeviceBtn.Visibility = Visibility.Collapsed;
            inputDevicesComboBox.Visibility = Visibility.Collapsed;
            audioLabel.Visibility = Visibility.Collapsed;
            setupScreenBtn.Visibility = Visibility.Collapsed;
        }

        //unchecked:
        //change the backgroud color back to white
        //show all the buttons!
        private void GCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //GCheckBox.Content = "unchecked";
            mainScreenGrid.Background = Brushes.White;
            SelectDeviceBtn.Visibility = Visibility.Visible;
            inputDevicesComboBox.Visibility = Visibility.Visible;
            
            setupScreenBtn.Visibility = Visibility.Visible;
        }
    }
    
}
