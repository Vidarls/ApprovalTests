using MbUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class ExampleUsages
	{
		[Test, Parallelizable]
		public void ApprovingText()
		{
			Approvals.Approve("A piece of text");
		}

		[Test, Parallelizable]
		public void ApprovingAnEnumerble()
		{
			Approvals.Approve(new []{"item1", "item2", "item3"}, "items");
		}

		[Test, Parallelizable]
		public void ApprovingAnImage()
		{
		}

		[Test, Parallelizable]
		public void ApprovingAForm()
		{
		}

		[Test, Parallelizable]
		public void ApprovingAnObject()
		{
		}
	}
}