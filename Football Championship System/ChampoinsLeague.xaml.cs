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
using System.Windows.Shapes;
using ServiceClasses;

namespace Football_Championship_System
{
    /// <summary>
    /// Interaction logic for Champoins_League.xaml
    /// </summary>
    public partial class Champoins_League : Window
    {
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public Champoins_League(int userId)
        {
            this.UserId = userId;
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            GridTeamInfo.Visibility = Visibility.Visible;
            GridPlayerInfo.Visibility = Visibility.Hidden;
            GridTopScorer.Visibility = Visibility.Hidden;
        }

        private void ButtonPlayerInfo_Click(object sender, RoutedEventArgs e)
        {
            GridPlayerInfo.Visibility = Visibility.Visible;
            GridTeamInfo.Visibility = Visibility.Hidden;
            GridTopScorer.Visibility = Visibility.Hidden;
        }

        private void ButtonTopScorer_Click(object sender, RoutedEventArgs e)
        {
            GridTopScorer.Visibility = Visibility.Visible;
            GridTeamInfo.Visibility = Visibility.Hidden;
            GridPlayerInfo.Visibility = Visibility.Hidden;
        }

        private void ButtonTeamInfoOK_Click(object sender, RoutedEventArgs e)
        {
            List<string> response = LINQStat.GetTeamInfo(UserId, TextBoxTeamInfo.Text);
            if (response==null)
            {
                MessageBox.Show("Incorrect team entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ListViewTeamInfo.ItemsSource = response;
            }
        }
    }
}
