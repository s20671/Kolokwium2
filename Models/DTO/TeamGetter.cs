using kolos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Models.DTO
{
    public class TeamGetter
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
