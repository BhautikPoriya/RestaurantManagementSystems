using Microsoft.Data.SqlClient;
using Restaurant_Management_Systems.Models;
using Restaurant_Management_Systems.Utiles;

namespace Restaurant_Management_Systems.Services;

public class CustomerService : ICustomerService
{
    #region Fields

    private readonly string _connectionString;
    private readonly IPasswordHelper _passwordHelper;

    #endregion

    #region Ctor

    public CustomerService(IConfiguration configuration, IPasswordHelper passwordHelper)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _passwordHelper = passwordHelper;
    }

    #endregion

    #region Methods

    public async Task<bool> CheckUserExistsAsync(LoginModel loginModel)
    {
        if (loginModel == null) throw new ArgumentNullException(nameof(loginModel));

        var roleId = await GetUserRoleIdAsync(loginModel);
        return roleId.HasValue;
    }

    public async Task<int?> GetUserRoleIdAsync(LoginModel loginModel)
    {
        if (loginModel == null) throw new ArgumentNullException(nameof(loginModel));

        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var command = conn.CreateCommand();

        string sql;
        if (loginModel.UsernamesEnabled)
        {
            sql = $"SELECT RoleId FROM {DatabaseTables.Users} WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @Login AND Password = @Password";
            command.Parameters.AddWithValue("@Login", loginModel.Username ?? string.Empty);
        }
        else
        {
            sql = $"SELECT RoleId FROM {DatabaseTables.Users} WHERE Email COLLATE SQL_Latin1_General_CP1_CS_AS = @Login AND Password = @Password";
            command.Parameters.AddWithValue("@Login", loginModel.Email ?? string.Empty);
        }

        command.CommandText = sql;
        command.Parameters.AddWithValue("@Password", await _passwordHelper.EncyptPasswordAsync(loginModel.Password));

        var result = await command.ExecuteScalarAsync();
        if (result == null || result == DBNull.Value)
            return 0;

        return Convert.ToInt32(result);
    }

    #endregion
}
