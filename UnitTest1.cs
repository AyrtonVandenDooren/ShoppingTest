using Xunit;

namespace ShoppingTest;

public class UnitTest1
{
    [Fact]
    public async Task Add_Order_ArgumentException()
    {
        var shopService = Helper.CreateShopService();

        Assert.ThrowsAsync<ArgumentException>(async () => shopService.AddBasket(null));

    }

    [Fact]
    public async Task Add_Order_And_Update_Stock()
    {
        var shopService = Helper.CreateShopService();

        FakeProductsRepository._product.Add(new Product() { Name = "Kaas", Id = "1", category = new Category() { Name = "Melk", shop = new Shop() {Name="supermarkt"} }, Stock= 0 });
        var newBasket = new Basket()
        {
            ProductId = "1"
        };

        var createdOrder = await shopService.AddBasket(newBasket);

        Assert.NotNull(createdOrder);

        var shop = await shopService.GetProduct("1");
        Assert.Equal<int>(1, shop.Stock);
    }
}