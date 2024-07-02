using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using CharityProject.Data;
using CharityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CharityProject.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly CharityProject.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(CharityProject.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            if (id is null)
            {
                return Page();
            }

            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post is null)
            {
                return NotFound();
            }

            Post = post;

            return Page();

        }

        [BindProperty(SupportsGet = true)]
        public Post Post { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile? file)
        {
            if (!ModelState.IsValid || (file is null && Post.Id == 0))
            {
                return Page();
            }

            if (file is not null)
            {
                string wwwRoot = _webHostEnvironment.WebRootPath;
                string imageDirectory = Path.Combine(wwwRoot, @"images/post");

                if (!string.IsNullOrEmpty(Post.ImageURL))
                {
                    var oldImagePath = Path.Combine(wwwRoot, Post.ImageURL.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                using (var fileStream = new FileStream(Path.Combine(imageDirectory, filename), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                Post.ImageURL = @"/images/post/" + filename;
            }

            if (Post.Id == 0)
            {
                _context.Posts.Add(Post);
            }
            else
            {
                _context.Posts.Update(Post);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
