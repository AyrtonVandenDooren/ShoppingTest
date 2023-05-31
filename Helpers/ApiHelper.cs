namespace ShopsTest.Helpers;

public class Helper
{
    
    public static IShopService CreateShopService(){
        return CreateApi().Services.GetService<IShopService>();
    }

    public static WebApplicationFactory<Program> CreateApi()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ICategoryRepository));
                services.Remove(descriptor);

                var fakeCategoryRepository = new ServiceDescriptor(typeof(ICategoryRepository), typeof(FakeCategoryRepository), ServiceLifetime.Transient);
                services.Add(fakeCategoryRepository);

                //Zelf aanvullen
                descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IShopRepository));
                services.Remove(descriptor);

                var fakeShopsRepository = new ServiceDescriptor(typeof(IShopRepository), typeof(FakeShopsRepository), ServiceLifetime.Transient);
                services.Add(fakeShopsRepository);

                descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IProductRepository));
                services.Remove(descriptor);

                var fakeProductsRepository = new ServiceDescriptor(typeof(IProductRepository), typeof(FakeProductsRepository), ServiceLifetime.Transient);
                services.Add(fakeProductsRepository);

                descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IBasketRepository));
                services.Remove(descriptor);

                var FakeBasketRepository = new ServiceDescriptor(typeof(IBasketRepository), typeof(FakeBasketRepository), ServiceLifetime.Transient);
                services.Add(FakeBasketRepository);

            });

        });

        return application;

    }
}