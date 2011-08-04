using ApprovalTests.Core;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	[UseReporter(typeof (MyReporter2))]
	public class ReporterFactoryTest
	{
		[Test]
		public void TestClassLevel()
		{
			Assert.AreEqual(typeof (MyReporter2), Approvals.GetReporter().GetType());
		}

		[Test]
		[UseReporter(typeof (MyReporter))]
		public void TestMethodOverride()
		{
			Assert.AreEqual(typeof (MyReporter), Approvals.GetReporter().GetType());
		}
	}


	public class MyReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}

	}

	public class MyReporter2 : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}

	}
}