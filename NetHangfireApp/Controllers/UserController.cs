using BusinessLogic.POCO;
using BusinessLogic.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;
using NetHangfireApp.Hub;
using NetHangfireDB.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetHangfireApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;        
        private IHubContext<UsersHub> _usersHub;
        public UserController(IUserService service, IHubContext<UsersHub> usersHub) 
        {             
            this._userService = service;
            this._usersHub = usersHub;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {            
            return await _userService.GetAllUsers();
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.DateOfBirth = new DateTime(user.NGDateOfBirth.year, user.NGDateOfBirth.month, user.NGDateOfBirth.day);            

            NetHangfireDB.Entities.User usr = new User()
            {
                Address = user.Address,
                DateCreated = DateTime.Now,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
            };

            var jobId = BackgroundJob.Schedule(() => _userService.AddUser(usr), TimeSpan.FromMinutes(5));            
            BackgroundJob.ContinueJobWith<UsersHubHelper>(jobId, m => m.SendData(user));
            return Ok();

        }
    }
}
