using HantverketProjectReports.Models;

namespace HantverketProjectReports.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository ProjectRepository { get; }
        ITimeReportRepository TimeReportRepository { get; }

        Task<bool> CompleteAsync();
        bool HasChanges();
    }
}
