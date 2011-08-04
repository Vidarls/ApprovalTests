using System;
using System.IO;

namespace ApprovalTests.Reporters
{
	public class WinMergeReporter:DiffReporter
	{
		public WinMergeReporter()
		{
			AddDiffReporter("*", new LaunchArgs(Environment.GetEnvironmentVariable("ProgramFiles") + @"\WinMerge\WinMergeU.exe", "\"{0}\" \"{1}\""));
		}
	}
}