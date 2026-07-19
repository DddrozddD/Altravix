using Altavix.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Altavix.Application.Features.Auth.Commands.Register;

public class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _configuration;

    public RegisterAdminCommandHandler(UserManager<UserEntity> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new Exception("Passwords do not match.");
        }

        var secretKey = _configuration["AdminRegistrationKey"];
        if (string.IsNullOrEmpty(secretKey) || request.SecretKey != secretKey)
        {
            throw new Exception("Invalid Secret Key for Admin Registration.");
        }

        
        var user = new UserEntity
        {
            Email = request.Email,
            UserName = Guid.NewGuid().ToString(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            PhoneNumber = request.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Failed to create admin: {errors}");
        }

        await _userManager.AddToRoleAsync(user, "Admin");

        return user.Id;
    }
}
