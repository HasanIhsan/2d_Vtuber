﻿#pragma checksum "..\..\..\..\Screens\MainScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "308A8A0264F8F96203BE5D21E5FE7AA992E3D4D2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using vtuber2d.Screens;


namespace vtuber2d.Screens {
    
    
    /// <summary>
    /// MainScreen
    /// </summary>
    public partial class MainScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainScreenGrid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setupScreenBtn;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label audioLabel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox inputDevicesComboBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectDeviceBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image vtuber;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox GCheckBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/vtuber2d;V1.0.0.0;component/screens/mainscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Screens\MainScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainScreenGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.setupScreenBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.audioLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.inputDevicesComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.SelectDeviceBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Screens\MainScreen.xaml"
            this.SelectDeviceBtn.Click += new System.Windows.RoutedEventHandler(this.SelectInputDevice_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.vtuber = ((System.Windows.Controls.Image)(target));
            
            #line 18 "..\..\..\..\Screens\MainScreen.xaml"
            this.vtuber.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Screens\MainScreen.xaml"
            this.vtuber.MouseMove += new System.Windows.Input.MouseEventHandler(this.Image_MouseMove);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Screens\MainScreen.xaml"
            this.vtuber.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Screens\MainScreen.xaml"
            this.vtuber.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Image_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\..\..\Screens\MainScreen.xaml"
            this.GCheckBox.Checked += new System.Windows.RoutedEventHandler(this.GCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Screens\MainScreen.xaml"
            this.GCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.GCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

