using HantverketProjectReports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace HantverketProjectReports.Data
{
    public class ProjectReportContext : DbContext
    {
        public ProjectReportContext(DbContextOptions<ProjectReportContext> opt) : base(opt)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator dbCreator)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
    }
}
