using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClasses
{
    public class Hashing
    {
        public static string HashPaswword(string password)
        {
            long mod = 1000000009;
            long osn = 271;
            long st = 1;
            long ans = 1;
            for (int i=0; i<password.Length; i++)
            {
                int x = password[i];
                ans = (ans + x * st)%mod;
                st = (st * osn) % mod;
            }
            return ans.ToString();
        }
    }
}
