using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CharityProject.Models
{
    public class Donation
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public IdentityUser? User { get; set; } = null!;

        public Donation()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
