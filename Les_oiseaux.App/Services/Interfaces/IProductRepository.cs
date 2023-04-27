using Les_oiseaux.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.App.Services.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(long? categoryId);
        Task<bool> IsProductUniqueAsync(string name);
        Task<bool> IsProductUniqueAsync(string name, long? productId);
    }

}
