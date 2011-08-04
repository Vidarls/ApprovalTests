using System.Diagnostics;
using System.IO;

namespace ApprovalUtilities.Utilities
{
    public class PathUtilities
    {
        public static string GetDirectoryForCaller()
        {
            return GetDirectoryForCaller(1);
        }

        public static string GetDirectoryForCaller(int callerStackDepth)
        {
            var fileName = new StackTrace(true).GetFrame(callerStackDepth + 1).GetFileName();
            return new FileInfo(fileName).Directory.FullName + "\\";
        }
    }
}