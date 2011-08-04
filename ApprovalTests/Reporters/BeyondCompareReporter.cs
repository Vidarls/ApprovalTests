using System;
using System.IO;

namespace ApprovalTests.Reporters
{
	public class BeyondCompareReporter:DiffReporter
	{
		public BeyondCompareReporter():base(new LaunchArgs(Environment.GetEnvironmentVariable("ProgramFiles") + @"\Beyond Compare 3\BCompare.exe", "\"{0}\" \"{1}\""))
		{
			 
		}
	}
}