using NUnit.Framework;

namespace ApprovalTests.Tests.Xml
{
	[TestFixture]

	public class XmlTest
	{
		[Test]
		public static void TestXml()
		{
			ApprovalTests.Xml.Approvals.ApproveXml("<xml><hello/><start>hi</start></xml>");
		}
	}
}