using System;
using System.Xml;


namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:格式化提供者配置信息存储器
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public class XmlProvider
	{
		#region 私有变量
		private string m_ProviderName;
		private Type m_Type;
		private XmlNode m_Properties;
		#endregion

		#region 构造函数
		public XmlProvider(XmlNode node)
		{
			m_ProviderName = node.Attributes.GetNamedItem("name").Value.Trim();
			string typeName = node.Attributes.GetNamedItem("type").Value.Trim();
			m_Type = Type.GetType(typeName,true, true);  
			m_Properties = node;
		}
		#endregion

		#region 属性
		public string ProviderName
		{
			get
			{
				return m_ProviderName;
			}
		}

		public Type ProviderType
		{
			get
			{
				return m_Type;
			}
		}

		public XmlNode Properties
		{
			get
			{ 
				return m_Properties;
			}
		}

		#endregion 
	}
}
