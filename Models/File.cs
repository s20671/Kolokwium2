
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class File
    {
        public int FileID { get; set; }
        public int TeamID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public Team Teams { get; set; }
    }
}
