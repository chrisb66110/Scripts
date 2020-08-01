using AutoMapper;
using NSpaceRequestsVar;
using NSpaceResponsesVar;
using NSpaceModelsDtosVar;

namespace NameSpaceVar
{
    public class NameClassVar : Profile
    {
        public NameClassVar()
        {
            CreateMap<NameRequestVar, NameModelDtoVar>();

            CreateMap<NameModelDtoVar, NameResponseVar>();

            CreateMap<NameModelLogDtoVar, NameResponseLogVar>();
        }
    }
}