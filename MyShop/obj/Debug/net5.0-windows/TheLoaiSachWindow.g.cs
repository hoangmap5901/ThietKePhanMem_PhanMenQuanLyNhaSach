﻿#pragma checksum "..\..\..\TheLoaiSachWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38F102BBA571976EA093212D7186589B2B9CFBBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyShop;
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


namespace MyShop {
    
    
    /// <summary>
    /// TheLoaiSachWindow
    /// </summary>
    public partial class TheLoaiSachWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\TheLoaiSachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button themTheLoaiButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\TheLoaiSachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button xoaTheLoaiButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\TheLoaiSachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button capNhatTheLoaiButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\TheLoaiSachWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid theLoaiDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyShop;component/theloaisachwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TheLoaiSachWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\TheLoaiSachWindow.xaml"
            ((MyShop.TheLoaiSachWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.themTheLoaiButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\TheLoaiSachWindow.xaml"
            this.themTheLoaiButton.Click += new System.Windows.RoutedEventHandler(this.ThemTheLoaiButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.xoaTheLoaiButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\TheLoaiSachWindow.xaml"
            this.xoaTheLoaiButton.Click += new System.Windows.RoutedEventHandler(this.XoaTheLoaiButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.capNhatTheLoaiButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\TheLoaiSachWindow.xaml"
            this.capNhatTheLoaiButton.Click += new System.Windows.RoutedEventHandler(this.CapNhatTheLoaiButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.theLoaiDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

