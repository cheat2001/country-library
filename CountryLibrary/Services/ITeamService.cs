using CountryLibrary.Dtos;
using CountryLibrary.Models;

namespace CountryLibrary.Repositories
{
    public interface ITeamService
    {
        public IEnumerable<TeamMemberDto> GetTeamMembers();
    }
}
