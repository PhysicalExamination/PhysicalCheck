using System;
using System.Security.Permissions;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Common.FormatProvider
{
	/// <summary>
	/// ModuleName:格式化提供管理器
	/// Author:pyf
	/// Date:2005-05-26
	/// </summary>
	public sealed class FormatManager
	{
		private static IEnvFormatProvider  m_Instance = null;
		private FormatManager()
		{}

		public static IEnvFormatProvider GetFormatProvider()
		{
			if (object.Equals(m_Instance,null))
			{
				m_Instance = GetProvider("FormatProviders","NumberProvider");
			}
			return m_Instance;
		}

		public static IEnvFormatProvider GetFormatProvider(string providerName)
		{
			return GetProvider("FormatProviders",providerName);		
		}

		[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
		private static IEnvFormatProvider GetProvider(String configSection, string providerName)
		{
			String nameOfProviderToFetch = providerName.ToLower(System.Globalization.CultureInfo.CurrentCulture);
			//ConfigurationSettings.GetConfig(configSection);
            IDictionary providers = ConfigurationManager.GetSection(configSection) as IDictionary;
			
			if (providers == null) 
			{
                throw new ConfigurationErrorsException("配置文件有误");
			}
			XmlProvider provider = providers[nameOfProviderToFetch] as XmlProvider;
			if (provider == null) 
			{
                throw new ConfigurationErrorsException("没有所要求的Provider");
			}
			
			try 
			{
				IEnvFormatProvider providerType = Activator.CreateInstance(provider.ProviderType) as IEnvFormatProvider;
				
				if (providerType == null) 
				{
                    throw new ConfigurationErrorsException("无法创建provider");
				}
				providerType.Initialize(provider.Properties);
				return providerType;
			} 
			catch (TargetInvocationException tiEx) 
			{
                throw new ConfigurationErrorsException(tiEx.Message, tiEx);
			}			
		}
	}
}
