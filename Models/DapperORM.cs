using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Qhrm.Models
{
    public static class DapperORM
    {
        private static readonly string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MVCDapperDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static IEnumerable<ProductsModel> GetAllProducts(String connectionString)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<ProductsModel>("dbo.GetAllProducts", commandType: CommandType.StoredProcedure);
        }

        public static void AddProduct(ProductsModel product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductName", product.ProductName);
                parameters.Add("@Description", product.Description);
                parameters.Add("@Price", product.Price);
                db.Execute("dbo.AddProduct", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static void UpdateProduct(ProductsModel product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", product.Id);
                parameters.Add("@ProductName", product.ProductName);
                parameters.Add("@Description", product.Description);
                parameters.Add("@Price", product.Price);
                db.Execute("dbo.UpdateProduct", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", productId);
                db.Execute("dbo.DeleteProduct", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static ProductsModel GetProductById(int productId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", productId);
                return db.QueryFirstOrDefault<ProductsModel>("dbo.GetProductById", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
