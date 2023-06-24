using Microsoft.EntityFrameworkCore;
using MVC03.Interface;
using MVC03.Data;
using MVC03.Models;

namespace MVC03.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MvcContext _context;

        public MemberRepository(MvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllMemberAsync()
        {
            return await _context.Members.ToListAsync<>;
        }
    }
}