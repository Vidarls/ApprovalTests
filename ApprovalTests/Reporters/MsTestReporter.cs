using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class MsTestReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			string assertClass = " Microsoft.VisualStudio.TestTools.UnitTesting.Assert, Microsoft.VisualStudio.QualityTools.UnitTestFramework";
			NUnitReporter.AssertFileContents(approved, received, assertClass);
		}
	}
}
