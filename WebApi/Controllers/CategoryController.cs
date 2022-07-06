using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            var result = await _categoryRepository.Add(category);

            if (result == 0)
            {
                throw new Exception("No se inserto el producto");
            }
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, Category category)
        {
            category.Id = id;
            var resultado = await _categoryRepository.Update(category);

            if (resultado == 0)
            {
                throw new Exception("No se pudo actualizar el producto");
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var result = await _categoryRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var resultado = await _categoryRepository.Delete(id);

            if (resultado == 0)
            {
                throw new Exception("No se pudo Eliminar la categoria");
            }
            return Ok("Categoria eliminado exitonsamente");
        }
    }
}
