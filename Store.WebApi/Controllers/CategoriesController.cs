using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Store.Business.Abstract;
using Store.Dtos.Concrete;
using Store.Entities.Concrete;

namespace Store.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        ICategoryService _categoryService;
        IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var categories = _categoryService.GetAll();

            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CategoryDto>(category));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<CategoryDto, Category>(categoryDto);
                _categoryService.Add(category);

                return Created(Request.RequestUri + category.CategoryID.ToString(), _mapper.Map<Category, CategoryDto>(category));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<CategoryDto, Category>(categoryDto);
                _categoryService.Update(category);

                return Ok(_mapper.Map<Category, CategoryDto>(category));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);

                return Ok();
            }
            catch
            {
            }

            return BadRequest();
        }
    }
}
