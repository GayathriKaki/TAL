using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAL.EF.Models
{
    [Table("Member")]
    public partial class Member
    {
        [Key]
        public int MemberId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateofBirth { get; set; }
        public int? Age { get; set; }
        public int OccupationId { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeathSumInsured { get; set; }
        [Column(TypeName = "money")]
        public decimal? MonthlyExpenses { get; set; }
        public int? StateId { get; set; }
        public int? PostCode { get; set; }

        [ForeignKey(nameof(OccupationId))]
        [InverseProperty("Members")]
        public virtual Occupation Occupation { get; set; }


        public decimal TotalValue { get; set; }
    }
}
