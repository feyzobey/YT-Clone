using VideoClone.Core.Entities.Concrete;

namespace VideoClone.Core.Utilities.Security.Jwt;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}