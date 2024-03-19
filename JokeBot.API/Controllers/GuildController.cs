using System.ComponentModel.DataAnnotations;
using JokeBot.API.Authentication;
using JokeBot.API.Repositories.Interfaces;
using JokeBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace JokeBot.API.Controllers;

[ApiController]
[Route("guilds")]
public class GuildController : ControllerBase
{
    private readonly IMongoRepository<GuildModel> _guildRepository;

    public GuildController(IMongoRepository<GuildModel> guildRepository)
    {
        _guildRepository = guildRepository;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var guilds = await _guildRepository.GetAll();

        if (!guilds.Any())
        {
            return NotFound();
        }

        return Ok(guilds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var guild = await _guildRepository.GetById(id);

        if (guild == null)
        {
            return NotFound();
        }

        return Ok(guild);
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(GuildModel guild)
    {
        guild = await _guildRepository.Create(guild);
        return Created(guild.Id, guild);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, GuildModel guild)
    {
        guild = await _guildRepository.Update(id, guild);

        if (id != guild.Id)
        {
            return NotFound();
        }

        return Ok(guild);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _guildRepository.Delete(id);
        return NoContent();
    }
}