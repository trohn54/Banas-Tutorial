using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BanasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string usersName = "";
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Hello World";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The app is closing");
            this.Close();
        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            //usersName = UsersName.Text;

            MessageBox.Show("Hello " + usersName);
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
        }

        private void MenuFontTimes_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Times New Roman");
        }

        private void MenuFontCourier_Click(object sender, RoutedEventArgs e)
        {
            menuFontTimes.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Courier");
        }

        private void MenuFontArial_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontTimes.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Arial");
        }

        private bool comboFSClosed = true;

        private void ComboFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboFSClosed)
            {
                ChangeTBFontSize();
                comboFSClosed = true;
            }
        }

        private void ComboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboFSClosed = !comboBox.IsDropDownOpen;
            ChangeTBFontSize();
        }

        private void ChangeTBFontSize()
        {
            string fontSize = ComboFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);

            switch(fontSize)
            {
                case "10":
                    txtBoxDoc.FontSize = 10;
                    break;
                case "12":
                    txtBoxDoc.FontSize = 12;
                    break;
                case "14":
                    txtBoxDoc.FontSize = 14;
                    break;
                case "16":
                    txtBoxDoc.FontSize = 16;
                    break;
            }
        }
    }
}
