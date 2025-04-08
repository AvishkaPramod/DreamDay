using AutoMapper;
using DreamDay.lb.business.Wrapper;
using DreamDay.lb.entities.User;
using DreamDay.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.business.Mapper
{
    public class UserSaveRequestMapper: IMapper<UserRequestWrapper, UserSaveRequest>
    {
        public UserSaveRequestMapper() { }

        public UserSaveRequest Map(UserRequestWrapper input)
        {
            return new UserSaveRequest()
            {
                UserID = input.Request.Attributes.UserID,
                FirstName = input.Request.Attributes.FirstName,
                LastName = input.Request.Attributes.LastName,
                Email = input.Request.Attributes.Email,
                UserName = input.Request.Attributes.UserName,
                Password = input.Request.Attributes.Password,
                Role = input.Request.Attributes.Role,
                CreateDate = DateTime.Now
            };
        }
    }
}
