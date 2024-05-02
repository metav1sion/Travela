using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public Category(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Travela.EntityLayer.Concrete.Category p)
        {
            _categoryService.TInsert(p);
            return Ok("Kategori Ekleme İşlemi Başarıyla Tamamlandı!");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silme İşlemi Başarıyla Tamamlandı!");
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Travela.EntityLayer.Concrete.Category p)
        {
            _categoryService.TUpdate(p);
            return Ok("Kategori Güncelleme İşlemi Başarıyla Tamamlandı!");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }
    }
}
