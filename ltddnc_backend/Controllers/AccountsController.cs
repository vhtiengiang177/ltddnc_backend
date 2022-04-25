using ltddnc_backend.Entity;
using ltddnc_backend.Model;
using ltddnc_backend.Repository;
using ltddnc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private AccountsService _accountsService;
        private AccountsRepository _accountsRepository;
        public AccountsController(AccountsService accountsService, DataDbContext dataDbContext)
        {
            this._accountsRepository = new AccountsRepository(dataDbContext);
            _accountsService = accountsService;
        }

        [HttpPost("createaccount")]
        public IActionResult CreateAccount([FromBody] UserAccountParams userAccountParams)
        {
            if (_accountsRepository.IsExistEmail(userAccountParams.Email))
            {
                return BadRequest("Email đã tồn tại.");
            }
            else if (_accountsRepository.IsExistPhone(userAccountParams.Phone))
            {
                return BadRequest("Số điện thoại đã được đăng ký.");
            }
            else
            {
                Account account = new Account();
                account.Email = userAccountParams.Email;
                account.Password = _accountsService.MD5Hash(userAccountParams.Password);
                account.State = 1;
                account.IdRole = userAccountParams.IdRole;


                User user = new User();
                user.Name = userAccountParams.Name;
                user.Phone = userAccountParams.Phone;



                if (_accountsRepository.CreateAccount(account, user) == false)
                {
                    return BadRequest("Tạo tài khoản thất bại.");
                }
            }
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Account accountParams)
        {
            var account = await _accountsRepository.Login(accountParams.Email, _accountsService.MD5Hash(accountParams.Password));
            if (account != null && account.State == 1)
            {
                var user = _accountsRepository.GetUserByID(account.Id);
                return Ok(user);
            }
            else
            {
                return BadRequest("Thông tin đăng nhập không hợp lệ.");
            }
        }

        [HttpGet("getuser")]
        public async Task<ActionResult> GetUser([FromBody] Account accountParams)
        {
            var account = await _accountsRepository.Login(accountParams.Email, _accountsService.MD5Hash(accountParams.Password));
            if (account != null && account.State == 1)
            {
                var user = _accountsRepository.GetUserByID(account.Id);
                return Ok(user);
            }
            else
            {
                return BadRequest("Thông tin đăng nhập không hợp lệ.");
            }
        }
    }
}
