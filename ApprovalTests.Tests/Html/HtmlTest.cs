using NUnit.Framework;

namespace ApprovalTests.Tests.Html
{
	[TestFixture]

	public class HtmlTest
	{
		[Test]
		public static void TestHtml()
		{
			Approvals.ApproveHtml("<html><body><div>hi</div></body></html>");
		}
	}
}