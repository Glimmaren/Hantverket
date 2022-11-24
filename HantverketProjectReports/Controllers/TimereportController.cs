using AutoMapper;
using HantverketProjectReports.Interfaces;
using HantverketProjectReports.Models;
using HantverketProjectReports.ViewModels.TimeReportViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace HantverketProjectReports.Controllers
{
    [Route("api/[controller]")]
    public class TimereportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private DateTime curretDateTime;
        private int daylightSavingOffset = 1;

        public TimereportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeReport(PostTimeReportViewModel model)
        {
            if (model.StartTime > model.EndTime)
                return BadRequest("Start date/time cant be later than end date/time ");
            if (model.StartTime > DateTime.Now || model.EndTime > DateTime.Now)
                return BadRequest("Cant report time in the future");

            var result = _mapper.Map<TimeReport>(model);
            if (await _unitOfWork.TimeReportRepository.AddTimeReportAsync(result))
                if (await _unitOfWork.CompleteAsync())
                    return StatusCode(201, model);

            return BadRequest("Could not add TimeReport");
        }

        [HttpGet("projectId")]
        public async Task<IActionResult> GetProjcetsAllReportsAsync(long projectId)
        {
            var result = await _unitOfWork.TimeReportRepository.GetAllProjectTimeReportsAsync(projectId);
            if (result.Count < 0) return NotFound($"Could not find any report on project {projectId}");

            var response = _mapper.Map<IList<TimeReportViewModel>>(result);

            return Ok(response);
        }

        [HttpGet("reportId")]
        public async Task<IActionResult> GetReportById(long reportId)
        {
            var result = await _unitOfWork.TimeReportRepository.GetTimeReportByIdAsync(reportId);
            if (result == null) return NotFound($"Could not find any report with id {result}");

            var response = _mapper.Map<TimeReportViewModel>(result);

            return Ok(response);
        }

        [HttpGet("projectId/startDate/endDate")]
        public async Task<IActionResult> GetReportBetweenDates(long projectId, DateTime startDate, DateTime endDate)
        {
            curretDateTime = AdjustForDaylightSavingsTime(daylightSavingOffset);
            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            if (startDate > endDate)
                return BadRequest("Start date/time cant be later than end date/time ");
            var result =
                await _unitOfWork.TimeReportRepository.GetProjectTimeReportsBetweenDates(projectId, startDate, endDate);
            if(result.Count < 0) return NotFound($"Could not find any TimeReports between {startDate} and {endDate}");

            var response = _mapper.Map<IList<TimeReportViewModel>>(result);

            return Ok(response);
        }

        [HttpPatch("reportId")]
        public async Task<IActionResult> UpdateTimereport(int reportId, PatchTimereportViewModel model)
        {
            var toUpdate = await _unitOfWork.TimeReportRepository.GetTimeReportByIdAsync(reportId);
            if (toUpdate == null) return NotFound($"Could not find any time report with id: {reportId}");

            toUpdate.StartTime = model.StartTime;
            toUpdate.EndTime = model.EndTime;
            
            if(_unitOfWork.TimeReportRepository.UpdateTimeReport(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("TimeReportUpdated");

            return StatusCode(500, "SomethingWent wrong updating");
        }

        [HttpDelete("reportId")]
        public async Task<IActionResult> DeleteTimeReport(long reportId)
        {
            if(_unitOfWork.TimeReportRepository.DeleteTimeReport(reportId))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("TimeReport deleted");

            return StatusCode(500, "Something went wrong deleting");
        }


        private DateTime AdjustForDaylightSavingsTime(int timeOffsetH)
        { 
            return DateTime.Now.AddHours(timeOffsetH);
        }
    }
}
