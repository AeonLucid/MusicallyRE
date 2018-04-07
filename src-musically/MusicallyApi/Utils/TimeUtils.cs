using System;

namespace MusicallyApi.Utils
{
    public static class TimeUtils
    {
        private static string _timeZone;

        public static string TimeZone
        {
            get
            {
                if (string.IsNullOrEmpty(_timeZone))
                {
                    _timeZone = TimeZoneInfo.Local.DisplayName.Substring(1).Split(new []{')'}, 2)[0];
                }

                return _timeZone;
            }
        }
    }
}
