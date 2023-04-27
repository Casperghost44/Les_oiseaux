using Les_oiseaux.App.Services.DTO;

namespace Les_oiseaux.App.Services.Interfaces.Services
{
    public interface IProductService
    {
        Task<long?> CreateProductAsync(
           CreateProductDTO createProduct);

        Task UpdateProductAsync(
            long? productId,
            UpdateProductDTO updateProduct);

        Task DeleteProductAsync(
           long? productId);

        Task UpdateProductPriceAsync(
            long? productId,
            UpdateProductPriceDTO updateProductPrice);

        Task<ProductDetailsDTO> GetProductDetailsAsync(
            long? productId);

        Task<IEnumerable<ProductShortDTO>> GetProductListAsync(
            long? categoryId);
    }
}
