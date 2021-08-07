using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAL.EF.Models
{
    [Table("Occupation")]
    public partial class Occupation
    {
        public Occupation()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        public int OccupationId { get; set; }
        [StringLength(50)]
        public string OccupationName { get; set; }
        public int RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        [InverseProperty("Occupations")]
        public virtual Rating Rating { get; set; }
        [InverseProperty(nameof(Member.Occupation))]
        public virtual ICollection<Member> Members { get; set; }
    }
}
