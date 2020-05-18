using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Kevsoft.Ssml
{
    public class FluentFluentSayDate : FluentSsml, IFluentSayDate, ISsmlWriter
    {
        private DateFormat _dateFormat;
        private readonly DateTime _date;

        public FluentFluentSayDate(ISsml ssml, DateTime date)
            : base(ssml)
        {
            _date = date;
        }

        public ISsml As(DateFormat dateFormat)
        {
            _dateFormat = dateFormat;

            return this;
        }

        public async Task WriteAsync(XmlWriter writer)
        {
            var format = DateFormatMap[_dateFormat];
            var date = FormatDate(_date, _dateFormat);

            var sayAsWriter = new SayAsWriter("date", format, date);

            await sayAsWriter.WriteAsync(writer)
                .ConfigureAwait(false);
        }

        private static string FormatDate(DateTime date, DateFormat dateFormat)
        {
            var stringFormat = DateFormatToDateTimeFormatString[dateFormat];

            return date.ToString(stringFormat);
        }

        private static readonly IReadOnlyDictionary<DateFormat, string> DateFormatToDateTimeFormatString =
            new Dictionary<DateFormat, string>()
            {
                {DateFormat.NotSet, "yyyy-MM-dd"},
                {DateFormat.MonthDayYear, "MM/dd/yyyy"},
                {DateFormat.DayMonthYear, "dd/MM/yyyy"},
                {DateFormat.YearMonthDay, "yyyy/MM/dd"},
                {DateFormat.MonthDay, "MM-dd"},
                {DateFormat.DayMonth, "dd/MM"},
                {DateFormat.YearMonth, "yyyy-MM"},
                {DateFormat.MonthYear, "MM/yyyy"},
                {DateFormat.Day, "dd"},
                {DateFormat.Month, "MM"},
                {DateFormat.Year, "yyyy"}
            };

        private static readonly IReadOnlyDictionary<DateFormat, string> DateFormatMap =
            new Dictionary<DateFormat, string>()
            {
                {DateFormat.NotSet, null},
                {DateFormat.MonthDayYear, "mdy"},
                {DateFormat.DayMonthYear, "dmy"},
                {DateFormat.YearMonthDay, "ymd"},
                {DateFormat.MonthDay, "md"},
                {DateFormat.DayMonth, "dm"},
                {DateFormat.YearMonth, "ym"},
                {DateFormat.MonthYear, "my"},
                {DateFormat.Day, "d"},
                {DateFormat.Month, "m"},
                {DateFormat.Year, "y"}
            };
    }
}