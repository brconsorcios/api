using System;
using System.Threading;

namespace exp.core
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     DateDiff in SQL style.
        ///     Datepart implemented:
        ///     "year" (abbr. "yy", "yyyy"),
        ///     "quarter" (abbr. "qq", "q"),
        ///     "month" (abbr. "mm", "m"),
        ///     "day" (abbr. "dd", "d"),
        ///     "week" (abbr. "wk", "ww"),
        ///     "hour" (abbr. "hh"),
        ///     "minute" (abbr. "mi", "n"),
        ///     "second" (abbr. "ss", "s"),
        ///     "millisecond" (abbr. "ms").
        /// </summary>
        /// <param name="DatePart"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static long Diff(this DateTime StartDate, string DatePart, DateTime EndDate)
        {
            long DateDiffVal = 0;
            var cal = Thread.CurrentThread.CurrentCulture.Calendar;
            var ts = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (DatePart.ToLower().Trim())
            {
                #region year

                case "year":
                case "yy":
                case "yyyy":
                    DateDiffVal = cal.GetYear(EndDate) - cal.GetYear(StartDate);
                    break;

                #endregion

                #region quarter

                case "quarter":
                case "qq":
                case "q":
                    DateDiffVal = (cal.GetYear(EndDate)
                                   - cal.GetYear(StartDate)) * 4
                                  + (cal.GetMonth(EndDate) - 1) / 3
                                  - (cal.GetMonth(StartDate) - 1) / 3;
                    break;

                #endregion

                #region month

                case "month":
                case "mm":
                case "m":
                    DateDiffVal = (cal.GetYear(EndDate)
                                   - cal.GetYear(StartDate)) * 12
                                  + cal.GetMonth(EndDate)
                                  - cal.GetMonth(StartDate);
                    break;

                #endregion

                #region day

                case "day":
                case "d":
                case "dd":
                    DateDiffVal = (long)ts.TotalDays;
                    break;

                #endregion

                #region week

                case "week":
                case "wk":
                case "ww":
                    DateDiffVal = (long)(ts.TotalDays / 7);
                    break;

                #endregion

                #region hour

                case "hour":
                case "hh":
                    DateDiffVal = (long)ts.TotalHours;
                    break;

                #endregion

                #region minute

                case "minute":
                case "mi":
                case "n":
                    DateDiffVal = (long)ts.TotalMinutes;
                    break;

                #endregion

                #region second

                case "second":
                case "ss":
                case "s":
                    DateDiffVal = (long)ts.TotalSeconds;
                    break;

                #endregion

                #region millisecond

                case "millisecond":
                case "ms":
                    DateDiffVal = (long)ts.TotalMilliseconds;
                    break;

                #endregion

                default:
                    throw new Exception(string.Format("DatePart \"{0}\" is unknown", DatePart));
            }

            return DateDiffVal;
        }

        public static DateTime AddWeekdays(this DateTime date, int days)
        {
            var sign = days < 0 ? -1 : 1;
            var unsignedDays = Math.Abs(days);
            var weekdaysAdded = 0;
            while (weekdaysAdded < unsignedDays)
            {
                date = date.AddDays(sign);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    weekdaysAdded++;
            }

            return date;
        }
    }
}