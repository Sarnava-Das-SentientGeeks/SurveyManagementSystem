using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRole _role;
        public RolesController(IRole role) => _role = role;


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role roleDTO)
        {
            var result = await _role.CreateRole(roleDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Role roleDTO)
        {
            var result = await _role.UpdateRole(roleDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _role.DeleteRole(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _role.GetRoleById(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _role.GetRoles();
            return Ok(data);
        }



    }
}
