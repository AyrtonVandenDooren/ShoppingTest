namespace ShopsTest.Fakes;

public class FakeBasketRepository : IBasketRepository
{
    private static readonly List<Basket> _basket = new();
    public Task<Basket> AddBasket(Basket newbasket)
    {
        _basket.Add(newbasket);
        return Task.FromResult(newbasket);
    }
}