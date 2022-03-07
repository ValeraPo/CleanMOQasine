using CleanMOQasine.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace CleanMOQasine.API.Validation
{
    public class IsNoRepeatDaysOfWeekAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is List<WorkingTimeInsertInputModel>)
            {
                var list = (List<WorkingTimeInsertInputModel>)value;
                if (list.Count>7)
                {
                    return false;
                }
                List<int> listDays = list.Select(d => d.Day).ToList();
                listDays.Sort();
                var checkedElement = listDays[0];
                for (int i = 1; i < listDays.Count; i++)
                {
                    if (listDays[i] != checkedElement)
                        checkedElement = listDays[i];
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
