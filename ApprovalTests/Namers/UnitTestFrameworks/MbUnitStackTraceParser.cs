using System;

namespace ApprovalTests.StackTraceParsers
{
	public class MbUnitStackTraceParser : AttributeStackTraceParser
	{
		protected override string GetAttributeType()
		{
			return "MbUnit.Framework.TestAttribute";
		}
	}
}