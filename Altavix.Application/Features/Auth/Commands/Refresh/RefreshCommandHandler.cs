using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Altavix.Application.Features.Auth.DTOs;
using Altavix.Application.Interfaces;
using Altavix.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Altavix.Application.Features.Auth.Commands.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, AuthResponseDto>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public RefreshCommandHandler(
        UserManager<UserEntity> userManager,
        IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResponseDto> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        // Extract principal from old access token
        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(request.AccessToken))
        {
            throw new Exception("Invalid access token.");
        }

        var jwtToken = handler.ReadJwtToken(request.AccessToken);
        var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;

        if (string.IsNullOrEmpty(emailClaim))
        {
            throw new Exception("Invalid token claims.");
        }

        var user = await _userManager.FindByEmailAsync(emailClaim);
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new Exception("Invalid client request.");
        }

        var newAccessToken = _jwtProvider.Generate(user);
        var newRefreshToken = _jwtProvider.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            Email = user.Email ?? string.Empty,
            Token = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}
