using NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Category;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Product
{
    public class ProductGetDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual CategoryGetDto Category { get; set; }
    }
}
