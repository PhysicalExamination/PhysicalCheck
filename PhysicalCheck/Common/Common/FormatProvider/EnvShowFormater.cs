using System;
using System.Collections;

namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:数字日期显示格式化工具
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	/// 	
	delegate string GetNumberStringHandler(Object value);
	delegate string GetCurrencyStringHandler(Object value);


	public sealed class EnvShowFormater
	{
		private static IEnvFormatProvider m_NumberFormatProvider;
		private static IEnvFormatProvider m_DateFormatProvider;
		private static Hashtable m_NumberConvertMethods;
		private static Hashtable m_CurrencyConvertMethods;



		static  EnvShowFormater()
		{
			m_NumberConvertMethods = new Hashtable();
			m_NumberConvertMethods.Add(typeof(double),new GetNumberStringHandler(GetDoubleString));
			m_NumberConvertMethods.Add(typeof(decimal),new GetNumberStringHandler(GetDecimalString));
			m_NumberConvertMethods.Add(typeof(Int16),new GetNumberStringHandler(GetInt16String));
			m_NumberConvertMethods.Add(typeof(Int32),new GetNumberStringHandler(GetInt32String));
			m_NumberConvertMethods.Add(typeof(Int64),new GetNumberStringHandler(GetInt64String));
			m_NumberConvertMethods.Add(typeof(float),new GetNumberStringHandler(GetFloatString));
			m_NumberConvertMethods.Add(typeof(ushort),new GetNumberStringHandler(GetUShortString));
			m_NumberConvertMethods.Add(typeof(ulong),new GetNumberStringHandler(GetULongString));
			m_NumberConvertMethods.Add(typeof(uint),new GetNumberStringHandler(GetUIntString));

			m_CurrencyConvertMethods = new Hashtable();
			m_CurrencyConvertMethods.Add(typeof(double),new GetCurrencyStringHandler(GetDoubleCurrencyString));
			m_CurrencyConvertMethods.Add(typeof(decimal),new GetCurrencyStringHandler(GetDecimalCurrencyString));
			m_CurrencyConvertMethods.Add(typeof(Int16),new GetCurrencyStringHandler(GetInt16CurrencyString));
			m_CurrencyConvertMethods.Add(typeof(Int32),new GetCurrencyStringHandler(GetInt32CurrencyString));
			m_CurrencyConvertMethods.Add(typeof(Int64),new GetCurrencyStringHandler(GetInt64CurrencyString));
			m_CurrencyConvertMethods.Add(typeof(float),new GetCurrencyStringHandler(GetFloatCurrencyString));
			m_CurrencyConvertMethods.Add(typeof(ushort),new GetCurrencyStringHandler(GetUshortCurrencyString));
			m_CurrencyConvertMethods.Add(typeof(ulong),new GetCurrencyStringHandler(GetULongCurrencyString));
			m_CurrencyConvertMethods.Add(typeof(uint),new GetCurrencyStringHandler(GetUintCurrencyString));

			m_NumberFormatProvider = FormatManager.GetFormatProvider();
			m_DateFormatProvider = FormatManager.GetFormatProvider("DateTimeFormatProvider");
		}		

		#region Number
		
		#region Public Methods

		public static string GetNumberString(Double? value)
		{
            if (value == null) return "";
			return value.Value.ToString("n",m_NumberFormatProvider);
		}
		public static string GetNumberString(Decimal? value)
		{
            if (value == null) return "";
			return value.Value.ToString("n",m_NumberFormatProvider);
		}		
		public static string GetNumberString (System.Int16? value)
		{
            if (value == null) return "";
			return value.Value.ToString("g",m_NumberFormatProvider);
		}
		public static string GetNumberString (System.Int32? value)
		{
            if (value == null) return "";
            return value.Value.ToString("g", m_NumberFormatProvider);
		}
		public static string GetNumberString (System.Int64? value)
		{
            if (value == null) return "";
            return value.Value.ToString("g", m_NumberFormatProvider);
		}
		public static string GetNumberString (float? value)
		{
            if (value == null) return "";
            return value.Value.ToString("n", m_NumberFormatProvider);
		}	
		
		public static string GetNumberString(ushort? value)
		{
            if (value == null) return "";
            return value.Value.ToString("g", m_NumberFormatProvider);
		}

		public static string GetNumberString(ulong? value)
		{
            if (value == null) return "";
            return value.Value.ToString("g", m_NumberFormatProvider);
		}

		public static string GetNumberString(uint? value)
		{
            if (value == null) return "";
            return value.Value.ToString("g", m_NumberFormatProvider);
		}

		public static string GetNumberString(object value)
		{			
			if (value == null) return string.Empty;
			GetNumberStringHandler handler = (GetNumberStringHandler)m_NumberConvertMethods[value.GetType()];
			if (handler!=null)			
				return handler(value);
			else
				return value.ToString();
		}

		#endregion 

		#region Private Methods

		private static  string GetDoubleString(Object value)
		{
            if (value == null) return "";
			Double val = (Double) value;
			return val.ToString("n",m_NumberFormatProvider);
		}
		private static string GetDecimalString(Object value)
		{
            if (value == null) return "";
			Decimal val = (Decimal) value;
			return val.ToString("n",m_NumberFormatProvider);
		}		
		private static string GetInt16String (Object value)
		{
            if (value == null) return "";
			Int16 val = (Int16) value;
			return val.ToString("g",m_NumberFormatProvider);
		}
		private static string GetInt32String (Object value)
		{
            if (value == null) return "";
			Int32 val = (Int32) value;
			return val.ToString("g",m_NumberFormatProvider);
		}
		private static string GetInt64String (Object value)
		{
            if (value == null) return "";
			Int64 val = (Int64) value;
			return val.ToString("g",m_NumberFormatProvider);
		}
		private static string GetFloatString (Object value)
		{
            if (value == null) return "";
			float val = (float) value;
			return val.ToString("n",m_NumberFormatProvider);
		}	
		
		private static string GetUShortString(Object value)
		{
            if (value == null) return "";
			ushort val = (ushort) value;
			return val.ToString("g",m_NumberFormatProvider);
		}

		private static string GetULongString(Object value)
		{
            if (value == null) return "";
			ulong val = (ulong) value;
			return val.ToString("g",m_NumberFormatProvider);
		}

		private static string GetUIntString(Object value)
		{
            if (value == null) return "";
			uint val = (uint) value;
			return val.ToString("g",m_NumberFormatProvider);
		}
		

		#endregion

		#endregion

		#region Currency

		#region Public Methods
		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString(Double? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString(Decimal? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);		
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString (System.Int16? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString (System.Int32? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString (System.Int64? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCurrencyString (float? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		public static string GetCurrencyString(ushort? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		public static string GetCurrencyString(ulong? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		public static string GetCurrencyString(uint? value)
		{
            if (value == null) return "";
			return value.Value.ToString("c",m_NumberFormatProvider);
		}

		public static string GetCurrencyString(Object value)
		{
			if (value == null) return string.Empty;
			GetCurrencyStringHandler handler = (GetCurrencyStringHandler)m_CurrencyConvertMethods[value.GetType()];
			if (handler != null)
				return handler(value);			
			else
				return value.ToString();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetDoubleCurrencyString(Object value)
		{
            if (value == null) return "";
			Double val = (Double)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetDecimalCurrencyString(Object value)
		{
            if (value == null) return "";
			Decimal val = (Decimal)value;
			return val.ToString("c",m_NumberFormatProvider);		
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetInt16CurrencyString (Object value)
		{
            if (value == null) return "";
			Int16 val = (Int16)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetInt32CurrencyString (Object value)
		{
            if (value == null) return "";
			Int32 val = (Int32)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetInt64CurrencyString (Object value)
		{
            if (value == null) return "";
			Int64 val = (Int64)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回货币值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetFloatCurrencyString (Object value)
		{
            if (value == null) return "";
			float val = (float)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		public static string GetUshortCurrencyString(Object value)
		{
            if (value == null) return "";
			uint val  = (ushort)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		public static string GetULongCurrencyString(Object value)
		{
			ulong val  = (ulong)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		public static string GetUintCurrencyString(Object value)
		{
            if (value == null) return "";
			uint val  = (uint)value;
			return val.ToString("c",m_NumberFormatProvider);
		}

		#endregion

		#endregion

		#region Percent

		
		public static string GetPercentString(Double? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString(System.Decimal? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}		

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (System.Int16? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (System.Int32? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (System.Int64? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (float? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}	

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (ushort? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (ulong? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (uint? value)
		{
            if (value == null) return "";
			return value.Value.ToString("P",m_NumberFormatProvider);
		}

		/// <summary>
		/// 返回百分值格式化字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetPercentString (Object value)
		{
            if (value == null) return "";
            decimal d = Convert.ToDecimal(value);
            return d.ToString("P", m_NumberFormatProvider);	
            //return -1;
		}

		#endregion

		#region DateTime

		/// <summary>
		/// 返回短日期值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetShortDate(DateTime? value)
		{
            if (value == null) return "";
			return value.Value.ToString("d",m_DateFormatProvider);
		}

		public static string GetShortDate(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime)value;
			return val.ToString("d",m_DateFormatProvider);
		}

		/// <summary>
		/// 返回长日期值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetLongDate(DateTime? value)
		{
            if (value == null) return "";			
			return value.Value.ToString("D",m_DateFormatProvider);
		}

		public static string GetLongDate(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime)value;			
			return val.ToString("D",m_DateFormatProvider);
		}

		/// <summary>
		/// 返回长日期和长时间值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetFullDate(DateTime? value)
		{
            if (value == null) return "";
			return value.Value.ToString("F",m_DateFormatProvider);
		}

		public static string GetFullDate(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime)value;
			return val.ToString("F",m_DateFormatProvider);
		}
        
		/// <summary>
		/// 返回短时间值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetShortTime(DateTime? value)
		{
            if (value == null) return "";
			return value.Value.ToString("t",m_DateFormatProvider);
		}

		public static string GetShortTime(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime) value;
			return val.ToString("t",m_DateFormatProvider);
		}

		/// <summary>
		/// 返回长时间值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetLongTime(DateTime? value)
		{
            if (value == null) return "";
			return value.Value.ToString("t",m_DateFormatProvider);
		}		

		public static string GetLongTime(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime) value;
			return val.ToString("t",m_DateFormatProvider);
		}		

		/// <summary>
		/// 返回年份月份
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetYearMonth(DateTime? value)
		{
            if (value == null) return "";
			return value.Value.ToString("Y",m_DateFormatProvider);
		}

		public static string GetYearMonth(Object value)
		{
            if (value == null) return "";
			DateTime val = (DateTime)value;
			return val.ToString("Y",m_DateFormatProvider);
		}


		#endregion
		
	}
	
}
