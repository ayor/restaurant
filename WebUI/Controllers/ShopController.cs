using System.Threading.Tasks;
using Application.Features.Shops.Commands.CreateShop;
using Application.Features.Shops.Commands.DeleteShop;
using Application.Features.Shops.Commands.UpdateShop;
using Application.Features.Shops.Queries.GetAllShops;
using Application.Features.Shops.Queries.GetShopById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ShopController : BaseController
    {
        [HttpGet, Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllShopsParameter filter)
        {
            var query = await Mediator.Send(new GetAllShopsQuery
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            });
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = await Mediator.Send(new GetShopByIdQuery(id));
            return Ok(query);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShopCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShopCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = await Mediator.Send(new GetShopByIdQuery(id));
            return Ok(await Mediator.Send(new DeleteShopCommand(query)));
        }
    }
}