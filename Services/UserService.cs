using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class UserService(ApiDbContext db)
    {
        private readonly ApiDbContext _db = db;

        public async Task<Player> CreatePlayerAsync(string name)
        {
            var player = new Player { Name = name };
            _db.Add(player);
            await _db.SaveChangesAsync();


            var bankAccount = new BankAccount { PlayerId = player.Id };
            _db.Add(bankAccount);
            await _db.SaveChangesAsync();

            return player;
        }

        public async Task<Player?> GetPlayerAsync(long id)
        {
            return await _db.Players
                .Include(p => p.BankAccount)
                .FirstOrDefaultAsync(p => p.Id == id );
        }
    }
}
