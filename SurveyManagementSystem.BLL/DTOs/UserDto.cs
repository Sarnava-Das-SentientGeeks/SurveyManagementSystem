using SurveyManagementSystem.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagementSystem.BLL.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
       
    }
}
