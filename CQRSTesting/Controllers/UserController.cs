using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CQRSTesting.ApplicationServices.Queries;
using MediatR;

namespace CQRSTesting.Controllers
{
    using ApplicationServices.Commands;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // This command should be ignored
            await _mediator.Send(new IgnoreMeCommand(), HttpContext.RequestAborted);


            var user = await _mediator.Send(new GetUserByIdQuery(id), HttpContext.RequestAborted);
            return Ok(user);
        }
    }
}
