using System.Numerics;

namespace JobBee.Shared.Ultils;

public static class DateConverter
{
	public static BigInteger ConvertToTime(this DateTime dateTime)
	{
		DateTime utcDateTime = dateTime.ToUniversalTime();

		DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		TimeSpan timeSpan = utcDateTime - unixEpoch;
		long seconds = (long)timeSpan.TotalSeconds;

		return new BigInteger(seconds);
	}

	public static BigInteger ConvertToTime(this DateOnly date)
	{
		// Chuyển DateOnly thành DateTime lúc 00:00:00
		DateTime dateTime = date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

		// Epoch
		DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Tính số giây kể từ Epoch
		TimeSpan timeSpan = dateTime - unixEpoch;
		long seconds = (long)timeSpan.TotalSeconds;

		return new BigInteger(seconds);
	}

	public static DateTime ConvertToDateTime(this BigInteger time)
	{
		DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		long seconds = (long)time;

		return unixEpoch.AddSeconds(seconds);
	}

	public static DateOnly ConvertToDate(this BigInteger time)
	{
		if (time < 0 || time > long.MaxValue)
		{
			return DateOnly.MinValue;
		}
		return DateOnly.FromDateTime(DateTime.UnixEpoch.AddSeconds((long)time));
	}
}