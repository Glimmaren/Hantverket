using HantverketProjectReports.Data;
using HantverketProjectReports.Interfaces;
using HantverketProjectReports.Models;
using Microsoft.EntityFrameworkCore;

namespace HantverketProjectReports.Repositories
{
    public class TimeReportRepository : ITimeReportRepository
    {
        private readonly ProjectReportContext _context;

        public TimeReportRepository(ProjectReportContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTimeReportAsync(TimeReport timeReport)
        {
            try
            {
                await _context.TimeReports.AddAsync(timeReport);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<IList<TimeReport>> GetAllProjectTimeReportsAsync(long projectId)
        {
           return await _context.TimeReports
               .Include(c => c.Project)
               .Where(c => c.ProjectId == projectId).ToListAsync();
        }

        public async Task<IList<TimeReport>> GetProjectTimeReportsBetweenDates(long projectId, DateTime startDateTime, DateTime endDateTime)
        {
            return await _context.TimeReports
                .Include(c => c.Project)
                .Where(c => c.StartTime >= startDateTime && c.EndTime <= endDateTime && c.ProjectId == projectId).ToListAsync();
        }

        public async Task<TimeReport> GetTimeReportByIdAsync(long id)
        {
            return await _context.TimeReports
                .Include(c => c.Project)
                .FirstOrDefaultAsync(c => c.TimeReportId == id);
        }


        public bool UpdateTimeReport(TimeReport timeReport)
        {
            try
            {
                _context.TimeReports.Update(timeReport);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteTimeReport(long id)
        {
            TimeReport? timeReport = _context.TimeReports.Find(id);
            try
            {
                _context.TimeReports.Remove(timeReport);
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
