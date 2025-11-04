using docker_backend.Model;
using Npgsql;

namespace docker_backend.Service
{
    public class ProductService
    {
        private readonly IConfiguration _config;
        private readonly string _connString;

        public ProductService(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }


        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, name, price FROM products", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            Product products = new();
            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand($"SELECT id, name, price FROM products where id = {id}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Id = reader.GetInt32(0);
                        products.Name = reader.GetString(1);
                        products.Price = reader.GetDecimal(2);
                    }
                }
            }
            return products;
        }
    }
}
