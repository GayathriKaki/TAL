using Moq;
using System;
using TAL.EF.Models;
using TAL.ServiceRepo.Services;
using TAL.ServiceRepo.Interfaces;
using Xunit;

namespace TAL.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateTotal_Test1()
        {
            var mockRatingService  = new Mock<IRatingService>();
         
            decimal premium = 1260;
            var member = new Member()
            {
                Name = "Gaya",
                OccupationId = 1,              
                Age = 30,
                DeathSumInsured = 1000
                 
            };
          

            CalculationService calService = new CalculationService(mockRatingService.Object);


            var result = calService.Calculate(member.DeathSumInsured??0, member.OccupationId, member.Age??0).Result;
           

            Assert.NotEqual(premium, result);
        }
    }
}
