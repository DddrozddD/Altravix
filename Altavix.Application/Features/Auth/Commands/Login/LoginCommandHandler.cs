using Altavix.Application.Features.Auth.DTOs;
using Altavix.Application.Interfaces;
using Altavix.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Altavix.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        UserManager<UserEntity> userManager,
        IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("Invalid email or password.");
        }

        var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isValidPassword)
        {
            throw new Exception("Invalid email or password.");
        }

        var token = _jwtProvider.Generate(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // 7 days valid
        await _userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            Email = user.Email ?? string.Empty,
            Token = token,
            RefreshToken = refreshToken
        };
    }
}
