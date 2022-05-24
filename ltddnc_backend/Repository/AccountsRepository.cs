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

        public bool CreateAccount(Account account, User user)
        {
            try
            {
                var result = _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();

                user.IdAccount = result.Entity.Id;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int IsExistPhone(string phone)
        {
            return _dbContext.Users.Where(a => a.Phone == phone).Count();
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

        public int IsExistEmail(string email)
        {
            // Kiểm tra tồn tại email cho việc tạo tài khoản mới nên không xét State
            return _dbContext.Accounts.Where(a => a.Email == email).Count();
        }

        public User GetUserByID(int idAccount)
        {
            return _dbContext.Users.FirstOrDefault(p => p.IdAccount == idAccount);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Attach(user);
            _dbContext.Entry(user).State = EntityState.Modified;
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
