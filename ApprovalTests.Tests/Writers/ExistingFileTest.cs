using System;
using System.IO;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using NUnit.Framework;

namespace ApprovalTests.Tests.Writers
{
    [TestFixture]
    [UseReporter(typeof (DiffReporter))]
    public class ExistingFileTest
    {
     
        [Test]
        public void TestExistFileIsApproved()
        {
					var basePath = Environment.CurrentDirectory + @"\..\..\";

        	var original = basePath + "a.png";
        	var copy = basePath + "a1.png";
					File.Copy(original, copy);
        	Approvals.Approve(new ExistingFileWriter(copy), Approvals.GetDefaultNamer(), Approvals.GetReporter());
        }

    }
}