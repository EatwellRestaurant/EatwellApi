namespace EatwellApi.Application.Extensions
{
    public static class DateTimeExtensions
    {
        static readonly TimeZoneInfo TurkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");


        public static DateTime ToTurkeyTime(this DateTime utcDateTime)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);


            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TurkeyTimeZone);
        }
    }
}
