using System;
using System.IO;
using ApprovalTests.Core;
using ApprovalUtilities.Persistence;

namespace ApprovalTests.Reporters
{
	public class ExecutableQueryFailure : IApprovalFailureReporter, IApprovalReporterWithCleanUp
	{
		private const string FILE_ADDITION = ".queryresults.txt";
		private readonly IExecutableQuery query;
		private readonly IApprovalFailureReporter reporter;

		public ExecutableQueryFailure(IExecutableQuery query, IApprovalFailureReporter reporter)
		{
			this.query = query;
			this.reporter = reporter;
		}

		public void Report(string approved, string received)
		{
			reporter.Report(approved, received);
			var r = RunQueryAndGetPath(received);
			var a = RunQueryAndGetPath(approved);
			reporter.Report(a, r);
		}

		private string RunQueryAndGetPath(string fileName)
		{
			if (!File.Exists(fileName)) return fileName;

			var newQuery = File.ReadAllText(fileName).Trim();
			var newResult = query.ExecuteQuery(newQuery);
			var newFileName = fileName + FILE_ADDITION;
			var header = "\t\tDo NOT approve\r\n\t\tThis File will be Deleted\r\n\t\tit is for feedback purposes only\r\n";
			File.WriteAllText(newFileName, string.Format("{0}query:\r\n\r\n{1}\r\n\r\nresult:\r\n\r\n{2}", header, newQuery, newResult));
			return newFileName;
		}

		public void CleanUp(string approved, string received)
		{
			File.Delete(approved + FILE_ADDITION);
			File.Delete(received + FILE_ADDITION);
		}
	}
}