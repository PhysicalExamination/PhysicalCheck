using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;


namespace DataAccess {

	public sealed class NHibernateHelper {

		private const string CurrentSessionKey = "nhibernate.current_session";
		private static readonly ISessionFactory sessionFactory;

		[ThreadStatic]
		private static Dictionary<string, ISession> dictionary = new Dictionary<string, ISession>();

		static NHibernateHelper() {
			sessionFactory = new Configuration().Configure().BuildSessionFactory();
		}

		public static ISession GetCurrentSession() {
			HttpContext context = HttpContext.Current;
			ISession currentSession = context.Items[CurrentSessionKey] as ISession;
			if (currentSession == null) {
				currentSession = sessionFactory.OpenSession();
				context.Items[CurrentSessionKey] = currentSession;
			}
			return currentSession;
			/*ISession currentSession;
			if (!dictionary.ContainsKey(CurrentSessionKey)) {
				currentSession = sessionFactory.OpenSession();
				dictionary.Add(CurrentSessionKey, currentSession);
			}
			else {
				currentSession = dictionary[CurrentSessionKey] as ISession;
			}
			return currentSession;*/
		}

		public static void CloseSession() {
			HttpContext context = HttpContext.Current;
			ISession currentSession = context.Items[CurrentSessionKey] as ISession;
			if (currentSession == null) {
				return;
			}
			currentSession.Close();
			context.Items.Remove(CurrentSessionKey);
			/*if (dictionary.Count == 0) return;
			ISession currentSession = dictionary[CurrentSessionKey] as ISession;
			if (currentSession == null) {
				return;
			}
			currentSession.Close();
			dictionary.Remove(CurrentSessionKey);*/
		}

		public static void CloseSessionFactory() {
			if (sessionFactory != null) {
				sessionFactory.Close();
			}
		}
	}
}
