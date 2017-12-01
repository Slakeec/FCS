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
    }
}
