using kolos.Models;
using kolos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace kolos.Controllers
{
    [Route("/api/teams")]
    [ApiController]
    public class MusicControlller : ControllerBase
    {
        private readonly IDbService _dbService;

        public MusicControlller(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        [Route("/api/teams/{teamId}")]

        public async Task<IActionResult> AddMembership(Member member, int teamId)
        {
            int result = await _dbService.AddMembership(member, teamId);
            if (result == 0)
            {
                return BadRequest("Organization and team dont match");
            }
            return Ok("Member added to the team");
        }



        [HttpGet]
        [Route("/api/teams/{teamId}")]
        public async Task<IActionResult> GetTeamInfo(int teamId)
        {
            var teamInfoGetter = await _dbService.GetTeamInfo(teamId);
            return Ok(teamInfoGetter);
        }


    }
    
}