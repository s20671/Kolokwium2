using kolos.Models;
using kolos.Models.DTO;
using kolos.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolos.Models
{
    public interface IDbService
    {
        Task<IEnumerable<TeamGetter>> GetTeamInfo(int teamId);
        Task<int> AddMembership(int memberId, int teamId);
        Task<int> AddMembership(Member member, int teamId);
    }
}
