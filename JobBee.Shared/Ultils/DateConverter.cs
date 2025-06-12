using System.Numerics;

namespace JobBee.Shared.Ultils;

public static class DateConverter
{
	public static long ConvertToTime(this DateTime dateTime)
	{
		DateTime utcDateTime = dateTime.ToUniversalTime();
		DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		TimeSpan timeSpan = utcDateTime - unixEpoch;
		return (long)timeSpan.TotalSeconds;
	}

	public static long ConvertToTime(this DateOnly date)
	{
		DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
		DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		TimeSpan timeSpan = dateTime.ToUniversalTime() - unixEpoch;
		return (long)timeSpan.TotalSeconds;
	}

	public static DateTime ConvertToDateTime(this long time)
	{
		DateTime utcDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(time);
		return DateTime.SpecifyKind(utcDateTime, DateTimeKind.Unspecified);
	}

	public static DateOnly ConvertToDate(this long time)
	{
		if (time < 0 || time > long.MaxValue)
		{
			return DateOnly.MinValue;
		}
		DateTime utcDateTime = DateTime.UnixEpoch.AddSeconds(time);
		return DateOnly.FromDateTime(DateTime.SpecifyKind(utcDateTime, DateTimeKind.Unspecified));
	}
}
