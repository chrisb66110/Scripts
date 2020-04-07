using System.Threading.Tasks;
using ModelsDtosNSpaceVar;
using RepositoriesNSpaceVar;

namespace NameSpaceVar
{
    public class NameClassVar : NameInterfaceVar
    {
        private readonly InterfaceRepository _nameRepostory;

        public NameClassVar(InterfaceRepository nameRepostory)
        {
            _nameRepostory = nameRepostory;
        }

        public async Task<NameModelDtoVar> Get()
        {
            var response = await _nameRepostory.Get();

            return response;
        }
    }
}
