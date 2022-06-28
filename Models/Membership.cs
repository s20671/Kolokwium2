
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public System.DateTime MembershipDate { get; set; }
        public Team Teams { get; set; }
        public Member Members { get; set; }
        public object Memberships { get; internal set; }
    }
}
