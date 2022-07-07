using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi.Properties
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartRepository _shoppingCart;
        public ShoppingCartController(IShoppingCartRepository shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCarById(string id)
        {
            var car = await _shoppingCart.GetShoppingCartAsync(id);
            return Ok(car ?? new ShoppingCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCart carParameter)
        {
            var updateCar = await _shoppingCart.UpdateShoppingCartAsync(carParameter);
            return Ok(updateCar);
        }

        [HttpDelete]
        public async Task DeleteShoppingCart(string id)
        {
            await _shoppingCart.DeleteShoppingCartAsync(id);
        }
    }
}
