using System;
using Restaurant_Management_Systems.Models;

namespace Restaurant_Management_Systems.Services;

public interface ICustomerService
{
    public Task<bool> CheckUserExistsAsync(LoginModel loginModel);
    public Task<int?> GetUserRoleIdAsync(LoginModel loginModel);
}
