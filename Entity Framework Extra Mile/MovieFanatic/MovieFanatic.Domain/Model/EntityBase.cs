using System;
using System.ComponentModel.DataAnnotations;
using MovieFanatic.Utility;

namespace MovieFanatic.Domain.Model
{
    [SoftDelete("IsDeleted")]
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string AddedBy { get; set; }
    }
}