namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TrendAttributes
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private string string_0;
        private DSkinChart.TimeSpanTypes timeSpanTypes_0;

        public TrendAttributes()
        {
            this.dateTime_0 = DateTime.Now;
            this.dateTime_1 = DateTime.Now;
            this.timeSpanTypes_0 = DSkinChart.TimeSpanTypes.Hour;
            this.string_0 = "hh:mm";
        }

        public TrendAttributes(DateTime Start, DateTime End, DSkinChart.TimeSpanTypes TimeSpan, string ValueFormat)
        {
            this.dateTime_0 = DateTime.Now;
            this.dateTime_1 = DateTime.Now;
            this.timeSpanTypes_0 = DSkinChart.TimeSpanTypes.Hour;
            this.string_0 = "hh:mm";
            this.Start = Start;
            this.End = End;
            this.TimeSpan = TimeSpan;
            this.ValueFormat = ValueFormat;
        }

        public TrendAttributes(string StartString, string EndString, DSkinChart.TimeSpanTypes TimeSpan, string ValueFormat)
        {
            this.dateTime_0 = DateTime.Now;
            this.dateTime_1 = DateTime.Now;
            this.timeSpanTypes_0 = DSkinChart.TimeSpanTypes.Hour;
            this.string_0 = "hh:mm";
            this.StartString = StartString;
            this.EndString = EndString;
            this.TimeSpan = TimeSpan;
            this.ValueFormat = ValueFormat;
        }

        [Category("DSkinChart"), Description("TrendChart End Time of XLabels\n趋势图的横坐标结束时间")]
        public DateTime End
        {
            get
            {
                return this.dateTime_1;
            }
            set
            {
                this.dateTime_1 = value;
            }
        }

        [Description("TrendChart End Time(string format) of XLabels\n趋势图的横坐标结束时间(字符串格式)"), Category("DSkinChart")]
        public string EndString
        {
            get
            {
                return this.dateTime_1.ToString();
            }
            set
            {
                this.dateTime_1 = DateTime.Parse(value);
            }
        }

        [Description("TrendChart Start Time of XLabels\n趋势图的横坐标起始时间"), Category("DSkinChart")]
        public DateTime Start
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
            }
        }

        [Category("DSkinChart"), Description("TrendChart Start Time(string format) of XLabels\n趋势图的横坐标起始时间(字符串格式)")]
        public string StartString
        {
            get
            {
                return this.dateTime_0.ToString();
            }
            set
            {
                this.dateTime_0 = DateTime.Parse(value);
            }
        }

        [Category("DSkinChart"), Description("TrendChart Time increase step of XLabels\n趋势图的横坐标步长(年，月，日，时，分，秒)")]
        public DSkinChart.TimeSpanTypes TimeSpan
        {
            get
            {
                return this.timeSpanTypes_0;
            }
            set
            {
                this.timeSpanTypes_0 = value;
            }
        }

        [Description("TrendChart Time increase step of XLabels\n趋势图的横坐标步长(年，月，日，时，分，秒)"), Category("DSkinChart")]
        public string ValueFormat
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

