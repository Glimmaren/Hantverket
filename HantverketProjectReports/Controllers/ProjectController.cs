using AutoMapper;
using HantverketProjectReports.Interfaces;
using HantverketProjectReports.Models;
using HantverketProjectReports.ViewModels.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HantverketProjectReports.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(PostProjectViewModel model)
        {
            var projectModel = _mapper.Map<Project>(model);
            if(await _unitOfWork.ProjectRepository.AddProjectAsync(projectModel))
                if (await _unitOfWork.CompleteAsync())
                    return StatusCode(201, model);

            return BadRequest("Could not add company category");
        }

        [HttpGet("companyId")]
        public async Task<IActionResult> GetAllProjects(long companyId)
        {
            var result = await _unitOfWork.ProjectRepository.GetAllProjectsByComapnyIdAsync(companyId);
            if(result.Count < 0) return NotFound("Could not find any projects");

            var response = _mapper.Map<IList<ProjectViewModel>>(result);

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProjectById(long id)
        {
            var result = await _unitOfWork.ProjectRepository.GetProjectByIdAsync(id);
            if(result == null) return NotFound("Could not find any project with Id:" + id);

            var response = _mapper.Map<ProjectViewModel>(result);

            return Ok(response);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            if (_unitOfWork.ProjectRepository.DeleteProject(id))
                if(await _unitOfWork.CompleteAsync()) 
                    return Ok($"Project {id} removed");

            return StatusCode(500, $"Something went wrong deleting project {id}");
        }

        [HttpPatch("id")]
        public async  Task<IActionResult> UpdateProject(long id, PatchProjectViewModel model)
        {
            var toUpdate = await _unitOfWork.ProjectRepository.GetProjectByIdAsync(id);
            if (toUpdate == null) return NotFound($"Could not find any project with id {id}");

            toUpdate.Address = model.Address;
            toUpdate.ZipCode = model.ZipCode;
            toUpdate.City = model.City;

            if (_unitOfWork.ProjectRepository.UpdateProject(toUpdate))
                if(await _unitOfWork.CompleteAsync())
                    return StatusCode(200, $"Project credentials updated");

            return StatusCode(500, "Something went wrong updating project credentials");
        }
    }
}
