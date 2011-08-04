using System;

namespace ApprovalTests.Reporters
{
	[AttributeUsage(AttributeTargets.All)]
	public class UseReporterAttribute : Attribute
	{
		public UseReporterAttribute(Type reporter)
		{
			Reporter = reporter;
		}
		public Type Reporter { private set; get; }
	}
}