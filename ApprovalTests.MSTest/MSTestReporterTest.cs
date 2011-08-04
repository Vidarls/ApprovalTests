using System;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalTests.MSTest
{
	[TestClass]
	public class MsTestReporterTest
	{
		[TestMethod]
		[UseReporter((typeof(MsTestReporter)))]
		public void TestReporter()
		{
			try
			{
				Approvals.Approve("Hello");
			}
			catch (AssertFailedException e)
			{
				Assert.AreEqual("Assert.AreEqual failed. Expected:<World>. Actual:<Hello>. ", e.Message);
			}
		}
	}
}
