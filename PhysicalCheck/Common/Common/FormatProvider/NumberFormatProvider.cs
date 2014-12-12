using System;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
using System.Threading;


namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:数字 货币 百分数格式化提供者
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public class NumberFormatProvider:IEnvFormatProvider
	{
		private NumberFormatInfo m_NumberFormat;

		public NumberFormatProvider()
		{
			m_NumberFormat = new NumberFormatInfo();
		}

		#region IEnvFormatProvider 成员

		public void Initialize(System.Xml.XmlNode parameters)
		{			
			m_NumberFormat.CurrencyDecimalSeparator = parameters.Attributes.GetNamedItem("CurrencyDecimalSeparator").Value;
			m_NumberFormat.CurrencySymbol = parameters.Attributes.GetNamedItem("CurrencySymbol").Value;
			m_NumberFormat.CurrencyGroupSeparator = parameters.Attributes.GetNamedItem("CurrencyGroupSeparator").Value;
			m_NumberFormat.NumberGroupSeparator = parameters.Attributes.GetNamedItem("NumberGroupSeparator").Value;
			m_NumberFormat.NumberDecimalSeparator = parameters.Attributes.GetNamedItem("NumberDecimalSeparator").Value;

			string attrValue = parameters.Attributes.GetNamedItem("CurrencyDecimalDigits").Value;
			if (attrValue!=null&&attrValue!=string.Empty)
				m_NumberFormat.CurrencyDecimalDigits = int.Parse(attrValue);
			attrValue = parameters.Attributes.GetNamedItem("CurrencyNegativePattern").Value;
			if (attrValue!=null&&attrValue!=string.Empty)
			   m_NumberFormat.CurrencyNegativePattern = int.Parse(attrValue);
			attrValue = parameters.Attributes.GetNamedItem("CurrencyPositivePattern").Value;
			if (attrValue!=null&&attrValue!=string.Empty)
				m_NumberFormat.CurrencyPositivePattern = int.Parse(attrValue); 
			attrValue = parameters.Attributes.GetNamedItem("NumberNegativePattern").Value;
			if (attrValue!=null&&attrValue!=string.Empty)
				m_NumberFormat.NumberNegativePattern = int.Parse(attrValue);
			attrValue = parameters.Attributes.GetNamedItem("NumberDecimalDigits").Value;
			if (attrValue!=null&&attrValue!=string.Empty)
				m_NumberFormat.NumberDecimalDigits = int.Parse(attrValue);
		}

		#endregion

		#region IFormatProvider 成员

		public object GetFormat(Type formatType)
		{			
			return m_NumberFormat;
		}

		#endregion
	}
}

