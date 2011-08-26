using System.Text;

namespace ApprovalUtilities.SimpleLogger
{
	public class StringBuilderLogger : IAppendable
	{
		private StringBuilder sb = new StringBuilder();

		public void Append(string text)
		{
			sb.Append(text);
		}

		public void AppendLine(string text)
		{
			sb.Append(text + "\r\n");
		}

		public override string ToString()
		{
			return sb.ToString();
		}

		public string ScrubPath(string directory)
		{
			return ToString().Replace(directory, "...\\");
		}
	}
}