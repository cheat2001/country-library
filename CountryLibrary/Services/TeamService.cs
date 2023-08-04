
using CountryLibrary.Models;
using CountryLibrary.Repositories;


namespace CountryLibrary.Services
{
    public class TeamService : ITeamService
    {

        //This for the hardcode when testing without the database connected
        public static List<TeamMember> teamMembers = new List<TeamMember>
        {
            new TeamMember{Name="Ronaldo",Gender="Male",Age=33,Address="Phnom Penh",Email="cr7@gmail.com"},
            new TeamMember{Name="Messi",Gender="Male",Age=33,Address="Phnom Penh",Email="messi@gmail.com"},
            new TeamMember{Name="Khem",Gender="Female",Age=24,Address="Kompong Cham",Email="khem@gmail.com"},
        };

        public IEnumerable<TeamMember> GetTeamMembers()
        {
            var members = teamMembers.ToList();
            return members;
        }
    }
}
