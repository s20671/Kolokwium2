
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Member
    {   [Key]
        public int MemberID { get; set; }
 
        public int OrganizationID { get; set; }
        [Required]
        [MaxLength(20)]
        public string MemberName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MemberSurname { get; set; }
        [MaxLength(20)]
        public string MemberNickName { get; set; }
        public Organization Organization { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
