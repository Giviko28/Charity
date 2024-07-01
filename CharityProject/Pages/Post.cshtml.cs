using CharityProject.Data;
using CharityProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CharityProject.Pages
{
    public class PostModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Post Post { get; set; }

        public PostModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var post = await _context.Posts
                .Include(p => p.Donations)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(post => post.Id == id);
            if (post is null)
            {
                return NotFound();
            }
            Post = post;

            return Page();
        }
    }
}
