using System.ComponentModel.DataAnnotations;
namespace quizzer_backend.Models
{
    public class SimpleUser : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
