using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class PlansController : BaseApiController
    {
        private readonly IGenericRepository<Plans> _plansRepository;
        public PlansController(IGenericRepository<Plans> planstRepository)
        {
            _plansRepository = planstRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Plans>> Post(Plans plans)
        {
            var result = await _plansRepository.Add(plans);

            if (result == 0)
            {
                throw new Exception("No se inserto el producto");
            }
            return Ok(plans);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Plans>> Put(int id, Plans plans)
        {
            plans.Id = id;
            var resultado = await _plansRepository.Update(plans);

            if (resultado == 0)
            {
                throw new Exception("No se pudo actualizar el producto");
            }
            return Ok(plans);
        }

        [HttpGet]
        public async Task<ActionResult<List<Plans>>> Get()
        {
            var result = await _plansRepository.GetAllAsync();
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Plans>> Delete(int id)
        {
            var resultado = await _plansRepository.Delete(id);

            if (resultado == 0)
            {
                throw new Exception("No se pudo Eliminar el producto");
            }
            return Ok("Producto eliminado exitonsamente");
        }
    }
}
