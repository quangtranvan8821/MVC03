using MVC03.Models;

namespace MVC03.Interface
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMemberAsync();
    }
}