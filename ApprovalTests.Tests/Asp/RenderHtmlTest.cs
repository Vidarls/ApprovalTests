using ApprovalTests.Reporters;
using Asp.Net.Demo.Orders;
using NUnit.Framework;

namespace ApprovalTests.Tests.Asp
{
    [TestFixture]
    [UseReporter(typeof(FileLauncherReporter))]
    public class RenderHtmlTest
    {
        [Test]
				public void TestSimpleInvoice()
        {
					ApprovalTests.Asp.Approvals.ApproveAspPage(new InvoiceView().TestSimpleInvoice);
					//ApprovalTests.Asp.Approvals.ApproveUrl("http://localhost:1359/Orders/InvoiceView.aspx?TestSimpleInvoice");
        }
    }
}
