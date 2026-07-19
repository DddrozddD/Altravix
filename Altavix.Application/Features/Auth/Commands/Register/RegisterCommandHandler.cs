using Altavix.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Altavix.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly UserManager<UserEntity> _userManager;

    public RegisterCommandHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new Exception("Passwords do not match.");
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
            throw new Exception($"Failed to create user: {errors}");
        }

        await _userManager.AddToRoleAsync(user, "User");

        return user.Id;
    }
}
