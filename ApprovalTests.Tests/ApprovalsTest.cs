using System.IO;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	[UseReporter(typeof (DiffReporter))]
	public class ApprovalsTest
	{
		private static readonly string[] text = new string[] {"abc", "123", "!@#"};

		[Test]
		public void Text()
		{
			Approvals.Approve("should be approved");
		}

		[Test]
		public void EnumerableWithLabel()
		{
			Approvals.Approve(text, "collection");
		}

		[Test]
		public void TestExistingFile()
		{
			var path = PathUtilities.GetDirectoryForCaller();
			var copy = path + "copyOfa.txt";
			File.Copy(path + "a.txt", copy, true);
			Approvals.ApproveFile(copy);
		}

		[Test]
		public void TestBytes()
		{
			var path = PathUtilities.GetDirectoryForCaller();
			Approvals.ApproveBinaryFile(File.ReadAllBytes(path + "a.png"), "png");
		}


		[Test]
		public void EnumerableWithLabelAndFormatter()
		{
			Approvals.Approve(text, "collection", (t) => "" + t.Length);
		}

		[Test]
		public void EnumerableWithHeaderAndFormatter()
		{
			var word = "Llewellyn";
			Approvals.Approve(word, word.ToCharArray(), (c) => c + " => " + (int) c);
		}

		[Test]
		public void EnumerableWithFormatter()
		{
			Approvals.Approve(text, (t) => "" + t.Length);
		}
	}
}