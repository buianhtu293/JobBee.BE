using JobBee.Application.Features.Role.Commands.CreateRole;
using JobBee.Application.Features.Role.Commands.DeleteRole;
using JobBee.Application.Features.Role.Commands.UpdateRole;
using JobBee.Application.Features.Role.Queries.GetAllRoles;
using JobBee.Application.Features.Role.Queries.GetRoleDetails;
using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobBee.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RolesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<RolesController>
		[HttpGet]
		public async Task<ApiResponse<List<RoleDto>>> Get()
		{
			var roles = await _mediator.Send(new GetAllRoleQuery());
			return roles;
		}

		// GET api/<RolesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ApiResponse<RoleDetailsDto>>> Get(Guid id)
		{
			var role = await _mediator.Send(new GetRoleDetailsQuery(id));
			return Ok(role);
		}

		// POST api/<RolesController>
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ApiResponse<CreateRoleDto>> Post([FromBody] CreateRoleCommand createRoleCommand)
		{
			var response = await _mediator.Send(createRoleCommand);
			return response;
		}

		// PUT api/<RolesController>/5
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ApiResponse<UpdateRoleDto>> Put([FromBody] UpdateRoleCommand updateRoleCommand)
		{
			var command = await _mediator.Send(updateRoleCommand);
			return command;
		}

		// DELETE api/<RolesController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new DeleteRoleCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
