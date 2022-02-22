using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanMOQasine.Business.Configurations
{
    public class AuthOptions
    {
        public const string Issuer = "CleanMOQasine";
        public const string Audience = "Front";

        private const string _key = "hu1_vam_a_ne_nash_pa55word_ot_WiFi!posos1((";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()=> 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    }
}
