using Assigment_PRN222_01.Models;

namespace Assigment_PRN222_01.Service
{
    public class AccountService
    {
        private readonly FunewsManagementContext _context;
        public AccountService(FunewsManagementContext context)
        {
            _context = context;
        }
        public List<SystemAccount> searchAccount(string search)
        {
            var listacc = _context.SystemAccounts.Where(m => m.AccountName.Contains(search)).ToList();
            return listacc;
        }
    }
}
