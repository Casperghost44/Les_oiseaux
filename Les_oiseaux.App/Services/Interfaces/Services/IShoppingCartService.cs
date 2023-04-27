using Les_oiseaux.App.Services.DTO;

namespace Les_oiseaux.App.Services.Interfaces.Services
{
    public interface IShoppingCartService
    {
        Task<long?> CreateShoppingCart(
           long? productId,
           int quantity);

        Task<ShoppingCartDTO> GetShoppingCartDetailsAsync(
            long? shoppingCartId);

        Task<IEnumerable<ShoppingCartShortDTO>> GetShoppingCartListAsync();
    }
}
