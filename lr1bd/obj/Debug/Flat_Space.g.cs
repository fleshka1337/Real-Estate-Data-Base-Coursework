﻿#pragma checksum "..\..\Flat_Space.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3494165FF415CA0B50AE756A1BB578185C94F21F6743C8B19FA6EAEFF434B9A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using lr1bd;


namespace lr1bd {
    
    
    /// <summary>
    /// Flat_Space
    /// </summary>
    public partial class Flat_Space : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewLocation;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CityDistrict;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Street;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB3;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Flat_Space.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB4;
        
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
            System.Uri resourceLocater = new System.Uri("/lr1bd;component/flat_space.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Flat_Space.xaml"
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
            this.NewLocation = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Flat_Space.xaml"
            this.NewLocation.Click += new System.Windows.RoutedEventHandler(this.NewLocation_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CityDistrict = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TB1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TB2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Street = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 16 "..\..\Flat_Space.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TB3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TB4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 21 "..\..\Flat_Space.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

