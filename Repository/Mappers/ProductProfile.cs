using AutoMapper;
using Repository.DtoModels;
using Repository.ViewModels;

namespace Repository.Mappers
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(d => d.Id, src => src.MapFrom(s => s.Id))
                .ForMember(d => d.Name, src => src.MapFrom(s => s.ProductName))
                .ForMember(d => d.Description, src => src.MapFrom(s => s.ProductDescription))
                .ForMember(d => d.Price, src => src.MapFrom(s => s.ProductPrice))
                .ForMember(d => d.Brand, src => src.MapFrom(s => s.ProductBrand))
                .ForMember(d => d.Quantity, src => src.MapFrom(s => s.ProductQuantity));


            CreateMap<ProductVM, Product>()
                .ForMember(d => d.Id, src => src.MapFrom(s => s.Id))
                .ForMember(d => d.ProductName, src => src.MapFrom(s => s.Name))
                .ForMember(d => d.ProductDescription, src => src.MapFrom(s => s.Description))
                .ForMember(d => d.ProductPrice, src => src.MapFrom(s => s.Price))
                .ForMember(d => d.ProductBrand, src => src.MapFrom(s => s.Brand))
                .ForMember(d => d.ProductQuantity, src => src.MapFrom(s => s.Quantity));
        }
    }
}
