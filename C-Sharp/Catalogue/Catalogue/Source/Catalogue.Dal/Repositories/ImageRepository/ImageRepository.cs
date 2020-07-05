using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.ImageDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.ImageRepository
{
    public class ImageRepository : BaseRepository<Image, long>, IImageRepository
    {
        private readonly IMapper _mapper;

        public ImageRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ImageDto>> GetAllAsync()
        {
            var listImage = await _GetAllAsync();
            
            var response = _mapper.Map<List<Image>, List<ImageDto>>(listImage);
            return response;
        }

        public async Task<ImageDto> GetByIdAsync(long id)
        {
            var image = await _GetByIdAsync(id);

            var response = _mapper.Map<Image, ImageDto>(image);
            return response;
        }

        public async Task<ImageDto> AddAsync(ImageDto imageDto)
        {
            var image = _mapper.Map<ImageDto, Image>(imageDto);

            var result = await _AddAsync(image);

            var response = _mapper.Map<Image, ImageDto>(result);
            return response;
        }

        public async Task<ImageDto> UpdateAsync(ImageDto imageDto)
        {
            var image = _mapper.Map<ImageDto, Image>(imageDto);

            var result = await _UpdateAsync(image);

            var response = _mapper.Map<Image, ImageDto>(result);
            return response;
        }

        public async Task<ImageDto> DeleteAsync(ImageDto imageDto)
        {
            var image = _mapper.Map<ImageDto, Image>(imageDto);

            var result = await _RemoveAsync(image);

            var response = _mapper.Map<Image, ImageDto>(result);
            return response;
        }
    }
}

