using System.Windows.Forms;
using ApprovalTests.Namers;

namespace ApprovalTests.WinForms
{
	public class Approvals
	{
		public static void Approve(Form form)
		{
			ApprovalTests.Approvals.Approve(new ApprovalFormWriter(form));
		}

		public static void Approve(Control control)
		{
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control));
		}
	}
}