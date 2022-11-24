using System.ComponentModel.DataAnnotations;

namespace HantverketProjectReports.Models
{
    public class Project
    {
        [Key]
        public long ProjectId { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
    }
}
