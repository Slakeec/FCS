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
    /// Interaction logic for SendToEmail.xaml
    /// </summary>
    public partial class SendToEmail : Window
    {
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public SendToEmail(int score)
        {
            this.Score = score;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            EmailSender.SendEmail(TextBoxEmail.Text, Score);
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
