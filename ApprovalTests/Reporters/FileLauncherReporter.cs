using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class FileLauncherReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
			QuietReporter.DisplayCommandLineApproval(approved, received);
			Process.Start(received);
		}

	}
}