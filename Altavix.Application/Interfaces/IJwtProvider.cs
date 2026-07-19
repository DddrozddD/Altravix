using Altavix.Domain;

namespace Altavix.Application.Interfaces;

public interface IJwtProvider
{
    string Generate(UserEntity user);
    string GenerateRefreshToken();
}
