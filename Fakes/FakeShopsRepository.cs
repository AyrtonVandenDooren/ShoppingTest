namespace ShopsTest.Fakes;

public class FakeShopsRepository : IShopRepository
{
    private static readonly List<Shop> _shops = new();

    #region add
    public Task<Shop> AddShop(Shop newShop)
    {
        _shops.Add(newShop);
        return Task.FromResult(newShop);
    }
    #endregion

    #region get all
    public Task<List<Shop>> GetAllShops()
    {
        return Task.FromResult(_shops);
    }
    #endregion

    #region get by id
    public Task<Shop> GetShop(string id)
    {
        var result = _shops.Find(s => s.Id == id);
        return Task.FromResult(result);
    }

    
    #endregion

    #region update
    public Task<Shop> UpdateShop(Shop Shop)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region delete
    public Task DeleteShop(string id)
    {
        throw new NotImplementedException();
    }
    #endregion

}
