using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
namespace EnFiveSales.Helper
{
    public static class SessionHelper
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static void ClearEverything()
        {
            AppSettings.Clear();
        }

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
        }

        public static string FullName
        {
            get => AppSettings.GetValueOrDefault(nameof(FullName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(FullName), value);
        }

        /// <summary>
        /// Gets the 12:00:00 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the 11:59:59 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }

    }
}