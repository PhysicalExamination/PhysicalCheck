using System;
using System.Collections;
using System.Configuration;
using System.Xml;

namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:格式化提供者配置文件读取处理器
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public sealed class ProviderConfigHandler:IConfigurationSectionHandler
	{
		public ProviderConfigHandler()
		{			
		}
		#region IConfigurationSectionHandler 成员

		public object Create(object parent, object configContext, XmlNode section)
		{
			Hashtable providers = new Hashtable();
			XmlNodeList nodeList = section.SelectNodes("provider");
			try 
			{
				foreach(XmlNode node in nodeList) 
				{
					XmlProvider provider = new XmlProvider(node);
					if( providers.Contains(provider.ProviderName.ToLower()) )
					{
                        throw new ConfigurationErrorsException("provider重复");
					}
					providers.Add(provider.ProviderName.ToLower(), provider);
				}
			} 
			catch (XmlException xmlEx) 
			{
                throw new ConfigurationErrorsException(xmlEx.Message, xmlEx);
			} 
			catch (System.Reflection.TargetInvocationException tEx) 
			{
                throw new ConfigurationErrorsException(tEx.Message, tEx);
			} 
			catch (System.TypeLoadException tlEx) 
			{
                throw new ConfigurationErrorsException(tlEx.Message, tlEx);
			} 
			catch (System.IO.FileNotFoundException fnfEx) 
			{
                throw new ConfigurationErrorsException(fnfEx.Message, fnfEx);
			}     
			return providers;
		}

		#endregion
	}
}
