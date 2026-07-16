using System.Data;

namespace Altavix.Application.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
