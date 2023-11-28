using System.ComponentModel.DataAnnotations;

namespace Repository.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name of the product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter description of the product")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter price of the product")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter brand of the product")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter quantity of the product")]
        public int Quantity { get; set; }
    }
}
