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
using vtuber2d.viewmodels;


namespace vtuber2d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
 
    }
}