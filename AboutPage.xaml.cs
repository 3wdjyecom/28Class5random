using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;


namespace 抽号器
{
    public partial class AboutPage : Page
    {

        public AboutPage()
        {
            InitializeComponent();
            NavigateToSetting();
        }
        public void NavigateToSetting()
        {
            SettingFrame.Navigate(new SettingPage());
            
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingFrame.Visibility = Visibility.Visible;
            SettingFrame.Navigate(new SettingPage());
        }
    }
}