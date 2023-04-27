using Les_oiseaux.App.Models;

namespace Les_oiseaux.App.Services.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetPending();
    }

}
