namespace ApprovalTests.Html
{
	public class Approvals
	{
		public static void ApproveHtml(string html)
		{
			Xml.Approvals.ApproveText(html, "html", true);

		}

		/// <summary>
		/// Throws exception if Html is incorrectly formatted
		/// </summary>
		public static void ApproveHtmlStrict(string html)
		{
			Xml.Approvals.ApproveText(html, "html", false);

		}
	}
}