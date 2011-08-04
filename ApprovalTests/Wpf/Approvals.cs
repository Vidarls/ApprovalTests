using System;
using System.Windows;
using ApprovalTests.Namers;

namespace ApprovalTests.Wpf
{
	public class Approvals
	{
		public static void Approve(Window window)
		{
			ApprovalTests.Approvals.Approve(new ApprovalWpfWindowWriter(window), new UnitTestFrameworkNamer(),
			                                ApprovalTests.Approvals.GetReporter());
		}

		public static void Approve(Func<Window> action)
		{
			ApprovalTests.Approvals.Approve(new WindowWpfWriter(action), new UnitTestFrameworkNamer(),
			                                ApprovalTests.Approvals.GetReporter());
		}
	}
}