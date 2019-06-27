using NorthwindTradersCli.Adapters.Driving.CommandLine.Models.Category;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Models.Product
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
