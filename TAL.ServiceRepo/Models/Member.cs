using System;
using System.Collections.Generic;
using System.Text;

namespace TAL.ServiceRepo.Models
{
   public class Member
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int OccupationId { get; set; }     
        public int DeathSumInsured { get; set; }
        public decimal Premium { get; set; }
        public decimal MonthlyExpenses { get; set; }
        public int StateId { get; set; }

       
    }
}
