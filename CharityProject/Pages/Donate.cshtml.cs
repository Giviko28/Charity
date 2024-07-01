using CharityProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CharityProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CharityProject.Pages
{
    public class DonateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DonateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Donation Donation { get; set; } =  default!;
        public Post Post { get; private set; } = default!;
        public string UserId { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
            if (post is null)
            {
                return NotFound();
            }
            if (User.Identity?.IsAuthenticated is false)
            {
                return Redirect("/identity/account/login");
            }

            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user is null)
            {
                return Unauthorized();
            }

            Post = post;
            UserId = user.Id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove(nameof(Donation.User));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Donations.Add(Donation);
            await _context.SaveChangesAsync();
            return Redirect("/index");

        }
    }
}
