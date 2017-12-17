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
using ServiceClasses;
using System.Media;
using System.IO;
namespace Football_Championship_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings settings;
        public Settings Setting
        {
            get { return settings; }
            set { settings = value; }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private SoundPlayer sp;

        public SoundPlayer SP
        {
            get { return sp; }
            set { sp = value; }
        }

        public MainWindow()
        {
            this.Setting = new Settings();
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
            if (textBoxRegistrationLogin.Text=="" || passwordBoxRegistration.Password=="" || passwordBoxConfirming.Password=="")
            {
                MessageBox.Show("Fill login and password fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (passwordBoxRegistration.Password!=passwordBoxConfirming.Password)
            {
                MessageBox.Show("You entered different passwords", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (var context = new Context())
            {
                context.Users.Add(new User(textBoxRegistrationLogin.Text, Hashing.HashPaswword(passwordBoxRegistration.Password)));
                context.SaveChanges();
            }
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
                return;
            }
            if (RadioButton1Level.IsChecked==false && RadioButton2Level.IsChecked==false && RadioButton3Level.IsChecked==false && RadioButton4Level.IsChecked==false)
            {
                MessageBox.Show("Choose one of the possible level", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int time = RadioButton60sec.IsChecked == true ? 60 : RadioButton90sec.IsChecked == true ? 90 : 180;
            int level = RadioButton1Level.IsChecked == true ? 1 : RadioButton2Level.IsChecked == true ? 2 : RadioButton3Level.IsChecked == true ? 3 : 4;
            this.Setting = new Settings(time, level);
            GridSettings.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            GridEnter.Visibility = Visibility.Hidden;
            GridSettings.Visibility = Visibility.Visible;
        }

        private void ButtonBackFromChoosing_Click(object sender, RoutedEventArgs e)
        {
            GridChoosingMyTeam.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;
        }

        private void ButtonOKFromChoosing_Click(object sender, RoutedEventArgs e)
        {
            if (ComboxTeams.SelectedIndex==-1)
            {
                MessageBox.Show("You haven't choosen a team", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //start game
            string myteam = ComboxTeams.SelectedValue.ToString();
            if (Championship.CreateChampionship(myteam, UserId)==false)
            {
                MessageBox.Show("Check your internet connection and restart program", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Champoins_League chp = new Champoins_League(UserId, Setting, SP);
            chp.ShowDialog();
            GridChoosingMyTeam.Visibility = Visibility.Hidden;
            GridEnter.Visibility = Visibility.Visible;

        }

        private void ButtomEnter_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text=="" || passwordBox.Password=="")//no login
            {
                MessageBox.Show("Enter login and password please", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (LINQFactory.IsLogin(textBoxLogin.Text)==false)
            {
                MessageBox.Show("You enter incorrect login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (LINQFactory.IsLoginAndPassword(textBoxLogin.Text, passwordBox.Password)==false)
            {
                MessageBox.Show("Your password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (LINQFactory.HasACareer(textBoxLogin.Text)) //has choosen a team
            {
                //start a game
                this.UserId = LINQFactory.GetUserIdByLogin(textBoxLogin.Text);
                Champoins_League chp = new Champoins_League(userId, Setting, SP);
                chp.ShowDialog();
            }
            else
            {
                this.UserId = LINQFactory.GetUserIdByLogin(textBoxLogin.Text);
                GridEnter.Visibility = Visibility.Hidden;
                GridChoosingMyTeam.Visibility = Visibility.Visible;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ComboxTeams.ItemsSource = new Repository().TeamNames;
            SP = new SoundPlayer(RandomMusic.GetRandomMusic());
            SP.Play();

        }

        private void ButtonMultyplayer_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayer mp = new MultiPlayer(SP);
            mp.Show();
        }
    }
}
