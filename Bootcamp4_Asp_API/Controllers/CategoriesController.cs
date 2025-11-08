using Bootcamp4_AspMVC.Dtos;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_Asp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryListDto>> GatAll()
        {
            try
            {

                IEnumerable<Category> categories = _categoryService.GetAllCategoriesWithProducts();
                var categoriesDto = categories.Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count(),
                });
                return Ok(categoriesDto);
            }
            catch (Exception ex)
            {

                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");

            }
        }


        [HttpGet("{uid}")]
        public ActionResult<Category> GetByUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    return BadRequest("Uid is required.");

                var category = _categoryService.GetByUid(uid);
                if (category == null)
                    return NotFound("لا توجد فئه بهذا الرقم"); // 404

                return Ok(category); // 200

            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

        }


        [HttpPost]
        public ActionResult Create(CategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var category = new Category();

                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;

                var isCreated = _categoryService.Create(category);
                if (isCreated)
                    //  return CreatedAtAction(nameof(GetByUid), new { uid = category.Uid }, category); // 201

                    return Ok("تم انشاء الفئه بنجاح"); // 200

                return BadRequest("فشل انشاء الفئه"); // 400

            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }
        }



        [HttpPut("{uid}")]
        public IActionResult Update(string uid, [FromBody] CategoryUpdateDto category)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return BadRequest("Uid is required.");

            if (category == null)
                return BadRequest("Category payload is required.");

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var exists = _categoryService.GetByUid(uid);
            if (exists == null)
                return NotFound(); // 404

            // نضمن التحديث على نفس الـUid

            var newCategory = new Category
            {
                Uid = category.Uid,
                Name = category.Name,
                Description = category.Description
            };



            _categoryService.Update(uid, newCategory);
            return Ok("تم تحديث الفئة بنجاح");
        }


        // DELETE: api/categories/{uid}
        [HttpDelete("{uid}")]
        public IActionResult Delete(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return BadRequest("Uid is required.");

            var exists = _categoryService.GetByUid(uid);
            if (exists == null)
                return NotFound(); // 404

            _categoryService.DeleteByUid(uid);
            return Ok("تم حذف الفئة بنجاح"); // 204
        }





    }
}
