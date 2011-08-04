using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;

namespace MVCRequestTesting.Web
{
	public class TestASPAppHost : MarshalByRefObject
	{
		public override object InitializeLifetimeService()
		{
			// This tells the CLR not to surreptitiously 
			// destroy this object -- it's a singleton
			// and will live for the life of the appdomain
			return null;
		}

		public static TestASPAppHost GetHostRelativeToAssemblyPath(string relativePath)
		{
			string asmFilePath = new Uri(typeof(TestASPAppHost).Assembly.CodeBase).LocalPath;
			string asmPath = Path.GetDirectoryName(asmFilePath);
			string fullPath = Path.Combine(asmPath, relativePath);
			fullPath = Path.GetFullPath(fullPath);

			return GetHost(fullPath);
		}

		public static TestASPAppHost GetHost(string webRootPath)
		{
			var host = (TestASPAppHost)ApplicationHost.CreateApplicationHost(
			                           	typeof(TestASPAppHost),
			                           	"/test",
			                           	webRootPath);

			// Run a bogus request through the pipeline to wake up ASP.NET and initialize everything
			host.InitASPNET();

			return host;
		}

		public void InitASPNET()
		{
			HttpRuntime.ProcessRequest(new SimpleWorkerRequest("/default.aspx", "", new StringWriter()));
		}

		public string ExecuteMvcUrl(string url, string query)
		{
			var writer = new StringWriter();
			var request = new SimpleWorkerRequest(url, query, writer);
			var context = HttpContext.Current = new HttpContext(request);
			var contextBase = new HttpContextWrapper(context);
			var routeData = RouteTable.Routes.GetRouteData(contextBase);
			var routeHandler = routeData.RouteHandler;
			var requestContext = new RequestContext(contextBase, routeData);
			var httpHandler = routeHandler.GetHttpHandler(requestContext);
			httpHandler.ProcessRequest(context);
			context.Response.End();
			writer.Flush();
			return writer.GetStringBuilder().ToString();
		}

		public void Shutdown()
		{
			HttpRuntime.UnloadAppDomain();
		}
	}
}