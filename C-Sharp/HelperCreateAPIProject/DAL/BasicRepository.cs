using System.Threading.Tasks;
using ModelsDtosNSpaceVar;
using ContextsNSpaceVar;

namespace NameSpaceVar
{
    public class NameClassVar : NameInterfaceVar
    {
        private readonly NameContextVar _context;
        public NameClassVar(NameContextVar context)
        {
            _context = context;
        }

        public async Task<NameModelDtoVar> Get()
        {
            var response = new NameModelDtoVar
            {
                Id = "NameModelDtoVar",
                Property = "Property"
            };
            return response;
        }
    }
}
