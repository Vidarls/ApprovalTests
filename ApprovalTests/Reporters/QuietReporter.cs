using System;
using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class QuietReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
			DisplayCommandLineApproval(approved, received);
		}

		public static void DisplayCommandLineApproval(string approved, string received)
		{
			string message = string.Format("move /Y \"{0}\" \"{1}\"", received, approved);
			Debug.WriteLine(message);
			Console.WriteLine(message);
		}
	}
}