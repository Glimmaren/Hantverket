namespace HantverketProjectReports.ViewModels.TimeReportViewModels
{
    public class PostTimeReportViewModel
    {
        public long ProjectId { get; set; }
        public long PersonId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ContractorId { get; set; }
    }
}
