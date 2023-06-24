using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC03.Data;
using MVC03.Models;
using MVC03.Interface;

namespace MVC03.Controllers
{
    public class MemberController : Controller
    {
        private readonly MvcContext _context;
        private readonly IMemberRepository _memberRepository;


        public MemberController(MvcContext context, IMemberRepository memberRepository)
        {
            _context = context;
            _memberRepository = memberRepository;

        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            var members = await _memberRepository.GetAllMemberAsync();
            return View(members);
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(string id)
        {

            var member = await _memberRepository.GetMemberAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberName,YearOfBirth,Email,Phone,Gender,MemberPassword")] Member member)
        {
            if (ModelState.IsValid)
            {
                _memberRepository.Create(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tblMember == null)
            {
                return NotFound();
            }

            var member = await _context.tblMember.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
    }
}
