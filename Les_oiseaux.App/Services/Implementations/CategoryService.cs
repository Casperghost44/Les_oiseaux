using AutoMapper;
using Les_oiseaux.App.Models;
using Les_oiseaux.App.Services.DTO;
using Les_oiseaux.App.Services.Interfaces;
using Les_oiseaux.App.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.App.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _cateogryReposity;

        public CategoryService(
            IMapper mapper,
            ICategoryRepository cateogryReposity)
        {
            _mapper = mapper;
            _cateogryReposity = cateogryReposity;
        }

        public async Task<long?> CreateCategoryAsync(
            CreateUpdateCategoryDTO createCategory)
        {
            var category = Category.Create(
                createCategory.Name);

            var isUnique = await _cateogryReposity.IsCategoryUniqueAsync(
                null,
                createCategory.Name);

            if (!isUnique)
            {
                throw new InvalidOperationException(
                    "Category name is not unique");
            }

            var categoryId = await _cateogryReposity.SaveAsync(
                category);

            return categoryId;
        }

        public async Task DeleteCategoryAsync(
            long? categoryId)
        {
            if (categoryId is null)
            {
                throw new ArgumentNullException(
                    nameof(categoryId),
                    "Category id is requred");
            }

            var category = await _cateogryReposity.GetAsync(
                categoryId);

            if (category is null)
            {
                throw new ArgumentException(
                    $"Category with id {categoryId} does not exist",
                    nameof(category));
            }

            await _cateogryReposity.DeleteAsync(category);
        }

        public async Task UpdateCategoryAsync(
            long? categoryId,
            CreateUpdateCategoryDTO updateCategory)
        {
            if (categoryId is null)
            {
                throw new ArgumentNullException(
                    nameof(categoryId),
                    "Category id is requred");
            }

            var category = await _cateogryReposity.GetAsync(
                categoryId);

            if (category is null)
            {
                throw new ArgumentException(
                    $"Product wit id {categoryId} does not exist",
                    nameof(category));
            }

            var isUnique = await _cateogryReposity.IsCategoryUniqueAsync(
                categoryId,
                updateCategory.Name);

            if (!isUnique)
            {
                throw new InvalidOperationException(
                    "Product name is not unique");
            }

            category.Update(updateCategory.Name);

            await _cateogryReposity.UpdateAsync(category);
        }

        public async Task<IEnumerable<CategoryShortDTO>> GetCategoryListAsync()
        {
            var categories = await _cateogryReposity.GetAsync();

            return _mapper.Map<IEnumerable<CategoryShortDTO>>(categories);
        }

    }
}
