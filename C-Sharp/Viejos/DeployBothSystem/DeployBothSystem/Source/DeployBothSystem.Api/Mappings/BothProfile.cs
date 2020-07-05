using AutoMapper;
using DeployBothSystem.Api.Requests;
using DeployBothSystem.Api.Responses;
using DeployBothSystem.Common.Dtos.BothDtos;

namespace DeployBothSystem.Api.Mappings
{
    public class BothProfile : Profile
    {
        public BothProfile()
        {
            CreateMap<BothRequest, BothDto>();

            CreateMap<BothDto, BothResponse>();
        }
    }
}

