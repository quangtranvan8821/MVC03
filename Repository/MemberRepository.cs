using Microsoft.AspNetCore.Mvc;
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
            return await _context.tblMember!.ToListAsync();
        }

        public async Task<Member> GetMemberAsync(string id)
        {
            return await _context.tblMember!.FirstOrDefaultAsync(i => i!.MemberName == id);
        }


        public bool Edit(Member member)
        {
            _context.Update(member);
            return Save();
        }

        public bool Create(Member member)
        {
            _context.Add(member);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}