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

    public static DateTime ConvertToDateTime(this BigInteger time)
    {
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        long seconds = (long)time;
        
        return unixEpoch.AddSeconds(seconds);
    }
}