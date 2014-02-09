using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fehb.Test
{
	[TestClass]
	public class BuilderUnitTests
	{
		[TestMethod]
		public void BuilderTestBasic()
		{
			var htmlBuilder = new Builder()
				.EnterHtml()
					.EnterHead()
						.CreateTitleTag("Example Title")
						.CreateMetaTag("Author", "Alex Reed")
					.LeaveHead()
					.EnterBody()
						.CreateHeading("Example Page Heading", Builder.HeaderType.H1, "title-anchor")
						.CreateHeading("Example Page Sub-Heading", Builder.HeaderType.H2, "sub-heading-anchor")
					.LeaveBody()
				.LeaveHtml();

			Debug.WriteLine(htmlBuilder);
		}
	}
}
