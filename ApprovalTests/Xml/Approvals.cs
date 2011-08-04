using ApprovalUtilities.Xml;

namespace ApprovalTests.Xml
{
	public class Approvals
	{
		public static void ApproveXml(string xml)
		{
			ApproveText(xml,"xml",true);
		}
		
		public static void ApproveText(string text, string fileExtensionWithoutDot, bool safely)
		{
			text = XmlUtils.FormatXml(text, safe: safely);
			ApprovalTests.Approvals.Approve(new ApprovalTextWriter(text,fileExtensionWithoutDot));
		}

		

		/// <summary>
		/// Throws exception if Xml is incorrectly formatted
		/// </summary>
		public static void ApproveXmlStrict(string xml)
		{
			ApproveText(xml, "xml", false);

		}
	}
}