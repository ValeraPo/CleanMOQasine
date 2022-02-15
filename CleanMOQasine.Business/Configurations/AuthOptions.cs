using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Configurations
{
    public class AuthOptions
    {
        public const string Issuer = "CleanMOQasine";
        public const string Audience = "Front";

        private const string _key = "mysupersecret_secretkey!123";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()=> 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    }
}
