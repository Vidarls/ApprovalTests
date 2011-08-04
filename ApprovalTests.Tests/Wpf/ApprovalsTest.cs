using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Wpf
{
	[TestFixture]
	[UseReporter(typeof(ImageReporter))]
	public class ApprovalsTest
	{
		[Test]
		public void TestControlApproved()
		{
			//ApprovalTests.Wpf.Approvals.Approve(() => new Button {Background = Brushes.Blue});
		}

		[Test]
		//[Ignore("Currently not working with build system")]
		public void TestFormApproval()
		{
//			var button = new Button {Content = "Hello"};
//			var window = new Window {Content = button,Width=200,Height=200};
//			ApprovalTests.Wpf.Approvals.Approve(window);
		}
	}
}