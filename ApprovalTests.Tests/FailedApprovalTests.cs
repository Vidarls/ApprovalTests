using ApprovalTests.Core.Exceptions;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
    [TestFixture]
    [UseReporter(typeof(CleanupReporter))]
    class FailedApprovalTests
    {
        [Test]
        [ExpectedException(typeof(ApprovalMismatchException))]
        public void TextDoesNotMatchApproval()
        {
            Approvals.Approve("should fail with mismatch");
        }

        [Test]
        [ExpectedException(typeof(ApprovalMissingException))]
        public void TextNotApprovedYet()
        {
            Approvals.Approve("should fail with a missing exception");
        }

        [Test]
        [ExpectedException(typeof(ApprovalMismatchException))]
        public void EnumerableDoesNotMatchApproval()
        {
            Approvals.Approve(new[]
                                  {
                                      "Does not match"
                                  }, "collection");
        }

        [Test]
        [ExpectedException(typeof(ApprovalMissingException))]
        public void EnumerableNotApprovedYet()
        {
            Approvals.Approve(new[]
                                  {
                                      "Not approved"
                                  }, "collection");
        }
    }
}