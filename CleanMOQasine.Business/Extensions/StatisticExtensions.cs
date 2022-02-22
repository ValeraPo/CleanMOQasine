namespace CleanMOQasine.Business.Extensions
{
    public  static class StatisticExtensions
    {
		public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
		{
			TimeSpan sumTillNowTimeSpan = TimeSpan.Zero;

			foreach (TimeSpan timeSpan in timeSpans)
			{
				sumTillNowTimeSpan += timeSpan;
			}

			return sumTillNowTimeSpan;
		}
	}
}
