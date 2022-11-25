using HantverketProjectReports.Models;

namespace HantverketProjectReports.ViewModels.ProjectViewModels
{
    public class ProjectViewModel
    {
        public long ProjectId { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
    }
}
