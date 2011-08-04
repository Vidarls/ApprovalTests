using System.Drawing;
using System.Windows.Forms;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.WinForms
{
	[TestFixture]
  [UseReporter(typeof(BeyondCompareReporter))]
	public class ApprovalsTest
	{
		[Test]
		public void TestControlApproved()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Button {BackColor = Color.Blue, Text = "Help"});
		}

		[Test]
		public void TestFormApproval()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Form());
		}
	}
}