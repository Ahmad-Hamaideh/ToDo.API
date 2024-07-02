using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Entitis;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.BLL;

namespace ToDoApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ToDoController(IToDoService service) : ControllerBase
{
    private readonly IToDoService _service = service;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetItems()
    {
        var items = await _service.GetItemsAsync();
        return Ok(items);
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var item = await _service.GetItemByIdAsync(id);

        return Ok(item);
    }

    [Authorize]
    [HttpGet("{date:datetime}")]
    public async Task<IActionResult> GetItemByDate(DateTime date)
    {
        var item = await _service.GetItemByDateAsync(date);

        return Ok(item);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] ToDo item)
    {
        _service.AddItemAsync(item);
        return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] ToDo updatedItem)
    {
        var item = await _service.GetItemByIdAsync(id);

        updatedItem.Id = id;
        _service.UpdateItemAsync(updatedItem);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _service.GetItemByIdAsync(id);

        _service.DeleteItemAsync(id);
        return NoContent();
    }
}

