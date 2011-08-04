using System;

namespace ApprovalTests.StackTraceParsers
{
    public class XUnitStackTraceParser : AttributeStackTraceParser
    {
        protected override string GetAttributeType()
        {
            return "Xunit.FactAttribute";
        }
    }
}