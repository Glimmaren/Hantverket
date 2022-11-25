using System.Linq.Expressions;
using HantverketProjectReports.Models;

namespace HantverketProjectReports.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        Task<bool> AddProjectAsync (Project project);
        Task<IList<Project>> GetAllProjectsByComapnyIdAsync (long companyId);
        Task<Project> GetProjectByIdAsync (long id);
        bool DeleteProject (long id);
        bool UpdateProject (Project project);
    }
}
