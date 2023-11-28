using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.DtoModels;
using Repository.ViewModels;

namespace Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private string connectionString;
        public ProductRepo(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.connectionString = this.GetConnection();
        }

        public ProductVM Create(ProductVM objVm)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO [Product] ([ProductName], [ProductPrice], [ProductBrand], [ProductDescription], [ProductQuantity])VALUES(@ProductName, @ProductPrice, @ProductBrand, @ProductDescription ,@ProductQuantity);" +
                        "Select Top 1 * From Product order by Id desc";
                    var objDTO = mapper.Map<Product>(objVm);
                    var result = con.Query<Product>(query, objDTO).FirstOrDefault();
                    var resultVM = mapper.Map<ProductVM>(result);
                    return resultVM;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool Delete(int id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "Delete From Product Where Id =" + id;
                    con.Execute(query);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public ProductVM Get(int id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "Select * From Product Where Id =" + id;
                    var result = con.Query<Product>(query).FirstOrDefault();
                    var resultVM = mapper.Map<ProductVM>(result);
                    return resultVM;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<ProductVM> GetAll()
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "Select * From Product";
                    var products = con.Query<Product>(query);
                    var resultVM = mapper.Map<List<ProductVM>>(products);
                    return resultVM;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public ProductVM Update(ProductVM objVM)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE [Product] SET [ProductName] = @ProductName, [ProductBrand] = @ProductBrand, [ProductPrice] = @ProductPrice, [ProductQuantity] = @ProductQuantity, [ProductDescription] = @ProductDescription  WHERE Id = @Id; " +
                        "Select * From [Product] Where Id = @Id";
                    var objDTO = mapper.Map<Product>(objVM);
                    var result = con.Query<Product>(query, objDTO).FirstOrDefault();
                    var resultVM = mapper.Map<ProductVM>(result);
                    return resultVM;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public string GetConnection()
        {
            var connection = configuration.GetSection("ConnectionStrings").GetSection("DB").Value;
            return connection;
        }
    }
}
