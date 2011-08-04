using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using ApprovalUtilities.Utilities;
using Microsoft.Reporting.WinForms;

namespace ApprovalTests.RdlcReports
{
	public class Approvals
	{
		public static void ApproveReport(string reportname, object data)
		{
			Action<ReportDataSourceCollection, IList<string>> populateDataSources =
				(ds, validNames) =>
					{
						if (validNames.Count != 1)
						{
							throw new Exception(
								"The Cannot use a 'default' Datasource Name for {0},\r\nLegal Matches are: {1}"
									.FormatWith(reportname, validNames.ToReadableString()));
						}
						ds.Add(new ReportDataSource(validNames[0], data));
					};
			ApproveRdlcReport(reportname, data.GetType().Assembly, populateDataSources);
		}

		public static void ApproveReport(string reportname, string datasourceName, object data)
		{
			ApproveReport(reportname, data.GetType().Assembly, datasourceName, data);
		}

		public static void ApproveReport(string reportname, Assembly assembly, string datasourceName, object data)
		{
			ApproveReport(reportname, assembly, Tuple.Create(datasourceName, data));
		}

		public static void ApproveReport<T>(string reportname, Assembly assembly, params Tuple<string, T>[] dataInfo)
		{
			Action<ReportDataSourceCollection, IList<string>> populateDataSources =
				(ds, validNames) =>
					{
						foreach (var info in dataInfo)
						{
							if (!validNames.Contains(info.Item1))
							{
								throw new Exception(
									"The Datasource Name '{0}'\r\nis not a legal match for {1},\r\nLegal Matches are: {2}"
										.FormatWith(info.Item1, reportname, validNames.ToReadableString()));
							}

							ds.Add(new ReportDataSource(info.Item1, info.Item2));
						}
					};
			ApproveRdlcReport(reportname, assembly, populateDataSources);
		}

		public static void ApproveRdlcReport(string reportname, Assembly assembly,
		                                      Action<ReportDataSourceCollection, IList<string>> populateDataSources)
		{
			string warning =
				@"Please Note: there is a slight variation between the Page size of a PDF and a multipage Tiff. 
If your report is very tight to the page, the page rendering might be different.";
			Console.WriteLine(warning);
			Debug.WriteLine(warning);
			using (var report = new ReportViewer())
			{
				var method = typeof (LocalReport).GetMethod("SetEmbeddedResourceAsReportDefinition",
				                                            BindingFlags.NonPublic | BindingFlags.Instance);
				method.Invoke(report.LocalReport, new object[] {reportname, assembly});
				populateDataSources(report.LocalReport.DataSources, report.LocalReport.GetDataSourceNames());
				var bytes = RenderReport(report.LocalReport, "IMAGE");
				ApprovalTests.Approvals.ApproveBinaryFile(bytes, "tiff");
			}
		}

		public static byte[] RenderReport(LocalReport localReport, string format)
		{
			string fileNameExtension;
			string[] streams;
			Warning[] warnings;
			string mimeType;
			string encoding;
			return localReport.Render(format, null, out mimeType, out encoding, out fileNameExtension,
			                          out streams, out warnings);
		}
	}
}