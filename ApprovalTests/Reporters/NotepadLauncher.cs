using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class NotepadLauncher : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			QuietReporter.DisplayCommandLineApproval(approved, received);

			var text = string.Format("notepad \"{0}\"", received);
			Process.Start(received);
		}
	}
}