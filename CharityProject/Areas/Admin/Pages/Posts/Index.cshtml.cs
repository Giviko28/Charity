using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CharityProject.Data;
using CharityProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CharityProject.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly CharityProject.Data.ApplicationDbContext _context;
        public IndexModel(CharityProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();
        }
    }
}
