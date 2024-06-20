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
        public async Task OnGet(int id)
        {
            Post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
        }
    }
}
