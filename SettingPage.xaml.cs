using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


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
                MessageBox.Show($"? 启动资源管理器失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void cmbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void selhd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOptions.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cmbOptions.SelectedItem;
                string displayText = selectedItem.Content.ToString();  // 显示文本："选项1"
                string value = selectedItem.Tag?.ToString();

                if (value == "True")  // 修正：使用 == 而不是 =，并添加引号
                {
                    try
                    {
                        string appDir = AppDomain.CurrentDomain.BaseDirectory;
                        string filePath = Path.Combine(appDir, "set1.hcy");
                        string[] lines = { "True" };

                        File.WriteAllLines(filePath, lines);
                        
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else  // 添加 else 分支
                {
                    try
                    {
                        string appDir = AppDomain.CurrentDomain.BaseDirectory;
                        string filePath = Path.Combine(appDir, "set1.hcy");
                        string[] lines = { "False" };
                        File.WriteAllLines(filePath, lines);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"写入文件时出错: {ex.Message}");
                    }
                }
            }
        }

        private void About_Click_1(object sender, RoutedEventArgs e)
        {
            AboutFrame.Visibility = Visibility.Visible;
            AboutFrame.Navigate(new AboutPage());
        }
    }



}

