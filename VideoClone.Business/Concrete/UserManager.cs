using VideoClone.Business.Abstract;
using VideoClone.Core.Entities.Concrete;
using VideoClone.Core.Utilities.Results;
using VideoClone.Core.Utilities.Security.Hashing;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public User GetById(Guid id)
    {
        return _userDal.Get(u => u.Id == id);
    }

    public User GetByEmail(string email)
    {
        return _userDal.Get(u => u.Email == email);
    }

    public IResult Add(User user)
    {
        return _userDal.Add(user)
            ? new SuccessResult()
            : new ErrorResult();
    }

    public List<OperationClaim> GetClaims(User user)
    {
        return _userDal.GetClaims(user);
    }

    public IResult ChangePassword(Guid userId, ChangePasswordDto changePasswordDto)
    {
        var user = GetById(userId);
        if (user == null) return new ErrorResult("User not found!");

        if (!HashingHelper.VerifyPasswordHash(changePasswordDto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
            return new ErrorResult("Current password is incorrect!");

        HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out var passwordHash, out var passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        return _userDal.Update(user)
            ? new SuccessResult("Password updated.")
            : new ErrorResult("Password cannot updated");
    }

    public IResult Delete(User user)
    {
        return _userDal.Delete(user)
            ? new SuccessResult("User deleted.")
            : new ErrorResult("User cannot deleted");
    }
}