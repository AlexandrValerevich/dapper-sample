using DapperSample.Api.Interfaces;
using DapperSample.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperSample.Controllers;

[ApiController]
[Route("[controller]")]
public class FruitsController : ControllerBase
{
    private readonly IRepository<Fruit> _repository;

    public FruitsController(IRepository<Fruit> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.ReadAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _repository.ReadAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Fruit fruit)
    {
        if (ModelState.IsValid)
        {
            var createdFtuit = await _repository.CreateAsync(fruit);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUrl + "/fruits/" + createdFtuit.Id;

            return Created(location, createdFtuit);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Fruit fruit)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateAsync(fruit);
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        if (ModelState.IsValid)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }

        return BadRequest();
    }
}
