using kolos.Models;
using kolos.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;
        private int result;

        public DbService(MainDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddMembership(int memberId, int teamId)
        {
            var team = _context.Teams.Where(e => e.TeamID == teamId).FirstOrDefault();
            var organization = _context.Organizations.Where(e => e.OrganizationID == team.OrganizationID).FirstOrDefault();

            if (organization == null)
            {
                var member = _context.Members.Where(e => e.MemberID == memberId).FirstOrDefault();

                if (organization.OrganizationID == member.OrganizationID)
                {
                    var newMembership = new Membership()
                    {
                        MemberID = memberId,
                        TeamID = teamId,
                        MembershipDate = DateTime.Now
                    };
                    _context.Memberships.Add(newMembership);
                    await _context.SaveChangesAsync();
                    result = 1;//added member to team

                }

            }
            return 0;//organization and team dont match

        }

        public async Task<int> AddMembership(Member member, int teamId)
        {
            var team = _context.Teams.Where(e => e.TeamID == teamId).FirstOrDefault();
            var organization = _context.Organizations.Where(e => e.OrganizationID == team.OrganizationID).FirstOrDefault();

            if (organization == null)
            {
                if (organization.OrganizationID == member.OrganizationID)
                {
                    var addMember = new Member()
                    {
                        MemberName = member.MemberName,
                        MemberSurname = member.MemberSurname,
                        MemberNickName = member.MemberNickName
                    };
                    _context.Members.Add(addMember);
                    await _context.SaveChangesAsync();

                    var memberId = _context.Members.Where(e => e.MemberName == member.MemberName && e.MemberSurname == member.MemberSurname && e.MemberNickName == member.MemberNickName).FirstOrDefault();
                    var newMembership = new Membership()
                    {
                        MemberID = memberId.MemberID,
                        TeamID = team.TeamID,
                        MembershipDate = DateTime.Now
                    };
                    _context.Memberships.Add(newMembership);
                    await _context.SaveChangesAsync();
                    result = 1;//added user and added member to team

                }

            }
            return 0;//organization and team dont match

        }

        public Task<IEnumerable<TeamGetter>> GetTeamInfo(int teamId)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<TeamGetter>> GetTeamInfo(int teamId){
        /*public async Task<IEnumerable<TeamGetter>> GetTeamInfo(int teamId)
        {
            var team = _context.Teams.Where(e => e.TeamID == teamId).FirstOrDefault();
            var organization = _context.Organizations.Where(e => e.OrganizationID == team.OrganizationID).FirstOrDefault();
            var members = _context.Memberships.Where(e => e.TeamID == team.TeamID);
            var member = _context.Members.Where(e => e.MemberID == member.MemberID);
            if (member == null)
            {

            }
            return await _context.Teams
                .Select(e => new TeamGetter
                {
                    TeamName = team.TeamName,
                    TeamDescription = team.TeamDescription,
                    OrganizationName = organization.OrganizationName,
                    Members = e.Memberships.Select(e => new MemberGetter { MemberName = e.Members.MemberName, MemberSurname = e.Members.MemberSurname, MemberNickName = e.Members.MemberNickName, MembershipDate = e.Membership.MembershipDate }).ToList()
                }).OrderBy(e => e.MembershipDate).ToListAsync();
        }
        */
    }
}