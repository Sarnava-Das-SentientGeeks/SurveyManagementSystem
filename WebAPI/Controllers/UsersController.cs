using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.DAL.Repositories;

namespace WebAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public UsersController(IUser user, IMapper _mapper)
        {
            this._user = user;
            this._mapper = _mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
        {
            //Mapping manually
            //var data = new User
            //{
            //    Name = userDTO.Name,
            //    Address = userDTO.Address,
            //};
            
           var userEntity = _mapper.Map<User>(userDTO); //mapping userDTO to userEntity
           var result = await _user.CreateAsync(userEntity);
           return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO userDTO)
        {

            var userEntity = _mapper.Map<User>(userDTO);
            var result = await _user.UpdateAsync(userEntity);
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
