using Les_oiseaux.App.Models;

namespace Les_oiseaux.App.Services.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>{

        Task<bool> IsCategoryUniqueAsync(
            long? categoryId,
            string name);
    }

}
