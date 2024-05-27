using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueBlog.Server.Data.Models
{
    [Table("Articles")]
    public class Article
    {
        // <summary>
        /// The unique id and primary key for this Article
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Article image
        /// </summary>
        public required string Image { get; set; }

        /// <summary>
        /// Article image
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Article image
        /// </summary>
        public required string Summary { get; set; }

        /// <summary>
        /// Article image
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Article image
        /// </summary>
        public DateTime Date { get; set; }
    }
}
