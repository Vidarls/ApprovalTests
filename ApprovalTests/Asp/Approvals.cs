using System;
using System.Net;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Asp
{
	public static class Approvals
	{
		public static void ApproveAspPage(Action testMethod)
		{
			var url = GetUrl(testMethod, "http://localhost:1359");
			ApproveUrl(url);
		}

		private static string GetUrl(Action testMethod, string host)
		{
			var type = testMethod.Method.DeclaringType;
			var clazz = type.Name;
			var path = type.Namespace.Substring(type.Assembly.GetName().Name.Length);
			path = path.Replace('.', '/');
			var method = testMethod.Method.Name;
			return "{0}{1}/{2}.aspx?{3}".FormatWith(host, path, clazz, method);
		}

		public static void ApproveUrl(string url)
		{
			try
			{
				using (var client = new WebClient())
				{
					var baseUrl = url.Substring(0, url.LastIndexOf("/"));
					var html = client.DownloadString(url);
					if (!html.Contains("<base"))
					{
						html = html.Replace("<head>", "<head><base href=\"{0}\">".FormatWith(baseUrl));
					}
					Html.Approvals.ApproveHtml(html);
				}
			}
			catch (Exception e)
			{
				throw new Exception(
					"The following error occured while connecting to:\r\n{0}\r\nError:\r\n{1}".FormatWith(url, e.Message), e);
			}
		}
	}
}