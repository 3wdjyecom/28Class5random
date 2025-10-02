using System;
using System;
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
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }
        string avoid;
        private void Avoidfigure_TextChanged(object sender, TextChangedEventArgs e)
        {
            avoid = aviodfigure.Text;
            Regex regex = new Regex(@"^[\d;]$");
            if (!regex.IsMatch(aviodfigure.Text))
            {
                e.Handled = true; // 阻止输入
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(avoid))
            {
                MessageBox.Show("请输入要避开的数字", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string[] avoider = avoid.Split(';');
            int[] allavNumbers = avoider.Select(int.Parse).ToArray();
            foreach (int num in allavNumbers)
            {
                
            }
        }



        private void Killexplorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                // 使用 taskkill 强制结束并防止重启
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = "/f /im explorer.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                Process.Start(startInfo);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败: {ex.Message}");
            }
        }

        private void returnexplorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ 启动资源管理器失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            // 修改这里：调用主窗口的导航方法
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.NavigateToMain();
            }
        }

    }


        
    }

