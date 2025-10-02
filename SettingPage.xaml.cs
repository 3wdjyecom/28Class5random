using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace �����
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
                e.Handled = true; // ��ֹ����
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(avoid))
            {
                MessageBox.Show("������Ҫ�ܿ�������", "28��5��ר�ó����", MessageBoxButton.OK, MessageBoxImage.Error);
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


                // ʹ�� taskkill ǿ�ƽ�������ֹ����
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
                MessageBox.Show($"����ʧ��: {ex.Message}");
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
                MessageBox.Show($"? ������Դ������ʧ��: {ex.Message}", "����", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            // �޸�������������ڵĵ�������
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
                string displayText = selectedItem.Content.ToString();  // ��ʾ�ı���"ѡ��1"
                string value = selectedItem.Tag?.ToString();

                if (value == "True")  // ������ʹ�� == ������ =�����������
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
                else  // ��� else ��֧
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
                        MessageBox.Show($"д���ļ�ʱ����: {ex.Message}");
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

