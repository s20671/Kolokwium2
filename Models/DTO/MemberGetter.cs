using kolos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Models.DTO
{
    public class MemberGetter
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
