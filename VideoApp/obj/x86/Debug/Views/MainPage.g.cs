﻿#pragma checksum "C:\Users\hlamzadr\Documents\Visual Studio 2015\Projects\Temp10WithService\VideoApp\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4A6F9ECC6D74D24DD3161FDF28577BA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoApp.Views
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ViewModel = (global::VideoApp.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 2:
                {
                    this.pageHeader = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.CommandBar element3 = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                    #line 44 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.CommandBar)element3).Opening += this.CommandBar_Opening;
                    #line 45 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.CommandBar)element3).Closing += this.CommandBar_Closing;
                    #line default
                }
                break;
            case 4:
                {
                    this.itemGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
