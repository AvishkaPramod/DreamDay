﻿using DreamDay.lb.entities.User;
using DreamDay.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.contracts.Manager
{
    public interface IUserManager
    {
        //Add
        Task<ResponseBase> AddUserAsync(UserRequest request);

        //Update
        Task<ResponseBase> UpdateUserAsync(UserRequest request);

        //List
        Task<ResponseBase> GetAllUserAsync();

        //View
        Task<ResponseBase> ViewUserDetailAsync(UserRequest request);

        //Delete
        Task<ResponseBase> DeleteUserAsync(UserRequest request);
    }
}
