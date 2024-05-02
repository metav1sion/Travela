using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public void TInsert(Category entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _dal.Update(entity);
        }

        public void TDelete(int id)
        {
           _dal.Delete(id);
        }

        public Category TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Category> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public int TGetCategoryCount()
        {
            return _dal.GetCategoryCount();
        }
    }
}
