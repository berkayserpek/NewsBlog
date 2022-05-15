using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void TAdd(Category t)
        {
            _categoryRepository.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryRepository.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _categoryRepository.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryRepository.GetList();
        }

        public List<Category> TGetListByWhere(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            _categoryRepository.Update(t);
        }
    }
}
