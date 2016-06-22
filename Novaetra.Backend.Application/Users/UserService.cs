using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Novaetra.Backend.Entities;
using Novaetra.Backend.Users.Dto;

namespace Novaetra.Backend.Users
{
    public class UserService : BackendAppServiceBase, IUserService
    {
        //These members set in constructor using constructor injection.

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<User> _userRepository;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public UserService(IRepository<Account> accountRepository, IRepository<User> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public GetUserOutput GetUsers(GetUserInput input)
        {
            var query = _userRepository.GetAll();
            List<User> users = query.Where(u => u.DisplayName.ToLower().StartsWith(input.SearchString)).OrderBy(u => u.DisplayName).ToList();

            return new GetUserOutput
            {
                Users = Mapper.Map<List<UserDto>>(users)
            };
        }

        public void UpdateUser(UpdateUserInput input)
        {
            Logger.Info("Updating a user for input: " + input);
            var user = _userRepository.Get(input.UserId);

            user.DisplayName = input.DisplayName ?? user.DisplayName;
            user.Email = input.Email ?? user.Email;

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
        }

        public void CreateUser(CreateUserInput input)
        {
            Logger.Info("Creating a user for input: " + input);


            User existing = _userRepository.GetAll()
                .First(u => u.DisplayName.Equals(input.DisplayName, StringComparison.CurrentCultureIgnoreCase));
            if (existing != null)
                throw new UserFriendlyException(L("UserWithDisplayNameAlreadyExists")); // TODO: Replace this with a CreateUserOutput

            var user = new User { DisplayName = input.DisplayName, Email = input.Email };
            var account = new Account
            {
                IterationCount = input.IterationCount,
                PasswordHash = input.PasswordHash,
                Salt = input.Salt
            };
            user.Account = account;

            _userRepository.Insert(user);
        }
    }
}