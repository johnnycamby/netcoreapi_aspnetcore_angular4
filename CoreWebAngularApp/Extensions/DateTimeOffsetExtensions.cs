using System;

namespace CoreWebAngularApp.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetYears(this DateTimeOffset dateTimeOffset, DateTimeOffset? presentDate)
        {
            var currentDate = DateTime.UtcNow;

            if (presentDate != null)
            {
                currentDate = presentDate.Value.UtcDateTime;
            }

            var years = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(years))
            {
                years--;
            }

            return years;
        }
    }
}