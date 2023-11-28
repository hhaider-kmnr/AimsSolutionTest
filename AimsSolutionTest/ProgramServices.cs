using AutoMapper;
using Repository;
using Repository.Mappers;

namespace AimsSolutionTest
{
    public static class ProgramServices
    {
        public static IServiceCollection ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepo, ProductRepo>();
            return services;
        }

        public static IServiceCollection ResolveMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<ProductProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
