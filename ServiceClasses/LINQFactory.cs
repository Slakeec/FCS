using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ServiceClasses
{
    public class LINQFactory
    {
        public static bool IsLogin(string login)
        {
            using (var context = new Context())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }
        public static bool IsLoginAndPassword(string login, string password)
        {
            using (var context = new Context())
            {
                string p = Hashing.HashPaswword(password);
                return context.Users.Any(u => u.Login == login && u.Password == p);
            }
        }
        public static bool HasACareer(string login)
        {
            using (var context = new Context())
            {
                int id = context.Users.First(u => u.Login == login).Id;
                return context.Teams.Any(t => t.UserId == id);
            }
        }
    }
}
