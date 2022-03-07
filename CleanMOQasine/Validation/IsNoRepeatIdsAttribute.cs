using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Validation
{
    public class IsNoRepeatIdsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is List<int>)
            {
                var listInt = (List<int>)value;
                listInt.Sort();
                var checkedElement = listInt[0];
                for (int i = 1; i < listInt.Count; i++)
                {
                    if (listInt[i] != checkedElement)
                        checkedElement = listInt[i];
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
