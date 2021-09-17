using System.Net.Mime;
using ApiSqlite.Data;
using ApiSqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlite.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CrudController<T> : ControllerBase where T : Entity
    {
        private readonly IDataService<T> _items;
        protected CrudController(IDataService<T> items)
        {
            _items = items;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            return Ok(await _items.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<ActionResult<T>> Get(string id)
        {
            return Ok(await _items.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<T>> PostTaskAsync([FromBody] T payload)
        {
            var res = await _items.Add(payload);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> DeleteTaskAsync(string id)
        {
            var item = await _items.Get(id);
            if(item == null) return BadRequest();

            await _items.Delete(item);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<T>> UpdateTaskAsync(string id, [FromBody] T payload)
        {
            if(payload == null) return BadRequest();

            var res = await _items.Update(payload);
            return Ok(res);
        }
    }
}