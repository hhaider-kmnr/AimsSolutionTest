using Repository.ViewModels;

namespace Repository
{
    public interface IProductRepo
    {
        public ProductVM Create(ProductVM objVm);
        public ProductVM Update(ProductVM objVM);
        public bool Delete(int id);
        public ProductVM Get(int id);
        public List<ProductVM> GetAll();
    }
}
