using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class BankService(ApiDbContext db)
    {
        private readonly ApiDbContext _db = db;

        public async Task DepositAsync(long playerId, long amount, string source = "Deposit")
        {
            var account = await _db.BankAccounts
                .FirstOrDefaultAsync(a => a.PlayerId == playerId);

            if (account == null)
                throw new Exception("Bank account not found.");

            account.Balance += amount;

            _db.BankTransaсtions.Add(new BankTransaсtion
            {
                BankAccountId = account.Id,
                Amount = amount,
                Source = source,
            });

            await _db.SaveChangesAsync();
        }

        public async Task WithdrawAsync(long playerId, long amount, string source = "Withdraw")
        {
            var account = await _db.BankAccounts
                .FirstOrDefaultAsync(a => a.PlayerId == playerId);

            if (account == null)
                throw new Exception("Bank account not found.");

            if (account.Balance < amount)
                throw new InvalidOperationException("Insufficient funds.");

            account.Balance -= amount;

            _db.BankTransaсtions.Add(new BankTransaсtion
            {
                BankAccountId = account.Id,
                Amount = -amount,
                Source = source,
            });

            await _db.SaveChangesAsync();
        }

        public async Task<long> GetBalanceAsync(long playerId)
        {
            var account = await _db.BankAccounts
                .FirstOrDefaultAsync(a => a.PlayerId == playerId);

            return account?.Balance ?? 0;
        }
    }
}
