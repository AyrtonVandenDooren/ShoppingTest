namespace ShopsTest.Fakes;

public class FakeCategoryRepository : ICategoryRepository
{
//contructor toevoegen en default toevoegen
    
    private readonly List<Category> _category = new();

    #region add
    public Task<Category> AddCategory(Category newCategory)
    {
        _category.Add(newCategory);
        return Task.FromResult(newCategory);
    }
    //werkt

    public Task<List<Category>> AddCategory(List<Category> categorys)
    {
        _category.AddRange(categorys);
        return Task.FromResult(categorys);
    }
    //werkt
    #endregion

    #region get all
    public Task<List<Category>> GetAllCategorys()
    {
        return Task.FromResult(_category);
    }
    //werkt
    #endregion

    #region get by id
    public Task<Category> GetCategory(string id)
    {
        var result = _category.Find(s => s.Id == id);
        return Task.FromResult(result);
    }
    #endregion

    #region get all by id
    public Task<List<Category>> GetCategoryByShopId(string shopId)
    {
        var result = _category.FindAll(s => s.shop.Id == shopId);
        return Task.FromResult(result);
    }
    #endregion 

    //voor later
    #region update
    public Task<Category> UpdateCategory(Category Category)
    {
        throw new NotImplementedException();
    }
    #endregion

    //voor later
    #region delete
    public Task DeleteCategory(string id)
    {
        // _category.Remove(id)
        throw new NotImplementedException();
    }
    #endregion 
}