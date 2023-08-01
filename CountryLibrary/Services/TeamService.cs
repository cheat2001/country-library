using AutoMapper;
using CountryLibrary.Dtos;
using CountryLibrary.Models;
using CountryLibrary.Repositories;


namespace CountryLibrary.Services
{
    public class TeamService : ITeamService
    {

        public static List<TeamMember> teamMembers = new List<TeamMember>
        {
            new TeamMember{Id=1,Name="Ronaldo",Gender="Male",Age=33,Address="Phnom Penh",Email="cr7@gmail.com"},
            new TeamMember{Id=2,Name="Messi",Gender="Male",Age=33,Address="Phnom Penh",Email="messi@gmail.com"},
            new TeamMember{Id=3,Name="Khem",Gender="Female",Age=24,Address="Kompong Cham",Email="khem@gmail.com"},
        };

        private readonly IMapper _mapper;
        public TeamService(IMapper mapper) {
         _mapper = mapper;
        }
        public IEnumerable<TeamMemberDto> GetTeamMembers()
        {
            var members = teamMembers.Select(member => _mapper.Map<TeamMemberDto>(member));
            return members;
        }
    }
}
