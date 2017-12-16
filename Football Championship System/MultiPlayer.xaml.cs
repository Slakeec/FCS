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
            List<string> FirstScorers = new List<string>();
            List<string> SecondScorers = new List<string>();
            FootballGameForm f = new FootballGameForm(name1, name2, MultiPlayerServise.GetNames(MultiPlayerServise.GetSquadFromName(name1)),
                                      MultiPlayerServise.GetNames(MultiPlayerServise.GetSquadFromName(name2)), int.Parse(ComboBoxTime.SelectedValue.ToString()), 0, true,FirstScorers, SecondScorers);
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
