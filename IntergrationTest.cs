namespace ShopsTest.Test;

public class IntegrationTests
{

    #region return all

    [Fact]
    public async Task Should_Return_Shops()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/shops");
        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var shops = await result.Content.ReadFromJsonAsync<List<Shop>>();
        Assert.NotNull(shops);
        Assert.IsType<List<Shop>>(shops);
    }

    [Fact]
    public async Task Should_Return_Categorys()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/categorys");
        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var categorys = await result.Content.ReadFromJsonAsync<List<Category>>();
        Assert.NotNull(categorys);
        Assert.IsType<List<Category>>(categorys);
    }

    [Fact]
    public async Task Should_Return_Products()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/products");
        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var products = await result.Content.ReadFromJsonAsync<List<Product>>();
        Assert.NotNull(products);
        Assert.IsType<List<Product>>(products);
    }
    #endregion

    #region get 1 by id

    [Fact]
    public async Task Should_Return_Shops_By_Id()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var FakeShopsRepository = new FakeShopsRepository();
        await FakeShopsRepository.AddShop(new Shop() { Id = "1" });
        var result = await client.GetAsync("/shop/1");


        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var shops = await result.Content.ReadFromJsonAsync<Shop>();
        Assert.NotNull(shops);
        Assert.IsType<Shop>(shops);
        Assert.Equal("1", shops.Id);
    }

    [Fact]
    public async Task Should_Return_Products_By_Id()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var FakeProductsRepository = new FakeProductsRepository();
        await FakeProductsRepository.AddProduct(new Product() { Id = "1" });
        var result = await client.GetAsync("/product/1");


        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var products = await result.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(products);
        Assert.IsType<Product>(products);
        Assert.Equal("1", products.Id);
    }

    #endregion



    [Fact]
    public async Task Add_Shop_Created()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var newShop = new Shop()
        {
            Id = "1",
            Name = "winkel"
        };
        var result = await client.PostAsJsonAsync("/shops", newShop);
        //Assert.NotNull(result.Headers.Location);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Add_Shop_No_Name_Bad_Request()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var newShop = new Shop()
        {
            Id="1",
        };
        var result = await client.PostAsJsonAsync("/shops", newShop);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Add_Shop_No_Id_Bad_Request()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();
        var newShop = new Shop()
        {
            Name = "test",
        };
        var result = await client.PostAsJsonAsync("/shops", newShop);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
