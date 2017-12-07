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
using Classes;

namespace Football_Championship_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            GridRegistration.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            //Добавить нового пользователя
            GridRegistration.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            GridEnter.Visibility = Visibility.Hidden;
            GridRegistration.Visibility = Visibility.Visible;
        }

        private void ButtonSettingsBack_Click(object sender, RoutedEventArgs e)
        {
            GridSettings.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonSettingsOK_Click(object sender, RoutedEventArgs e)
        {
            //logic for settings
            if (RadioButton60sec.IsChecked==false && RadioButton90sec.IsChecked==false && RadioButton180sec.IsChecked==false)
            {
                MessageBox.Show("Choose one of the possible time", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (RadioButton1Level.IsChecked==false && RadioButton2Level.IsChecked==false && RadioButton3Level.IsChecked==false && RadioButton4Level.IsChecked==false)
            {
                MessageBox.Show("Choose one of the possible level", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Settings settings = new Settings();
            GridSettings.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            GridEnter.Visibility = Visibility.Hidden;
            GridSettings.Visibility = Visibility.Visible;
        }   
    }
}
