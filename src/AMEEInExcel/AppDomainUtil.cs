using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AMEEInExcel
{
	static class AppDomainUtil
	{
		public static IEnumerable<AppDomain> GetAppDomains()
		{
			IntPtr enumHandle;

			var host = new mscoree.CorRuntimeHost();
			host.EnumDomains(out enumHandle);
			try
			{
				Object domain;
				do
				{
					host.NextDomain(enumHandle, out domain);
					if (domain != null)
						yield return (AppDomain)domain;
				}
				while (domain != null);
			}
			finally
			{
				host.CloseEnum(enumHandle);
				Marshal.ReleaseComObject(host);
			}
		}
	}
}
