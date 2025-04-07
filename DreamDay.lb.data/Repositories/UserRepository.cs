using DreamDay.lb.contracts.Repositories;
using DreamDay.lb.dbcontext.tables.Models;
using DreamDay.lb.entities.User;
using DreamDay.lb.shared.Contracts;
using DreamDay.lb.shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.data.Repositories
{
    public class UserRepository: IUserRepository
    {
        // The Db Context
        private readonly DreamDayContext _dreamDayContext;

        // The entity mapper
        private readonly IEntityMapper _entityMapper;

        //ILogger for log errors
        private readonly ILogger<UserRepository> _logger;

        //Constructor
        public UserRepository(DreamDayContext dreamDayContext, IEntityMapper entityMapper, ILogger<UserRepository> logger)
        {
            _dreamDayContext = dreamDayContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        //Add User
        public async Task<UserResponse> SaveUserAsync(UserSaveRequest request)
        {
            try
            {
                var UserDetails = _entityMapper.Map<UserSaveRequest, user>(request);
                var UserResponse = _dreamDayContext.users.Add(UserDetails).Entity;
                await _dreamDayContext.SaveChangesAsync();

                return _entityMapper.Map<user, UserResponse>(UserResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<UserResponse> UpdateUserAsync(UserSaveRequest request)
        {
            try
            {
                var User = await _dreamDayContext.users.FirstOrDefaultAsync(i => i.UserID == request.UserID);
                User.FirstName = request.FirstName;
                User.LastName = request.LastName;
                User.Email = request.Email;
                User.UserName = request.UserName;
                User.Password = request.Password;
                User.Role = request.Role;


                _dreamDayContext.SaveChanges();

                return _entityMapper.Map<user, UserResponse>(User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<List<UserResponse>> GetAllUserAsync()
        {
            try
            {
                var Users = await _dreamDayContext.users
               .Select(u => new UserResponse
               {
                   UserID = u.UserID,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Email = u.Email,
                   UserName = u.UserName,
                   Password = u.Password,
                   Role = u.Role
               }).ToListAsync();

                return Users;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<UserResponse> GetUserDetailAsync(UserAttributes request)
        {
            try
            {
                var User = await _dreamDayContext.users
                .Where(u => u.UserID == request.UserID)
                .Select(u => new UserResponse
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    UserName = u.UserName,
                    Password = u.Password,
                    Role = u.Role

                }).FirstOrDefaultAsync();

                return User;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<UserResponse> DeleteUserAsync(UserAttributes request)
        {
            try
            {
                var UserObj = await _dreamDayContext.users.FirstOrDefaultAsync(x => x.UserID == request.UserID);
                _dreamDayContext.users.Remove(UserObj);
                _dreamDayContext.SaveChanges();

                return _entityMapper.Map<user, UserResponse>(UserObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
