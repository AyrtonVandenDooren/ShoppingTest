namespace ShopsTest.Fakes;


public class FakeProductsRepository : IProductRepository
{
    public static List<Product> _product = new();

    #region add
    public Task<Product> AddProduct(Product newProduct)
    {
        _product.Add(newProduct);
        return Task.FromResult(newProduct);
    }
    #endregion

    #region get all
    public Task<List<Product>> GetAllProducts()
    {
        return Task.FromResult(_product);
    }
    #endregion

    #region get by id
    public Task<Product> GetProduct(string id)
    {
        var result = _product.Find(s => s.Id == id);
        return Task.FromResult(result);
    }
    #endregion

    #region get all by id
    public Task<List<Product>> GetProductsByCategoryId(string categoryId)
    {
        var result = _product.FindAll(s => s.category.Id == categoryId);
        return Task.FromResult(result);
    }
    #endregion

    //voor later
    #region update
    public Task<Product> UpdateProduct(Product Product)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> UpdateStock(string productId, int stock)
    {
        try
        {
            var item = _product.Where(s => s.Id == productId).SingleOrDefault();
            if (item != null)
                item.Stock = stock;

            return await Task.FromResult(item);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }

    #endregion

    //voor later
    #region delete
    public Task DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(string productId, Product product)
    {
        throw new NotImplementedException();
    }
    #endregion
}

