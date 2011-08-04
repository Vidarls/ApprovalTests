using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Persistence.EntityFramework;
using NUnit.Framework;

namespace ApprovalTests.Tests.EntityFramework
{
	[TestFixture]
	public class EntityFrameworkLoaderTest
	{
		[Test]
		public void Text()
		{
			Approvals.Approve(new CompanyLoaderByName("M"));
		}
	}

	public class CompanyLoaderByName : EntityFrameworkLoader<Company, Company[], ModelContainer>
	{
		private readonly string name;
		
		public CompanyLoaderByName(string name) : base(() => new ModelContainer())
		{
			this.name = name;
		}

		public override IQueryable<Company> GetLinqStatement()
		{
			return (from c in GetDatabaseContext().Companies
			       where c.Name.StartsWith(name)
			       select c).Take(1);
		}
		
		public override Company[] Load()
		{
			return GetLinqStatement().ToArray();
		}
	}
	public class CompanyLoaderByName2 : MultiLoader<Company>
	{
		private readonly string name;
		
		public CompanyLoaderByName2(string name) 
		{
			this.name = name;
		}

		public override IQueryable<Company> GetLinqStatement()
		{
			return (from c in GetDatabaseContext().Companies
			       where c.Name.StartsWith(name)
			       select c).Take(1);
		}
	}

	public abstract class MultiLoader<T>: EntityFrameworkLoader<T, IEnumerable<T>, ModelContainer>
	{
		public MultiLoader(): base(() =>new ModelContainer())
		{
			
		}


		public override IEnumerable<T> Load()
		{
			return GetLinqStatement().ToArray();
		}
	}
}