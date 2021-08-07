using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAL.EF.Models
{
    [Table("Rating")]
    public partial class Rating
    {
        public Rating()
        {
            Occupations = new HashSet<Occupation>();
        }

        [Key]
        public int RatingId { get; set; }
        [StringLength(50)]
        public string RatingName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Factor { get; set; }

        [InverseProperty(nameof(Occupation.Rating))]
        public virtual ICollection<Occupation> Occupations { get; set; }
    }
}
