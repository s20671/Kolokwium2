
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(500)]
        public string TeamDescription { get; set; }
        public Organization Organization { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
