using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Dictionary.LanguageRESX;
using WPFLocalizeExtension.Engine;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("EN");

        }
    }
}
