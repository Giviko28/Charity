using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int DonationGoal { get; set; }
        [ForeignKey("IdentityUser")]
        public IdentityUser User { get; set; }

    }
}
