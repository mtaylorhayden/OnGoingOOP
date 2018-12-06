﻿#pragma checksum "..\..\AnimalWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "88881F9C386D620852FF2FDDE461AA90"
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
using ZooScenario;


namespace ZooScenario {
    
    
    /// <summary>
    /// AnimalWindow
    /// </summary>
    public partial class AnimalWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox genderComboBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ageTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weightTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pregnancyStatusLabel;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button makePregnantButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AnimalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ZooScenario;component/animalwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AnimalWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\AnimalWindow.xaml"
            ((ZooScenario.AnimalWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\AnimalWindow.xaml"
            this.nameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.nameTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.genderComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\AnimalWindow.xaml"
            this.genderComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.genderComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ageTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\AnimalWindow.xaml"
            this.ageTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.ageTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.weightTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\AnimalWindow.xaml"
            this.weightTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.weightTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pregnancyStatusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.makePregnantButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AnimalWindow.xaml"
            this.makePregnantButton.Click += new System.Windows.RoutedEventHandler(this.makePregnantButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.okButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AnimalWindow.xaml"
            this.okButton.Click += new System.Windows.RoutedEventHandler(this.okButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

