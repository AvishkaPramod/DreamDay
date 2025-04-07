using DreamDay.lb.entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.contracts.Repositories
{
    public interface IUserRepository
    {
        // Add 
        Task<UserResponse> SaveUserAsync(UserSaveRequest request);

        //Update 
        Task<UserResponse> UpdateUserAsync(UserSaveRequest request);

        //List 
        Task<List<UserResponse>> GetAllUserAsync();

        //View 
        Task<UserResponse> GetUserDetailAsync(UserAttributes request);

        //Delete 
        Task<UserResponse> DeleteUserAsync(UserAttributes request);
    }
}
