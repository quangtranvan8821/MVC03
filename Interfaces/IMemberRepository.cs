using MVC03.Models;

namespace MVC03.Interface
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMemberAsync();

        Task<Member> GetMemberAsync(string id);

        bool Create(Member member);
        bool Edit(Member member);
    }
}