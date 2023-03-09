using Microsoft.Extensions.Logging;
using System.Data;
using TicTacToeApi.Bll.Models;
using TicTacToeApi.Bll.Services.Contracts;
using TicTacToeApi.Dal.Entities;
using TicTacToeApi.Dal.Repos.Contract;
using BC = BCrypt.Net.BCrypt;

namespace TicTacToeApi.Bll.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<UserService> _logger;
        private readonly IRoleRepo _rolesRepo;

        public UserService(IUserRepo userRepo, IRoleRepo rolesRepo, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
            _rolesRepo = rolesRepo;
        }


        public async Task DeleteAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "'{userId}' can't be empty.");
            }

            await _userRepo.DeleteAsync(userId);
        }

        public async Task<BaseUserModel?> GetUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            UserEntity? userEntity = await _userRepo.FindByEmailAsync(email);

            if (userEntity == null)
            {
                return null;
            }

            if (!BC.Verify(password, userEntity.PasswordHash))
            {
                return null;
            };

            return new BaseUserModel()
            {
                Email = userEntity.Email,
                Nickname = userEntity.NickName,
                Roles = userEntity.Roles.Select(_ => _.Name).ToArray()
            };
        }

        public async Task RegisterUserAsync(AddUserModel user)
        {
            _logger.LogInformation("Start registration for a new user.");

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            // create Only customers

            UserEntity newUser = new()
            {
                Email = user.Email,
                NickName = user.NickName,
                PasswordHash = BC.HashPassword(user.Password)
            };

            _logger.LogInformation("New user is ready. Add roles");
            newUser.Roles ??= new List<RoleEntity>();

            RoleEntity? playerRole = await _rolesRepo.FindByNameAsync(Constants.PlayerRoleName);

            if (playerRole == null)
            {
                _logger.LogCritical("Role can't be finded. Create new custemer impossible.");
                throw new Exception($"Role: {Constants.PlayerRoleName}, can't be finded.");
            }

            newUser.Roles.Add(playerRole);

            _logger.LogInformation("Roles applied successfully.");

            await _userRepo.AddAsync(newUser);

            _logger.LogInformation("User has been created successfully.");
        }

    }
}
