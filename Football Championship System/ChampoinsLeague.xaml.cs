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
using Classes;
using System.Windows.Forms;
using Football_Game;
using Football_Game;
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
        private Settings settings;
        public Settings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        public Champoins_League(int userId, Settings settings)
        {
            this.UserId = userId;
            this.Settings = settings;
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
                System.Windows.MessageBox.Show("Incorrect team entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ListViewTeamInfo.ItemsSource = response;
            }
        }

        private void ButtonTopScorersOK_Click(object sender, RoutedEventArgs e)
        {
            ListViewTopScorers.ItemsSource = LINQStat.GetTopScorers(UserId);
        }

        private void ButtonPlayerInfoOK_Click(object sender, RoutedEventArgs e)
        {
            List<string> response = LINQStat.GetPlayerInfo(UserId, TextBoxPlayerInfo.Text);
            if (response == null)
            {
                System.Windows.MessageBox.Show("Incorrect player entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ListViewPlayerInfo.ItemsSource = response;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxColorFirst.ItemsSource = (new Repository()).Colors;
            ComboBoxCOlorSecond.ItemsSource = (new Repository()).Colors;
            int round = LINQFactory.Round(UserId);
            if (round==Repository.Cnt)
            {
                ButtonStartGame.Content = "Tournament ended!";
                ButtonStartGame.IsEnabled = true;
            }
            ListViewTable.ItemsSource = Sorting.Sort(LINQFactory.GetTeamsByUser(UserId));
            ListViewResults.ItemsSource = LINQFactory.GetResults(UserId, LINQFactory.Round(UserId) - 1);
        }

        private void ButtonStartGame_Click(object sender, RoutedEventArgs e)
        {
            string color1 = ComboBoxColorFirst.SelectedIndex==-1 ? "" : ComboBoxColorFirst.SelectedValue.ToString();
            string color2 = ComboBoxCOlorSecond.SelectedIndex==-1? "" : ComboBoxCOlorSecond.SelectedValue.ToString();
            if (color1=="" || color2=="")
            {
                System.Windows.MessageBox.Show("Choose forms for the game", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int round = LINQFactory.Round(UserId);
            Match match = Championship.playRound(userId, round);
            //Game
            FootballGameForm f = new FootballGameForm(match.TeamName1, match.TeamName2, LINQFactory.GetNamesById(match.PlayersOne),
                                                     LINQFactory.GetNamesById(match.PlayersTwo), settings.Time, settings.Level, false,
                                                     match.ScorersOne, match.ScorersTwo, color1,color2);
            f.ShowDialog();
            match.ScorersOne = f.MyRep.ScoredFirstTeam;
            match.ScorersTwo = f.MyRep.ScoredSecondTeam;
            Championship.SaveMyMatch(match,round,userId);
            ListViewTable.ItemsSource = Sorting.Sort(LINQFactory.GetTeamsByUser(UserId));
            ListViewResults.ItemsSource = LINQFactory.GetResults(UserId, LINQFactory.Round(UserId) - 1);
        }
    }
}
