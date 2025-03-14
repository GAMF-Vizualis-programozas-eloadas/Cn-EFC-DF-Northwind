using System;
using System.Globalization;
using System.Linq;
using Microsoft.Data.SqlClient;
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
				Console.WriteLine("==================================================================================================");
				Console.WriteLine("{0,-18}{1,-32}{2,10}  {3,-38}", "Category", "Product", "Unit price", "Supplier");
				Console.WriteLine("==================================================================================================");
				var prlist = cn.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
				foreach (var pr in prlist)
				{
					Console.WriteLine("{0,-18}{1,-32}{2,10}  {3,-38}",
						(pr.Category != null ? pr.Category.CategoryName : "***"),
						pr.ProductName,
						((double)pr.UnitPrice).ToString("C", CultureInfo.CreateSpecificCulture("en-US")),
						(pr.Supplier != null ? pr.Supplier.CompanyName : ""));
				}
				DetachDb(cn);
			}
		}

		private static void DetachDb(cnNorthwind cn)
		{
			cn.Database.OpenConnection();
			var connection = cn.Database.GetDbConnection();
			if (connection.State == System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}
			string[] commands =
			{ "USE master",
				$"ALTER DATABASE [{connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
				$"ALTER DATABASE [{connection.Database}] SET OFFLINE WITH ROLLBACK IMMEDIATE",
				$"EXEC sp_detach_db '{connection.Database}'"
			};
			using (var sqlCommand = new SqlCommand())
			{
				sqlCommand.Connection = connection as SqlConnection;
				foreach (string command in commands)
				{
					sqlCommand.CommandText = command;
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

	}
}
