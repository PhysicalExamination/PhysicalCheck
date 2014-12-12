using System;
using System.Globalization;

namespace Common.FormatProvider
{
    /// <summary>
    /// ModuleName:将字符串转换为指定的数值类型
    /// Author：pyf
    /// Date：2005-05-27
    /// </summary>
    public sealed class EnvConverter
    {
        private static IEnvFormatProvider m_NumberFormatProvider;
        private static IEnvFormatProvider m_DateFormatProvider;

        #region Constructors

        static EnvConverter()
        {
            m_NumberFormatProvider = FormatManager.GetFormatProvider();
            m_DateFormatProvider = FormatManager.GetFormatProvider("DateTimeFormatProvider");
        }


        #endregion

        #region Number

        /// <summary>
        /// 将字符串转换成Int16
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int16? ToInt16(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return Int16.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成Int32
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int32? ToInt32(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return Int32.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成Int64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int64? ToInt64(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return Int64.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float? ToFloat(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return float.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 将字符串转换成double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double? ToDouble(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return double.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return decimal.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成short
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static short? ToShort(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return short.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换成ushort
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ushort? ToUshor(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return ushort.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }            
        }

        /// <summary>
        /// 将字符串转换成long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long? ToLong(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return long.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }            
        }

        /// <summary>
        /// 将字符串转换成ulong
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ulong? ToUlong(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return ulong.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }
            
        } 

        /// <summary>
        /// 将字符串转换成uint
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uint? ToUint(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return uint.Parse(s, NumberStyles.Any, m_NumberFormatProvider);
            }
            catch
            {
                return null;
            }           
        }

        #endregion

        #region DateTime

        public static DateTime? ToDateTime(string s)
        {
            if (string.IsNullOrEmpty(s.Trim())) return null;
            try
            {
                return DateTime.Parse(s, m_DateFormatProvider, DateTimeStyles.AllowWhiteSpaces);
            }
            catch
            {
                return null;
            }            
        }

        #endregion
    }
}
