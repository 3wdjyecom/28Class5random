using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System;
using System.Diagnostics.Eventing.Reader;


namespace 抽号器
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaultValues();

        }




        private void RealTimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currentTexta = minNUM.Text;
            string currentTexti = maxNUM.Text;
        }
        private void InitializeDefaultValues()
        {
            // 确保文本框有默认值
            if (string.IsNullOrWhiteSpace(minNUM.Text))
            {
                minNUM.Text = "1";
            }

            if (string.IsNullOrWhiteSpace(maxNUM.Text))
            {
                maxNUM.Text = "40";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(minNUM.Text, out int minNum) || !int.TryParse(maxNUM.Text, out int maxNum))
            {

                MessageBox.Show("取值范围不能为空集", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }//检测是否为数字

            int aN = int.Parse(this.maxNUM.Text);
            int iN = int.Parse(this.minNUM.Text);


            if (string.IsNullOrWhiteSpace(minNUM.Text) || string.IsNullOrWhiteSpace(maxNUM.Text))
            {
                MessageBox.Show("请输入有效内容（不能为空或纯空格）", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);
                minNUM.Text = "1";
                maxNUM.Text = "40";
            }//检测是否为空集
            if (aN <= iN)
            {
                MessageBox.Show("取值范围出现错误！", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }//检测取值范围是否正确

            int num = new Random().Next(iN, aN + 1);
            output.Text = num.ToString();
            //生成随机数并输出
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(appDir, "set1.hcy");
            string set1 = File.ReadAllText(filePath, System.Text.Encoding.UTF8).Trim();
            if (set1 == "True")
            {

            }
            else
            {
                
            }
            ;


        }


        private void Opensetting_Click(object sender, RoutedEventArgs e)
        {
            // 显示Frame并导航到设置页面
            MainContent.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new LoginPage());
        }

        // 添加导航到主页面的方法（从登录页面和设置页面调用）    
        public void NavigateToMain()
        {
            MainFrame.Visibility = Visibility.Collapsed;
            MainContent.Visibility = Visibility.Visible;
        }


        private void Githubopen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://github.com/3wdjyecom/28Class5random";
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            finally
            {
                // No cleanup required
            }
            ;
        }

    }

}