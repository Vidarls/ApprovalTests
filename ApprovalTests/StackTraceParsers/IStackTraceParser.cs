using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public interface IStackTraceParser
	{
		string ApprovalName { get; }
		string SourcePath { get; }
		bool Parse(StackTrace stackTrace);
	}
}