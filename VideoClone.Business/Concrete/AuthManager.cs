using VideoClone.Business.Abstract;
using VideoClone.Core.Entities.Concrete;
using VideoClone.Core.Utilities.Results;
using VideoClone.Core.Utilities.Security.Hashing;
using VideoClone.Core.Utilities.Security.Jwt;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserService _userService;
    private readonly IChannelDal _channelDal;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IChannelDal channelDal)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _channelDal = channelDal;
    }

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
    {
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash, out var passwordSalt);

        var user = new User
        {
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            Email = userForRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = false
        };

        var channel = new Channel()
        {
            Name = userForRegisterDto.FirstName + " " + userForRegisterDto.LastName,
            User = user,
            UserId = user.Id,
            Verified = false
        };

        if (_userService.Add(user).Success)
        {
            _channelDal.Add(channel);
            return new SuccessDataResult<User>(user, "User created.");
        }

        return new ErrorDataResult<User>(null, "User cannot created");
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
        if (userToCheck == null) return new ErrorDataResult<User>(null, "User not found");

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt)) return new ErrorDataResult<User>(null, "Invalid password");

        if (userToCheck.Status == false) return new ErrorDataResult<User>(null, "User not confirmed");

        return new SuccessDataResult<User>(userToCheck, "Login successful");
    }


    public IResult UserExists(string email)
    {
        if (_userService.GetByEmail(email) != null) return new SuccessResult("Already exist");

        return new ErrorResult();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Access token is created.");
    }
}