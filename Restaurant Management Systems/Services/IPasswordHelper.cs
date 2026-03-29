using System;

namespace Restaurant_Management_Systems.Services;

public interface IPasswordHelper
{
    public Task<string> EncyptPasswordAsync(string password);

    public Task<string> DecryptPasswordAsync(string password);
}
