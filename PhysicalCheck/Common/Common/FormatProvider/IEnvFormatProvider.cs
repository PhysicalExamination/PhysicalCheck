using System;
using System.Xml;

namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:���и�ʽ���ṩ�߽ӿ�
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public interface IEnvFormatProvider:IFormatProvider
	{
//		string  ProviderName
//		{
//			get;
//			set;
//		}
//		Type  ProviderType
//		{
//			get;
//			set;
//		}
//		XPathNavigator Properties
//		{
//			get;
//			set;
//		}
		void Initialize(XmlNode parameters);
	}
}
