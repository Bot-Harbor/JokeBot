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
    
    [HttpGet("{id}")]
    [ServiceFilter(typeof(GuildApiKeyFilter))]
    public async Task<IActionResult> GetById(string id, [FromHeader(Name = "x-api-key")] [Required] string header)
    {
        var guild = await _guildRepository.GetById(id);

        if (guild == null)
        {
            return NotFound();
        }

        return Ok(guild);
    }

    [HttpPost("")]
    [ServiceFilter(typeof(GuildApiKeyFilter))]
    public async Task<IActionResult> Create(GuildModel guild, [FromHeader(Name = "x-api-key")] [Required] string header)
    {
        guild = await _guildRepository.Create(guild);
        return Created(guild.Id, guild);
    }

    [HttpPut("{id}")]
    [ServiceFilter(typeof(GuildApiKeyFilter))]
    public async Task<IActionResult> Update(string id, GuildModel guild, [FromHeader(Name = "x-api-key")] [Required] string header)
    {
        guild = await _guildRepository.Update(id, guild);

        if (id != guild.Id)
        {
            return NotFound();
        }

        return Ok(guild);
    }
    
    [HttpDelete("{id}")]
    [ServiceFilter(typeof(GuildApiKeyFilter))]
    public async Task<IActionResult> Delete(string id, [FromHeader(Name = "x-api-key")] [Required] string header, bool hardDelete = false)
    {
        await _guildRepository.Delete(id, hardDelete);
        return NoContent();
    }
}