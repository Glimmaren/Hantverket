using HantverketProjectReports.Data;
using HantverketProjectReports.Interfaces;
using HantverketProjectReports.Models;
using Microsoft.EntityFrameworkCore;

namespace HantverketProjectReports.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectReportContext _context;
 

        public ProjectRepository(ProjectReportContext context)
        {
            _context = context;
            
        }

        public async Task<bool> AddProjectAsync(Project project)
        {
            try
            {
                await _context.AddAsync(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<IList<Project>> GetAllProjectsByComapnyIdAsync(long companyid)
        {
            return await _context.Projects.Where(c => c.CompanyId == companyid).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(long id)
        {
            return await _context.Projects.FirstOrDefaultAsync(c => c.ProjectId == id);
        }

        public bool UpdateProject(Project project)
        {
            try
            {
                _context.Projects.Update(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteProject(long id)
        {
            var project = _context.Projects.Find(id);

            try
            {
                _context.Projects.Remove(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
