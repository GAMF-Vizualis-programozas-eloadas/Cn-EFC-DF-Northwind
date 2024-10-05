using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind;

namespace CnEFDF_Northwind
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Database first using Northwind database with three entities\n");
			using(var cn=new cnNorthwind())
			{
				Console.WriteLine("=========================================================================================================");
				Console.WriteLine("{0,-20}{1,-32}{2,10}  {3,-40}", "Category", "Product", "Unit price", "Supplier");
				Console.WriteLine("=========================================================================================================");
				var prlist = cn.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
				foreach (var pr in prlist)
				{
					Console.WriteLine("{0,-20}{1,-32}{2,10}  {3,-40}",
						(pr.Category != null ? pr.Category.CategoryName : "***"),
						pr.ProductName,
						((double)pr.UnitPrice).ToString("C", CultureInfo.CreateSpecificCulture("en-US")),
						(pr.Supplier != null ? pr.Supplier.CompanyName : ""));
				}
			}
		}
	}
}
