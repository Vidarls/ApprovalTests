using System.Collections;
using System.Text;

namespace ApprovalUtilities.Utilities
{
    public static class StringUtils
    {
        public static string ToReadableString(this IEnumerable list)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (object l in list)
            {
                sb.Append(l + ", ");
            }
            if (sb.Length >0)
            {
            	sb.Remove(sb.Length - 2, 2);
            }
            sb.Append("]");
            return sb.ToString();
        }

			public static string FormatWith(this string mask, params object[] parameters)
			{
				return string.Format(mask, parameters);
			}
    }
}