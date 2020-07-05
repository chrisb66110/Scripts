using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ProductColorDtos;

namespace Catalogue.Bll.Blls.ProductColorBll
{
    public interface IProductColorBll
    {
        Task<List<ProductColorDto>> GetAllAsync();
        Task<ProductColorDto> GetByIdAsync(string id);
        Task<ProductColorDto> AddAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> UpdateAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> DeleteAsync(ProductColorDto productColorDto);
    }
}

