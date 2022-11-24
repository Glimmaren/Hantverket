using HantverketProjectReports.Interfaces;
using HantverketProjectReports.Models;
using HantverketProjectReports.Repositories;

namespace HantverketProjectReports.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectReportContext _context;

        public UnitOfWork(ProjectReportContext context)
        {
            _context = context;
        }

        public IProjectRepository ProjectRepository => new ProjectRepository(_context);
        public ITimeReportRepository TimeReportRepository =>  new TimeReportRepository(_context);

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }
    }
}
