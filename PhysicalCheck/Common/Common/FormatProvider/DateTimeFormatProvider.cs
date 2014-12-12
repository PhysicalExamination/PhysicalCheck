using System;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
using System.Threading;

namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:日期时间格式化提供者
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public class DateTimeFormatProvider:IEnvFormatProvider
	{
		private DateTimeFormatInfo m_DateTimeFormat;
		public DateTimeFormatProvider()
		{
			m_DateTimeFormat = new DateTimeFormatInfo();
		}

		#region IEnvFormatProvider 成员

		public void Initialize(System.Xml.XmlNode parameters)
		{
			m_DateTimeFormat.FullDateTimePattern = parameters.Attributes.GetNamedItem("FullDateTimePattern").Value.Trim();
			m_DateTimeFormat.ShortDatePattern = parameters.Attributes.GetNamedItem("ShortDatePattern").Value.Trim();
			m_DateTimeFormat.LongDatePattern = parameters.Attributes.GetNamedItem("LongDatePattern").Value.Trim();	
			m_DateTimeFormat.YearMonthPattern =parameters.Attributes.GetNamedItem("YearMonthPattern").Value.Trim();	 
		}

		#endregion

		#region IFormatProvider 成员

		public object GetFormat(Type formatType)
		{
			
			return m_DateTimeFormat;
		}

		#endregion
	}
}
