using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ProductController(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
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
        public async Task<ActionResult<List<Product>>> Get()
        {
            var result = await _productRepository.GetAllAsync();
            return Ok(result);

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
    }
}
