using BankingConsoleApp.Models;

namespace BankingConsoleApp.Repositories
{
    public interface IAccountRepository
    {
        // Load all accounts from file (async)
        Task<List<Account>> LoadAccountsAsync();

        // Save all accounts to file (async)
        Task SaveAccountsAsync(List<Account> alstAccounts);

        // Load all transactions from file (async)
        Task<List<Transaction>> LoadTransactionsAsync();

        // Save all transactions to file (async)
        Task SaveTransactionsAsync(List<Transaction> alstTransactions);
    }
}