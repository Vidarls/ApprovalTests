using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ApprovalTests.StackTraceParsers
{
    public abstract class AttributeStackTraceParser : IStackTraceParser
    {
        private StackTrace stackTrace;

        public MethodBase Method
        {
            get { return FindApprovalFrame().GetMethod(); }
        }

        public string TypeName
        {
            get { return Method.DeclaringType.Name; }
        }


        public string ApprovalName
        {
            get { return String.Format(@"{0}.{1}", TypeName, Method.Name); }
        }

        public string SourcePath
        {
            get { return Path.GetDirectoryName(FindApprovalFrame().GetFileName()); }
        }

        public bool Parse(StackTrace trace)
        {
            stackTrace = trace;
            return FindApprovalFrame() != null;
        }


        public static StackFrame GetFirstFrameForAttribute(StackFrame[] frames, string attributeName)
        {
            if (frames == null)
                return null;


            for (int i = 0; i < frames.Length; i++)
            {
                if (ContainsAttribute(frames[i].GetMethod().GetCustomAttributes(false), attributeName))
                {
                    return frames[i];
                }
            }

            return null;
        }

        private static bool ContainsAttribute(object[] attributes, string attributeName)
        {
            foreach (object a in attributes)
            {
                if (a.GetType().FullName.StartsWith(attributeName))
                {
                    return true;
                }
            }

            return false;
        }

        private StackFrame FindApprovalFrame()
        {
            return GetFirstFrameForAttribute(stackTrace.GetFrames(), GetAttributeType());
        }

        public bool IsApplicable()
        {
            return GetAttributeType() != null;
        }

        protected abstract string GetAttributeType();
    }
}