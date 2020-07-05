using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ImageDtos;
using Catalogue.Dal.Repositories.ImageRepository;

namespace Catalogue.Bll.Blls.ImageBll
{
    public class ImageBll : IImageBll
    {
        private readonly IImageRepository _imageRepository;

        public ImageBll(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<List<ImageDto>> GetAllAsync()
        {
            var response = await _imageRepository.GetAllAsync();

            return response;
        }

        public async Task<ImageDto> GetByIdAsync(long id)
        {
            var response = await _imageRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ImageDto> AddAsync(ImageDto imageDto)
        {
            var response = await _imageRepository.AddAsync(imageDto);

            return response;
        }

        public async Task<ImageDto> UpdateAsync(ImageDto imageDto)
        {
            var response = await _imageRepository.UpdateAsync(imageDto);

            return response;
        }

        public async Task<ImageDto> DeleteAsync(ImageDto imageDto)
        {
            var response = await _imageRepository.DeleteAsync(imageDto);

            return response;
        }
    }
}

