using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericReository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(T item)
        {
           await  _context.Set<T>().AddAsync(item);
        }

        public  void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {

            if (typeof(T) == typeof(News))
            {
              
                return (IReadOnlyList<T>)await _context.News.Include(E => E.Author).AsNoTracking().ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
            
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
