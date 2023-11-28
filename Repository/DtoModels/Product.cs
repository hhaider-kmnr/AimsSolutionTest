using System.ComponentModel.DataAnnotations;

namespace Repository.DtoModels
{
    public class Product
    {
        
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductBrand { get; set; }
        public int ProductQuantity { get; set; }
    }
}
