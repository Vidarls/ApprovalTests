using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	public class NUnitReporterTest
	{
		[Test]
		[UseReporter((typeof (NUnitReporter)))]
		public void TestReporter()
		{
			try
			{
				Approvals.Approve("Hello");
			}
			catch (AssertionException e)
			{
				Assert.AreEqual("  String lengths are both 5. Strings differ at index 0.\r\n  Expected: \"World\"\r\n  But was:  \"Hello\"\r\n  -----------^\r\n", e.Message);
			}
		}
		
	}
}