using System.Threading.Tasks;
using ModelsDtosNSpaceVar;

namespace NameSpaceVar
{
    public interface NameClassVar
    {
        Task<NameModelDtoVar> Get();
    }
}
