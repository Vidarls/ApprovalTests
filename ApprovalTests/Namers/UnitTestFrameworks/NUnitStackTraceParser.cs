using System;

namespace ApprovalTests.StackTraceParsers
{
	public class NUnitStackTraceParser : AttributeStackTraceParser
	{
		protected override string GetAttributeType()
		{
		    return "NUnit.Framework.TestAttribute";
		}
	}
}