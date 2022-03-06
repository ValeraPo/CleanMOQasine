using AutoMapper;

namespace CleanMOQasine.API.Configurations
{
    public class TimeOnlyFromStringConverter : IValueConverter<string, TimeOnly>
    {
        public TimeOnly Convert(string sourceMember, ResolutionContext context)
        {
            var splitStrings = sourceMember.Split(':');
            var hours = Int32.Parse(splitStrings[0]);
            var minutes = Int32.Parse(splitStrings[1]);

            return new TimeOnly(hours, minutes);
        }
    }
}
