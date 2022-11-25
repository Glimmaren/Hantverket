using HantverketProjectReports.Models;

namespace HantverketProjectReports.ViewModels.TimeReportViewModels
{
    public class TimeReportViewModel
    {
        
        public long TimeReportId { get; set; }
        public long ProjectId { get; set; }
        public long ÚserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Billed { get; set; }
        public Project? Project { get; set; }
    }
}
