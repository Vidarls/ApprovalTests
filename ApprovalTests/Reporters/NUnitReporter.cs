using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class NUnitReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			string assertClass = "NUnit.Framework.Assert, nunit.framework";
			AssertFileContents(approved, received, assertClass);
		}

		public static void AssertFileContents(string approved, string received, string assertClass)
		{
			var a = File.Exists(approved) ? File.ReadAllText(approved) : "";
			var r = File.ReadAllText(received);

			QuietReporter.DisplayCommandLineApproval(approved, received);
			try
			{
				Type.GetType(assertClass).InvokeMember("AreEqual",
				                                       BindingFlags.InvokeMethod | BindingFlags.Public |
				                                       BindingFlags.Static, null, null, new[] {a, r});
			}
			catch (TargetInvocationException e)
			{
				throw e.GetBaseException();
			}
		}
	}
}