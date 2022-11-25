namespace HantverketProjectReports.ViewModels.TimeReportViewModels
{
    public class PostTimeReportViewModel
    {
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedDate = DateTime.UtcNow;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Billed { get; set; } = false;

    }
}
