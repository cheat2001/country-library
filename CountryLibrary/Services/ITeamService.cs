
using CountryLibrary.Models;

namespace CountryLibrary.Repositories
{
    public interface ITeamService
    {
        public IEnumerable<TeamMember> GetTeamMembers();
    }
}
