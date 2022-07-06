using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogic.Data;

namespace BussinesLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly FitnessFoodContext _contex;
        public GenericRepository(FitnessFoodContext context)
        {
            _contex = context;
        }
        public async Task<int> Add(T entity)
        {
            _contex.Set<T>().Add(entity);
            return await _contex.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            //_contex.Set<T>().Attach(id);
            var result = await _contex.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
            _contex.Set<T>().Remove(result);
            return await _contex.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _contex.Set<T>().ToListAsync();
        }

        public Task<int> GetByIdAsync(int id)
        {

            throw new NotImplementedException();
        }

        public async Task<int> Update(T entity)
        {
            _contex.Set<T>().Attach(entity);
            _contex.Entry(entity).State = EntityState.Modified;
            return await _contex.SaveChangesAsync();
        }

        Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
