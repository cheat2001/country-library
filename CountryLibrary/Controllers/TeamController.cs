using CountryLibrary.Models;
using CountryLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService) {
            _teamService = teamService;
        }

        [HttpGet("GetTeamMembers")]
        public ActionResult<List<TeamMember>> GetTeamMember() {
            return Ok(_teamService.GetTeamMembers());
        }
    }
}
