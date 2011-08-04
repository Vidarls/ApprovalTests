using System;

namespace ApprovalTests.StackTraceParsers
{
    public class VSStackTraceParser : AttributeStackTraceParser
    {
        protected override string GetAttributeType()
        {
            return "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute";
        }
    }
}