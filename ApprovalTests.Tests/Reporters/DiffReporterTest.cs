using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	[UseReporter(typeof (DiffReporter))]
	public class DiffReporterTest
	{
		private static void AssertLauncher(string approved, string received, DiffReporter reporter)
		{
			var args = reporter.GetLaunchArguments(approved, received);

			try
			{
				Approvals.Approve(args.ToString());
			}
			catch
			{
				reporter.Launch(args);
				throw;
			}
		}

		[Test]
		public void TestLaunchesTortoiseImage()
		{
			AssertLauncher("../../a.png", "../../b.png", new DiffReporter());
		}

		[Test]
		public void TestLaunchesBeyondCompareImage()
		{
			AssertLauncher("../../a.png", "../../b.png", new BeyondCompareReporter());
		}

		[Test]
		public void TestLaunchesTortoiseMerge()
		{
			AssertLauncher("../../a.txt", "../../b.txt", new DiffReporter());
		}

		[Test]
		public void TestWinMerge()
		{
			AssertLauncher("../../a.txt", "../../b.txt", new WinMergeReporter());
		}
	}
}