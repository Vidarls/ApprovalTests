using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class DiffReporter : IApprovalFailureReporter
	{
		private string imageDiffArgs = "/left:\"{0}\" /right:\"{1}\"";
		private string imageDiffTool = "tortoiseidiff";
		private string textDiffArguments = "/base:\"{0}\" /mine:\"{1}\"";
		private string textDiffProgram = "tortoisemerge.exe";


		private Dictionary<string, LaunchArgs> types = new Dictionary<string, LaunchArgs>();

		public DiffReporter()
		{
			var tortoise = new LaunchArgs(textDiffProgram, textDiffArguments);
			AddDiffReporter("*", tortoise);
			AddDiffReporter(".tif", new LaunchArgs(imageDiffTool, imageDiffArgs));
			AddDiffReporter(".tiff", new LaunchArgs(imageDiffTool, imageDiffArgs));
			AddDiffReporter(".png", new LaunchArgs(imageDiffTool, imageDiffArgs));
		}
		public DiffReporter(LaunchArgs defaultLauncher)
		{
			AddDiffReporter("*", defaultLauncher);
		}

		/// <param name = "extensionWithDot"> Use * for default</param>
		public void AddDiffReporter(string extensionWithDot, LaunchArgs fileParameters)
		{
			types[extensionWithDot] =  fileParameters;
		}

		public void Report(string approved, string received)
		{
			QuietReporter.DisplayCommandLineApproval(approved, received);
			Launch(GetLaunchArguments(approved, received));
		}


		public LaunchArgs GetLaunchArguments(string approved, string received)
		{
			if (!File.Exists(approved))
			{
				File.Create(approved).Dispose();
			}

			var args = GetLaunchArgumentsForFile(approved);
			return new LaunchArgs(args.Program, string.Format(args.Arguments, received, approved));
		}

		private LaunchArgs GetLaunchArgumentsForFile(string approved)
		{
			var ext = Path.GetExtension(approved);
			if (types.ContainsKey(ext))
			{
				return types[ext];
			}
			return types["*"];
		}

		public void Launch(LaunchArgs launchArgs)
		{
			Process.Start(launchArgs.Program, launchArgs.Arguments);
		}
	}
}