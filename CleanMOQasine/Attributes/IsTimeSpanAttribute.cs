using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CleanMOQasine.API.Attributes
{
    public class IsTimeSpanAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex regex = new Regex(@"^(((0{1}|1{1})[0-9]{1})|(2{1}[0-3]{1}))+\:([0-5]{1}[0-9]{1})");
            string strValue = value as string;
            if (!regex.IsMatch(strValue))
            {
                return false;
            }
            return true;
        }
    }
}
