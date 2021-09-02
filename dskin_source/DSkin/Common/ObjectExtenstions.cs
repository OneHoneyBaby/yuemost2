namespace DSkin.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ObjectExtenstions
    {
        public static string FormatDateTime(this object data, string format)
        {
            if (data != null)
            {
                DateTime time;
                if (DateTime.TryParse(data.ToString(), out time))
                {
                    return time.ToString(format);
                }
                return data.ToString();
            }
            return string.Empty;
        }

        public static string FormatNumber(this object data, string format)
        {
            if (data != null)
            {
                double num;
                if (double.TryParse(data.ToString(), out num))
                {
                    num.ToString(format);
                }
                return data.ToString();
            }
            return string.Empty;
        }

        public static string FormatString(this object data, string format)
        {
            if (data != null)
            {
                return string.Format(format, data);
            }
            return string.Empty;
        }

        public static bool ToBool(this object data)
        {
            if (data is bool)
            {
                return (bool) data;
            }
            bool result = false;
            if (data != null)
            {
                bool.TryParse(data.ToString(), out result);
            }
            return result;
        }

        public static DateTime ToDateTime(this object data)
        {
            if (data is DateTime)
            {
                return (DateTime) data;
            }
            DateTime result = new DateTime();
            if (data != null)
            {
                DateTime.TryParse(data.ToString(), out result);
            }
            return result;
        }

        public static double ToDouble(this object data)
        {
            if (data is double)
            {
                return (double) data;
            }
            double result = 0.0;
            if (data != null)
            {
                double.TryParse(data.ToString(), out result);
            }
            return result;
        }

        public static T ToEnum<T>(this object data, T defaultValue)
        {
            if (data is T)
            {
                return (T) data;
            }
            if ((data != null) && (data.ToString() != string.Empty))
            {
                try
                {
                    return (T) Enum.Parse(typeof(T), data.ToString());
                }
                catch (Exception)
                {
                }
            }
            return defaultValue;
        }

        public static float ToFloat(this object data)
        {
            if (data is float)
            {
                return (float) data;
            }
            float result = 0f;
            if (data != null)
            {
                float.TryParse(data.ToString(), out result);
            }
            return result;
        }

        public static int ToInt(this object data)
        {
            return data.ToInt(0);
        }

        public static int ToInt(this object data, int errorResult)
        {
            if (data is int)
            {
                return (int) data;
            }
            int result = errorResult;
            if ((data != null) && !int.TryParse(data.ToString(), out result))
            {
                result = errorResult;
            }
            return result;
        }

        public static long ToLong(this object data)
        {
            if (data is long)
            {
                return (long) data;
            }
            long result = 0L;
            if (data != null)
            {
                long.TryParse(data.ToString(), out result);
            }
            return result;
        }
    }
}

