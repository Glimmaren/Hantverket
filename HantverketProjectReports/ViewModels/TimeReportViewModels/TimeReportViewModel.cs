using HantverketProjectReports.Models;

namespace HantverketProjectReports.ViewModels.TimeReportViewModels
{
    public class TimeReportViewModel
    {
        
        public long TimeReportId { get; set; }
        public long ProjectId { get; set; }
        public long PersonId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ContractorId { get; set; }
        public Project? Project { get; set; }
    }
}
