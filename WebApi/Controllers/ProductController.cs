using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var result = await _productRepository.Add(product);

            if (result == 0)
            {
                throw new Exception("No se inserto el producto");
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            product.Id = id;
            var resultado = await _productRepository.Update(product);

            if (resultado == 0)
            {
                throw new Exception("No se pudo actualizar el producto");
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var product = await _productRepository.GetAllAsync();

            var productDto = _mapper.Map<IReadOnlyList<Product>, List<ProductDto>>(product);

            return productDto;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var resultado = await _productRepository.Delete(id);

            if (resultado == 0)
            {
                throw new Exception("No se pudo Eliminar el producto");
            }
            return Ok("Producto eliminado exitonsamente");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductId(int id)
        {

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            return product;
        }
    }
}
