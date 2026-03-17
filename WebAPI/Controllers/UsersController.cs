using Microsoft.AspNetCore.Mvc;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.DAL.Repositories;

namespace WebAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser user)
        {
            this._user = user;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User userDTO)
        {
            var result = await _user.CreateAsync(userDTO);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User userDTO)
        {
            var result = await _user.UpdateAsync(userDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _user.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _user.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _user.GetByIdAsync(id);
            return Ok(data);
        }
    }
}
