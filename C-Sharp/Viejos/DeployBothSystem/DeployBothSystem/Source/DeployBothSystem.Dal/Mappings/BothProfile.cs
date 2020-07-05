using AutoMapper;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Models;

namespace DeployBothSystem.Dal.Mappings
{
    public class BothProfile : Profile
    {
        public BothProfile()
        {
            CreateMap<Both, BothDto>();

            CreateMap<BothDto, Both>();
        }
    }
}

