using AutoMapper;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;
using Store.Business.Abstract;
using Store.Dtos.Concrete;
using Store.Entities.Concrete;

namespace Store.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = _productService.GetAllWithCategory();

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(products));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetByIdWithCategory(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<Product, ProductDto>(product));
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<ProductDto, Product>(productDto);
                _productService.Add(product);

                var produtWithCategory = _productService.GetByIdWithCategory(product.ProductID);
                var mappedProductDto = _mapper.Map<Product, ProductDto>(produtWithCategory);

                return Created(Request.RequestUri + product.ProductID.ToString(), mappedProductDto);
            }
            catch
            {
            }

            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<ProductDto, Product>(productDto);
                _productService.Update(product);

                var produtWithCategory = _productService.GetByIdWithCategory(product.ProductID);
                var mappedProductDto = _mapper.Map<Product, ProductDto>(produtWithCategory);

                return Ok(mappedProductDto);
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
                _productService.Delete(id);

                return Ok();
            }
            catch
            {
            }

            return BadRequest();
        }
    }
}
