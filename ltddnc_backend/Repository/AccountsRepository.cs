using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class AccountsRepository
    {
        private DataDbContext _dbContext;

        public AccountsRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public Account GetAccountByID(int accountID)
        {
            return _dbContext.Accounts.FirstOrDefault(p => p.Id == accountID && p.State > 0);
        }

        public Account CreateAccount(Account account, User user)
        {
            try
            {
                var result = _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public bool IsExistPhone(string phone)
        {
            if (_dbContext.Users.Where(a => a.Phone == phone).Count() > 0)
                return true;
            return false;
        }

        public void UpdateAccount(Account account)
        {
            _dbContext.Attach(account);
            _dbContext.Entry(account).State = EntityState.Modified;
        }

        public async Task<Account> Login(string email, string password)
        {
            Account account = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return account;
        }

        public bool IsExistEmail(string email)
        {
            // Kiểm tra tồn tại email cho việc tạo tài khoản mới nên không xét State
            if (_dbContext.Accounts.Where(a => a.Email == email).Count() > 0)
                return true;
            return false;
        }

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
