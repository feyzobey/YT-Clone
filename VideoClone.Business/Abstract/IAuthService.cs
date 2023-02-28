using VideoClone.Core.Entities.Concrete;
using VideoClone.Core.Utilities.Results;
using VideoClone.Core.Utilities.Security.Jwt;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IResult UserExists(string email);
    IDataResult<AccessToken> CreateAccessToken(User user);
}