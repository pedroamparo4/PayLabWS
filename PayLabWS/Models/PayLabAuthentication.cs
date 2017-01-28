using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace PayLabWS.Models
{
    public class PayLabAuthentication
    {
        public PayLabAuthentication() { }

        public IEnumerable<Claim> Authenticate(string user, string password)
        {
            string _user = "paylab";
            string _password = "paylab_project@2017";
            string _userName = "Pedro Amparo";
            string _role = "admin";

            if (user == _user && password == _password)
            {
                return new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, _role),
                        new Claim("username", _user),
                        new Claim(ClaimTypes.Name, _userName)
                    };
            }
            return null;
        }

    }
}