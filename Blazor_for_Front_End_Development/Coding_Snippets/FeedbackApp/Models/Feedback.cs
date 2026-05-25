using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Name is Required.")]
        public string? Name {get; set;}

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email {get; set;}

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment {get; set;}
    }
}