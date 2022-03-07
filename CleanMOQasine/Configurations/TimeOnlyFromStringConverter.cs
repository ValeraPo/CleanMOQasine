using AutoMapper;

namespace CleanMOQasine.API.Configurations
{
    public class TimeOnlyFromStringConverter : IValueConverter<string, TimeOnly>, IValueConverter<TimeOnly, string>
    {
        public TimeOnly Convert(string sourceMember, ResolutionContext context)
        {
            var splitStrings = sourceMember.Split(':');
            var hours = Int32.Parse(splitStrings[0]);
            var minutes = Int32.Parse(splitStrings[1]);

            return new TimeOnly(hours, minutes);
        }

        public string Convert(TimeOnly sourceMember, ResolutionContext context)
        {
            var hour = sourceMember.Hour;
            var minute = sourceMember.Minute;
            var hourString = hour < 10 ? "0" + hour : hour.ToString();
            var minuteString = minute < 10 ? "0" + minute : minute.ToString();
            return hourString + ":" + minuteString;
        }
    }
}
