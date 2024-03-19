using JokeBot.API.Repositories.Interfaces;
using JokeBot.API.Settings;
using JokeBot.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace JokeBot.API.Repositories;

public class GuildRepository : IMongoRepository<GuildModel>
{
    private readonly IMongoClient _mongoClient;

    public GuildRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<IEnumerable<GuildModel>> GetAll()
    {
        var guilds = await GetCollection().AsQueryable()
            .Where(u => !u.Deleted).ToListAsync();
        return guilds;
    }
    
    public async Task<GuildModel> GetById(string id)
    {
        var guild = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);
        return guild;
    }
    
    public async Task<GuildModel> Create(GuildModel guildModel)
    {
        guildModel.CreatedAt = DateTime.UtcNow;
        guildModel.UpdatedAt = DateTime.UtcNow;
        await GetCollection().InsertOneAsync(guildModel);
        var guildList = await GetCollection().AsQueryable().ToListAsync();
        return guildList.FirstOrDefault(x => x.Id == guildModel.Id);
    }

    public async Task<GuildModel> Update(string id, GuildModel guildModel)
    {
        guildModel.UpdatedAt = DateTime.UtcNow;
        guildModel.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id == id, guildModel);
        return guildModel;
    }

    public async Task Delete(string id, bool hardDelete = false)
    {
        if (hardDelete)
        {
            await GetCollection().DeleteOneAsync(x => x.Id == id);
        }
        else
        {
            await GetCollection().UpdateOneAsync<GuildModel>(x => x.Id == id,
                Builders<GuildModel>.Update.Set(x => x.Deleted, true));
        }
    }
    
    private IMongoCollection<GuildModel> GetCollection()
    {
        var jokeBotDbSettings = new JokeBotDbSettings();
        var database = _mongoClient.GetDatabase(jokeBotDbSettings.DatabaseName);
        var collection = database.GetCollection<GuildModel>(jokeBotDbSettings.Collections[0]);
        return collection;
    }
}