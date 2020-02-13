using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WarehousingWebApi.Buildings
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BuildingsController : ControllerBase
    {
        private readonly ILogger<BuildingsController> logger;
        private readonly IMediator mediator;

        public BuildingsController(ILogger<BuildingsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
            logger.LogInformation($"{nameof(BuildingsController)} constructed");
        }
        // GET: api/Building
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(await Task.FromResult(new string[] { "value1", "value2" }));
        }

        // GET: api/Building/5
        [HttpGet("{building-id}", Name = "GetBuilding")]
        public async Task<ActionResult<string>> Get([FromRoute(Name = "building-id")] int id)
        {
            return Ok(await Task.FromResult("value"));
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(BuildingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<BuildingResponse>> SearchBuildings([FromBody] BuildingQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        // POST: api/Building
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string value)
        {
            return CreatedAtAction(nameof(Get), new { id = string.Empty }, null);
            // return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/Building/5
        [HttpPut("{building-id}")]
        public void Put([FromRoute(Name = "building-id")]int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{building-id}")]
        public void Delete([FromRoute(Name = "building-id")]int id)
        {
        }
    }
}