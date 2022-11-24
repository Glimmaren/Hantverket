using AutoMapper;
using HantverketProjectReports.Models;
using HantverketProjectReports.ViewModels.ProjectViewModels;
using HantverketProjectReports.ViewModels.TimeReportViewModels;

namespace HantverketProjectReports.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Project Mapping
            CreateMap<Project, PostProjectViewModel>();
            CreateMap<PostProjectViewModel,Project>();
            
            CreateMap<Project, PatchProjectViewModel>();
            CreateMap<PatchProjectViewModel, Project>();
            
            CreateMap<Project, ProjectViewModel>();
            CreateMap<ProjectViewModel, Project>();


            //TimeReport Mapping
            CreateMap<TimeReport, TimeReportViewModel>();
            CreateMap<TimeReportViewModel, TimeReport>();

            CreateMap<TimeReport, PostTimeReportViewModel>();
            CreateMap<PostTimeReportViewModel, TimeReport>();

            CreateMap<TimeReport, PatchProjectViewModel>();
            CreateMap<PatchProjectViewModel, TimeReport>();


        }
    }
}
