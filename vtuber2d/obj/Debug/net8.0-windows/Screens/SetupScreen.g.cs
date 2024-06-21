﻿#pragma checksum "..\..\..\..\Screens\SetupScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4966F2F212D81836B66C90A608B5E4F954EB8050"
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
    /// SetupScreen
    /// </summary>
    public partial class SetupScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Screens\SetupScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label audioLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Screens\SetupScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Talkingbtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Screens\SetupScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button notTalkingbtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Screens\SetupScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image notTalkingImage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Screens\SetupScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TalkingImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/vtuber2d;component/screens/setupscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Screens\SetupScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.audioLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Talkingbtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Screens\SetupScreen.xaml"
            this.Talkingbtn.Click += new System.Windows.RoutedEventHandler(this.Talkingbtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.notTalkingbtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Screens\SetupScreen.xaml"
            this.notTalkingbtn.Click += new System.Windows.RoutedEventHandler(this.notTalkingbtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.notTalkingImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.TalkingImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

