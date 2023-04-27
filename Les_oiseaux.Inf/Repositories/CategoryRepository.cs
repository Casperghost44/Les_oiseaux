using Les_oiseaux.App.Models;
using Les_oiseaux.App.Services.Interfaces;
using Les_oiseaux.Inf.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.Inf.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Category> GetAsync(long? id)
        {
            return await _context.Categories.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.AsQueryable()
                .ToListAsync();
        }

        public async Task<bool> IsCategoryUniqueAsync(
            long? categoryId,
            string name)
        {
            var exists = await _context.Categories.AsQueryable()
                .Where(e => e.Name == name)
                .Where(e => e.Id != categoryId)
                .Select(e => e.Id)
                .AnyAsync();

            return !exists;
        }

        public async Task<long?> SaveAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
