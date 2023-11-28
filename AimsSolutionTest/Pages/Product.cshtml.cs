using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.ViewModels;

namespace AimsSolutionTest.Pages
{
    public class ProductModel : PageModel
    {
        [BindProperty]
        public ProductVM product { get; set; }
        
        private readonly IProductRepo productRepo;
        public ProductModel(IProductRepo product) => this.productRepo = product;
        public JsonResult OnGetProductList()
        {
            var products = productRepo.GetAll();
            return new JsonResult(products);
        }

        public JsonResult OnGetProduct(int id)
        {
            var products = productRepo.Get(id);
            return new JsonResult(new { isSet = true, product =  products});
        }

        public JsonResult OnPostAdd(ProductVM product)
        {
            if (product.Id > 0)
            {
                var res = productRepo.Update(product);
                return new JsonResult(new { isValid = true });
            }
            else
            {
                var res = productRepo.Create(product);
                return new JsonResult(new { isValid = true });
            }
        }

        public JsonResult OnPostDelete(string id)
        {
            var res = productRepo.Delete(int.Parse(id));
            if (res == true)
                return new JsonResult(new { isDeleted = true });
            else
                return new JsonResult("Error");
        }
    }
}
