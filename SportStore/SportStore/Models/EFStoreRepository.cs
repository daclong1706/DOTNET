
namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly DataContext context;
        public EFStoreRepository(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }
    }
}
