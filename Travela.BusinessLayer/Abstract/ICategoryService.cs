using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Abstract;

public interface ICategoryService : IGenericService<Category>
{
    public int TGetCategoryCount();
}