using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HantverketProjectReports.Models
{
    public class TimeReport
    {
        [Key]
        public long TimeReportId { get; set; }
        public long ProjectId { get; set; }
        public long PersonId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ContractorId { get; set; }
        [Required]
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}
