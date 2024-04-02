namespace ASP_Homework_Product.Models
{
    public class ComparisonItem
    {
        public Product Product { get; }

        public Product ComparableProduct { get; }
        public IProductsRepository ProductsRepository { get; }

        public ComparisonItem(Product product, Product comparableProduct, IProductsRepository productsRepository)
        {
            Product = product;
            ComparableProduct = comparableProduct;
            ProductsRepository = productsRepository;
        }
    }
}
