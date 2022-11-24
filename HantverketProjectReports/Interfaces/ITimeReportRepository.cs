using HantverketProjectReports.Models;

namespace HantverketProjectReports.Interfaces
{
    public interface ITimeReportRepository : IDisposable
    {
        Task<bool> AddTimeReportAsync(TimeReport timeReport);
        Task<IList<TimeReport>> GetAllProjectTimeReportsAsync(long projectId);
        Task<TimeReport> GetTimeReportByIdAsync(long id);
        Task<IList<TimeReport>> GetProjectTimeReportsBetweenDates(long projectId, DateTime startDateTime, DateTime endDateTime);
        bool DeleteTimeReport(long id);
        bool UpdateTimeReport(TimeReport timeReport);
    }
}
