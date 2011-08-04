using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
    public class StackTraceParser : IStackTraceParser
    {
        private static IStackTraceParser[] parsers;
        private IStackTraceParser parser;


        public bool Parse(StackTrace stackTrace)
        {
            foreach (IStackTraceParser p in getParsers())
            {
                if (p.Parse(stackTrace))
                {
                    parser = p;
                    return true;
                }
            }

            throw new Exception(string.Format("Could Find Namer for {0}", stackTrace));
        }

        public string ApprovalName
        {
            get { return parser.ApprovalName; }
        }

        public string SourcePath
        {
            get { return parser.SourcePath; }
        }


        private static void LoadIfApplicable(List<IStackTraceParser> found, AttributeStackTraceParser p)
        {
            if (p.IsApplicable())
            {
                found.Add(p);
            }
        }

        private IStackTraceParser[] getParsers()
        {
            if (parsers == null)
            {
                var found = new List<IStackTraceParser>();
                LoadIfApplicable(found, new NUnitStackTraceParser());
                LoadIfApplicable(found, new VSStackTraceParser());
                LoadIfApplicable(found, new MbUnitStackTraceParser());
                parsers = found.ToArray();
            }
            return parsers;
        }
    }
}