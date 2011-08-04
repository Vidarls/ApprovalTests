using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
    [TestFixture]
    [UseReporter(typeof (DiffReporter))]
    public class LockDownTests
    {
        public string Echo(params int[] i)
        {
            return StringUtils.ToReadableString(i);
        }

        [Test]
        public void TestLockDown()
        {
            int[] n = {1, 2};
            Combinations.Approvals.ApproveAllCombinations((a,b,c,d,e,f,g,h,i)=>Echo(a,b,c,d,e,f,g,h,i), n, n, n, n, n, n, n, n, n);
        }
        [Test]
        public void TestLockDown8()
        {
            int[] n = { 1, 2 };
            Combinations.Approvals.ApproveAllCombinations((a, b, c, d, e, f, g, h) => Echo(a, b, c, d, e, f, g, h), n, n, n, n, n, n, n, n);
        }
        [Test]
        public void TestLockDown2()
        {
            int[] n = { 1, 2 };
            Combinations.Approvals.ApproveAllCombinations((a, b) => Echo(a, b), n, n);
        }
        [Test]
        public void TestExceptions()
        {
            int[] n = { 0, 2 };
            Combinations.Approvals.ApproveAllCombinations((a, b) => a / b, n, n);
        }
    }
}