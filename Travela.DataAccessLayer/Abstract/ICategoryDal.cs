using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Abstract;

public interface ICategoryDal : IGenericDal<Category>
{
    public int GetCategoryCount();
}