using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAL.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {


            CreateMap<TAL.EF.Models.Occupation, TAL.ServiceRepo.Models.Occupation>().ReverseMap();
            //.ForMember(dest => dest.OccupationId, src => src.MapFrom(t => t.OccupationId))
            //.ForMember(dest => dest.OccupationName, src => src.MapFrom(t => t.OccupationName)).ReverseMap();


            CreateMap<TAL.EF.Models.Member, TAL.ServiceRepo.Models.Member>().ForMember(dest => dest.Premium, src => src.MapFrom(t => t.TotalValue)).ReverseMap();



        }

    }
}
