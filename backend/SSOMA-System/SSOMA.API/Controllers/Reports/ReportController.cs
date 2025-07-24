using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSOMA.Application.DTOs.Report;
using SSOMA.Application.Features.Reports.Commands;
using SSOMA.Application.Features.Reports.Queries;

namespace SSOMA.API.Controllers.Reports
{
    [Authorize]
    public class ReportsController : BaseController
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportRequestDto reportDto)
        {
            var userId = GetUserId();

            var command = new CreateReportCommand(reportDto, userId);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetReportByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}