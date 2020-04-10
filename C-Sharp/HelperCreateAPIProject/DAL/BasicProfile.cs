using AutoMapper;
using NSpaceModelsDtosVar;
using NSpaceModelsVar;

namespace NameSpaceVar
{
    public class NameClassVar : Profile
    {
        public NameClassVar()
        {
            CreateMap<NameModelVar, NameModelDtoVar>();

            CreateMap<NameModelDtoVar, NameModelVar>();
        }
    }
}
