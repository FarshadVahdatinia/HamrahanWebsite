using System;


namespace FarshadTools { 
    public static class DateExt
    {
        /// <summary>
        /// تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="date">تاریخ میلادی</param>
        /// <param name="seprator">جدا کننده</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToPersianDate(this DateTime date, char seprator = '/')
        {
            var pc = new System.Globalization.PersianCalendar();
            var year = pc.GetYear(date);
            var month = pc.GetMonth(date);
            var day = pc.GetDayOfMonth(date);
            return $"{year}{seprator}{month.ToString().PadLeft(2, '0')}{seprator}{day.ToString().PadLeft(2, '0')}";
        }

        



        /// <summary>
        /// تاریخ امروز به شمسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <param name="seprator">جدا کننده</param>
        /// <returns></returns>
        public static string Today(this DateTime date, char seprator = '/')
        {
            // Remove unused parameter 'date' if it is not part of a shipped public API"
            return DateTime.Now.ToPersianDate(seprator);
        }


        /// <summary>
        /// روز هفته فارسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static string ToPersianDayOfWeek(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "يكشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
                default:
                    return "";
            }
        }




    }
}
