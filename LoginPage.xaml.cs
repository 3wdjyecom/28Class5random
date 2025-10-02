using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace 抽号器
{
	public partial class LoginPage : Page
	{
		public LoginPage()
		{
			InitializeComponent();  // 确保这行存在且拼写正确
		}

		public void NavigateToMain()
		{
			SettingFrame.Visibility = Visibility.Collapsed;
			SettingContent.Visibility = Visibility.Visible;
		}

		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			string appDir = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(appDir, "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=.pwyy");
			string correctPassword = File.ReadAllText(filePath, System.Text.Encoding.UTF8).Trim();
			string password = passwordBox.Password;


			if (string.IsNullOrEmpty(password))
			{
				MessageBox.Show("请输入密码", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			string haxipw;
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = sha256.ComputeHash(inputBytes);
				haxipw = Convert.ToBase64String(hashBytes);
			}
			if (haxipw == correctPassword)
			{
				// 密码正确，直接进入主页面或设置页面
				SettingContent.Visibility = Visibility.Collapsed;
				SettingFrame.Visibility = Visibility.Visible;
				SettingFrame.Navigate(new SettingPage());
			}
			else
			{
				// 密码错误，显示登录页面
				MessageBox.Show("密码错误", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Error);
				passwordBox.Clear();
			}
		}

		private void ForgetButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MessageBox.Show("请联系breader获取密码", "28届5班专用抽号器", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			finally
			{
				// No cleanup required
			}
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.NavigateToMain();
            } 

        }
	}
}







