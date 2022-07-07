using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartAsync(string carritoId);
        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart carritoCompra);
        Task<bool> DeleteShoppingCartAsync(string carritoId);
    }
}
