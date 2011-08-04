using System;
using System.Data;
using System.Reflection;
using ApprovalTests.Persistence.DataSets;
using NUnit.Framework;
using ReportingDemo;

namespace ApprovalTests.Tests.Persistence.Datasets
{
	[TestFixture]
	public class DatasetTest
	{
		private const string ReportName = "ReportingDemo.InsultsReport.rdlc";

		private static DataTable GetDefaultData()
		{
			return new InsultsDataSet.InsultsDataTable().AddTestDataRows();
		}
		private static Assembly GetAssembly()
		{
			return typeof (InsultsDataSet).Assembly;
		}

		[Test]
		public void TestSimpleReportWith1Dataset()
		{
			RdlcReports.Approvals.ApproveReport(ReportName, GetDefaultData());
		}

		[Test]
		public void TestSimpleReportWithDatasetInAssembly()
		{
			RdlcReports.Approvals.ApproveReport(ReportName, "Model", GetDefaultData());
		}

		[Test]
		public void TestReport()
		{
			RdlcReports.Approvals.ApproveReport(ReportName, GetAssembly(), Tuple.Create("Model", GetDefaultData()));
		}


		[Test]
		public void TestSimpleReportExplict()
		{
			RdlcReports.Approvals.ApproveReport(ReportName, GetAssembly(), "Model", GetDefaultData());
		}

		[Test]
		public void TestDataSourceNames()
		{
			var message = "";
			try
			{
				RdlcReports.Approvals.ApproveReport(ReportName, GetAssembly(), "purposelyMisspelt", GetDefaultData());
			}
			catch (Exception e)
			{
				message = e.Message;
			}
			Approvals.Approve(message);
		}
	}
}