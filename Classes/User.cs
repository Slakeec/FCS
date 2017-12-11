using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
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
      
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            
        }
        public User()
        {

        }
    }
}
