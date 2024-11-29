using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Python.Runtime;

namespace vtuber2d.Screens
{
    /// <summary>
    /// Interaction logic for faceModelScreen.xaml
    /// </summary>
    public partial class faceModelScreen : UserControl
    {
        public faceModelScreen()
        {
            InitializeComponent();
        }

        //trkbtn
        private void Trackingbtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("tracking");
            string scriptPath = @"D:\Code_Stuff\projects\code_stuff\Vtuber_2D\vtuber2d\vtuber2d\pythonTracking";



            string EnvPath = @"C:\Users\ihsan\.pyenv\pyenv-win\versions\3.10.0";
            Environment.SetEnvironmentVariable("PATH", EnvPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONHOME", EnvPath, EnvironmentVariableTarget.Process);

            Runtime.PythonDLL = @"C:\Users\ihsan\.pyenv\pyenv-win\versions\3.10.0\python310.dll";

            PythonEngine.Initialize();

            using (Py.GIL())
            {
                try
                {
                    // Add script path to sys.path
                    dynamic sys = Py.Import("sys");
                    sys.path.append(scriptPath);

                   

                    // Import and use your Python script
                    dynamic pyscript = Py.Import("Tracking"); // Use module name without .py
                    Debug.WriteLine("Module imported successfully");


                    //dynamic result = pyscript.get_tracking_data(); // Call a function from the script
                    //Debug.WriteLine($"Tracking result: {result}");
                    //foreach (var frameData in result)
                    //{
                    //    Debug.WriteLine($"Frame Data: {frameData}");
                    //}
                    //while (true)
                    //{
                    //    dynamic frameData = pyscript.start_tracking();
                    //    if (frameData == null)  // StopIteration reached
                    //        break;

                    //    Debug.WriteLine($"Frame Data: {frameData}");
                    //}
                    // Start the tracking process (ensure this runs continuously in Python)
                    Task.Run(() =>
                    {
                        pyscript.start_tracking();
                    });

                    // Fetch the latest data
                    while (true)
                    {
                        dynamic latestData = pyscript.get_latest_data();
                        if (latestData != null)
                        {
                            Debug.WriteLine($"Latest Frame Data: {latestData}");
                        }

                        Thread.Sleep(100); // Adjust polling interval as needed
                    }


                }
                catch (Python.Runtime.PythonException ex)
                {
                    Debug.WriteLine($"Python Error: {ex.Message}");
                    Debug.WriteLine($"Python Traceback: {ex.StackTrace}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"General Error: {ex.Message}");
                }
            }

            PythonEngine.Shutdown();
        }
    }

}
