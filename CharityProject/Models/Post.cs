using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CharityProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        [Range(1,10000)]
        public int DonationGoal { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }

        [ValidateNever]
        public ICollection<Donation> Donations { get; set; }
    }
}
