using System;

namespace AMEEInExcel
{
	static class CrossDomain
	{
		public static T CreateInMasterDomain<T>()
			where T : MarshalByRefObject
		{
			var masterDomain = GetMasterAppDomain();
			var type = typeof(T);
			var proxy = (T)masterDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
			return proxy;
		}

		static AppDomain GetMasterAppDomain()
		{
			foreach (var domain in AppDomainUtil.GetAppDomains())
			{
				var name = domain.FriendlyName;
				if (name.StartsWith("AMEEInExcel.vsto", StringComparison.OrdinalIgnoreCase))
					return domain;
			}
            throw new ApplicationException("Cannot find MasterAppDomain -> AMEEInExcel.vsto");
		}
	}
}
