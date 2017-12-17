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
using Football_Game;
using GameFootball;
using Classes;
using ServiceClasses;
using System.Windows.Forms;
namespace Football_Championship_System
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        public MultiPlayer()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string name1 = ComboBoxFirstTeam.SelectedValue.ToString();
            string name2 = ComboBoxSecondTeam.SelectedValue.ToString();
            if (name1=="" || name2=="")
            {
                System.Windows.MessageBox.Show("Choose teams please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string form1 = ComboBoxColorFirst.SelectedValue.ToString();
            string form2 = ComboBoxColorSecond.SelectedValue.ToString();
            if (form1=="" || form2=="")
            {
                System.Windows.MessageBox.Show("Choose colors please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string t = ComboBoxTime.SelectedValue.ToString();
            if (t=="")
            {
                System.Windows.MessageBox.Show("Choose time please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<string> FirstScorers = new List<string>();
            List<string> SecondScorers = new List<string>();
            FootballGameForm f = new FootballGameForm(name1, name2, MultiPlayerServise.GetNames(MultiPlayerServise.GetSquadFromName(name1)),
                                      MultiPlayerServise.GetNames(MultiPlayerServise.GetSquadFromName(name2)), int.Parse(t), 0, true,FirstScorers, SecondScorers);
            f.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxFirstTeam.ItemsSource = (new Repository()).TeamNames;
            ComboBoxSecondTeam.ItemsSource = (new Repository()).TeamNames;
            ComboBoxColorFirst.ItemsSource = (new Repository()).Colors;
            ComboBoxColorSecond.ItemsSource = (new Repository()).Colors;
            ComboBoxTime.ItemsSource = (new Repository()).Time;
        }
    }
}
