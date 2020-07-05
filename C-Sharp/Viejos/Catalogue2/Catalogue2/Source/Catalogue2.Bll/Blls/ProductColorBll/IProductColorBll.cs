using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ProductColorDtos;

namespace Catalogue2.Bll.Blls.ProductColorBll
{
    public interface IProductColorBll
    {
        Task<List<ProductColorDto>> GetAllAsync();
        Task<ProductColorDto> GetByIdAsync(long id);
        Task<ProductColorDto> AddAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> UpdateAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> DeleteAsync(ProductColorDto productColorDto);
    }
}

