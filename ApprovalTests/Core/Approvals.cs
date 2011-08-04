using ApprovalTests.Core;

namespace ApprovalTests.Core
{
	public class Approvals
	{
		public static void Approve(IApprovalApprover approver, IApprovalFailureReporter reporter)
		{
			if (approver.Approve())
				approver.CleanUpAfterSucess(reporter);
			else
			{
				approver.ReportFailure(reporter);

				if (reporter is IReporterWithApprovalPower && ((IReporterWithApprovalPower)reporter).ApprovedWhenReported())
					approver.CleanUpAfterSucess(reporter);
				else
					approver.Fail();
			}
		}
	}
}