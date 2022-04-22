using ltddnc_backend.Entity;
using ltddnc_backend.Model;
using ltddnc_backend.Repository;
using ltddnc_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private AccountService _accountsService;
        private AccountsRepository _accountsRepository;
        public AccountsController(AccountService accountsService)
        {
            this._accountsRepository = new AccountsRepository(new DataDbContext());
            _accountsService = accountsService;
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody] UserAccountParams userAccountParams)
        {
            if (_accountsRepository.IsExistEmail(userAccountParams.Email))
            {
                return BadRequest("Email đã tồn tại.");
            }
            else
            {
                Account account = new Account();
                account.Email = userAccountParams.Email;
                account.Password = userAccountParams.Password;
                account.State = 1;
                account.IdRole = userAccountParams.IdRole;


                User user = new User();
                user.Name = userAccountParams.Name;
                user.Phone = userAccountParams.Phone;


                _accountsRepository.CreateAccount(account, user);

                if (_accountsRepository.Save() == false)
                {
                    return BadRequest("Tạo tài khoản thất bại.");
                }
            }
            return Ok();
        }
    }
}
