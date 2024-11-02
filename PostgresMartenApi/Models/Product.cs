using Marten.Schema;

namespace PostgresMartenApi.Models
{
    public class Product
    {
        [Identity] // This will tell Marten to use this property as the identifier
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
