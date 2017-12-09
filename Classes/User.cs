using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class User
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int championshipId;
        public int ChampionshipId
        {
            get { return championshipId; }
            set { championshipId = value; }
        }
        public User(string login, string password, int champId)
        {
            this.Login = login;
            this.Password = password;
            this.ChampionshipId = champId;
        }
    }
}
