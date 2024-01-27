using Application.DTOs;
using JobPortal.Application.DataAccess.Services.Auth;
using JobPortal.Domain;
using Microsoft.AspNetCore.Http;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface IUserService : IGenericService<User, UserDTO>
    {
        Task ValidateUser(string userId);
        Task<UpdateAccountResponse> UpdateAccountAsync(UserDTO userDTO);
        Task ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task ResetPasswordAsync(string email);
        Task UploadProfilePictureAsync(string userId, IFormFile file);
        //Task SendPasswordResetEmailAsync(User user, string token);

    }

}