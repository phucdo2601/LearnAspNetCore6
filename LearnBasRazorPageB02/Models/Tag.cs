using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnBasRazorPageB02.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid BlogPostId { get; set; }

        [ForeignKey("BlogPostId")]
        public BlogPost BlogPost { get; set; }
    }
}
