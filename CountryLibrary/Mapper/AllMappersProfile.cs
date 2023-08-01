using AutoMapper;
using CountryLibrary.Dtos;
using CountryLibrary.Models;

namespace CountryLibrary.Mapper
{
    public class AllMappersProfile : Profile
    {
        public AllMappersProfile() {

            CreateMap<TeamMember, TeamMemberDto>();
        }
    }
}
